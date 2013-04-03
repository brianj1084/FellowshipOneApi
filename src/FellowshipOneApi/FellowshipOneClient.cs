using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace FellowshipOneApi
{
    public interface IFellowshipOneClient
    {
        string RequestToken { get; set; }
        string TokenSecret { get; set; }
        string BaseUrl { get; }
        string RequestTokenPath { get; set; }
        string AccessTokenPath { get; set; }
        string AuthPath { get; set; }
        string ChurchCode { get; set; }
        void SetPathsFromConfig();
        string Request(string requestUrl, Dictionary<string, string> nonOAuthHeaders);
        string PostRequest(string requestUrl, string requestBody, Dictionary<string, string> nonOAuthHeaders);
        string PutRequest(string requestUrl, string requestBody, Dictionary<string, string> nonOAuthHeaders);
        bool GetRequestToken();
        bool GetAccessToken(string requestToken, string tokenSecret);
    }

    [Serializable]
    public class FellowshipOneClient : IFellowshipOneClient
    {
        private string _baseUrl;

        private readonly string _consumerKey;
        private readonly string _consumerSecret;

        private string _requestToken;
        private string _tokenSecret = "";

        private string _requestTokenPath;
        private string _accessTokenPath;
        private string _authPath;
        private string _churchCode;

        public string RequestToken
        {
            get { return _requestToken; }
            set { _requestToken = value; }
        }

        public string TokenSecret
        {
            get { return _tokenSecret; }
            set { _tokenSecret = value; }
        }

        public string BaseUrl
        {
            get { return _baseUrl; }
        }

        public string RequestTokenPath
        {
            get { return _requestTokenPath; }
            set { _requestTokenPath = value; }
        }

        public string AccessTokenPath
        {
            get { return _accessTokenPath; }
            set { _accessTokenPath = value; }
        }

        public string AuthPath
        {
            get { return _authPath; }
            set { _authPath = value; }
        }

        public string ChurchCode
        {
            get { return _churchCode; }
            set
            {
                _churchCode = value;
                _churchCode = _churchCode.Replace(" ", "");
                _churchCode = _churchCode.ToLower();
                _baseUrl = string.Format(_baseUrl, _churchCode);
                
            }
        }

        public FellowshipOneClient(string baseUrl, string consumerKey, string consumerSecret)
        {
            _baseUrl = baseUrl;
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
        }

        public void SetPathsFromConfig()
        {
            _requestTokenPath = FellowshipOneConfig.RequestTokenPath;
            _accessTokenPath = FellowshipOneConfig.AccessTokenPath;
            _authPath = FellowshipOneConfig.AuthPath;
        }

        private static string GetNonce()
        {
            var rnd = new Random();
            return (DateTime.Now.Ticks + rnd.Next(9999)).ToString(CultureInfo.InvariantCulture);
        }

        private static string GetTimeStamp()
        {
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString(CultureInfo.InvariantCulture);
        }

        private string GetOAuthHeader(string httpMethod, string requestUrl)
        {
            var oAuthHeaderValues = new Dictionary<string, string>
                                        {
                                            {"oauth_consumer_key", _consumerKey},
                                            {"oauth_nonce", GetNonce()},
                                            {"oauth_signature_method", "HMAC-SHA1"},
                                            {"oauth_timestamp", GetTimeStamp()},
                                            {"oauth_version", "1.0"}
                                        };
            if (!string.IsNullOrEmpty(_requestToken))
            {
                oAuthHeaderValues["oauth_token"] = _requestToken;
            }

            oAuthHeaderValues["oauth_signature"] = RequestSigner.BuildSignature(_consumerSecret, _tokenSecret,
                                                                                httpMethod, requestUrl,
                                                                                oAuthHeaderValues);
            return BuildOAuthHeader(oAuthHeaderValues);
        }

        private static string BuildOAuthHeader(Dictionary<string, string> oAuthHeaderValues)
        {
            var oAuthValues = (from item in oAuthHeaderValues where item.Key.Substring(0, 6) == "oauth_" select string.Format("{0}={1}", item.Key, UrlEncode(item.Value))).ToList();

            string header = string.Join(",", oAuthValues);

            return header;
        }

        private string SendRequest(string httpMethod, string requestUrl, Dictionary<string, string> nonOAuthHeaders, HttpStatusCode responseStatusCode, string requestBody = "")
        {
            var oAuthHeader = GetOAuthHeader(httpMethod, requestUrl);

            var request = (HttpWebRequest)WebRequest.Create(requestUrl);
            request.Method = httpMethod;

            request.Accept = "*/*";
            request.Headers.Add(HttpRequestHeader.Authorization, oAuthHeader);

            foreach (var header in nonOAuthHeaders)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            if (httpMethod == "POST" || httpMethod == "PUT")
            {
                request.ContentType = "application/x-www-form-urlencoded";
                var dataStream = request.GetRequestStream();
                byte[] bytes = Encoding.UTF8.GetBytes(requestBody);
                dataStream.Write(bytes, 0, bytes.Length);
            }

            string responseBody;

            try
            {
                var httpResponse = (HttpWebResponse)request.GetResponse();
                responseBody = httpResponse.StatusCode == responseStatusCode ? GetResponseBody(httpResponse) : null;
                httpResponse.Close();
            }
            catch (WebException ex)
            {
                responseBody = GetResponseBody((HttpWebResponse) ex.Response);
            }


            return responseBody;
        }

        public string Request(string requestUrl, Dictionary<string, string> nonOAuthHeaders)
        {
            return SendRequest("GET", requestUrl, nonOAuthHeaders, HttpStatusCode.OK);
        }

        public string PostRequest(string requestUrl, string requestBody, Dictionary<string, string> nonOAuthHeaders)
        {
            return SendRequest("POST", requestUrl, nonOAuthHeaders, HttpStatusCode.Created, requestBody);
        }

        public string PutRequest(string requestUrl, string requestBody, Dictionary<string, string> nonOAuthHeaders)
        {
            return SendRequest("PUT", requestUrl, nonOAuthHeaders, HttpStatusCode.OK, requestBody);
        }

        private static string GetResponseBody(HttpWebResponse httpWebResponse)
        {
            var responseBody = string.Empty;

            var responseStream = httpWebResponse.GetResponseStream();
            if (responseStream != null)
            {
                var encode = Encoding.UTF8;
                var readStream = new StreamReader(responseStream, encode);
                var read = new Char[256];
                var count = readStream.Read(read, 0, 256);
                while (count > 0)
                {
                    var str = new string(read, 0, count);
                    count = readStream.Read(read, 0, 256);
                    responseBody += str;
                }
                readStream.Close();
            }

            return responseBody;
        }

        private static Dictionary<string, string> GetResponseParameters(string responseBody)
        {
            var parameters = new Dictionary<string, string>();

            if (!String.IsNullOrEmpty(responseBody))
            {
                var paramArray = responseBody.Split('&');

                foreach (var s in paramArray)
                {
                    var paramKeyVal = s.Split('=');
                    if (paramKeyVal.Length >= 2)
                        parameters.Add(paramKeyVal[0], paramKeyVal[1]);
                }
            }

            return parameters;
        }

        public bool GetRequestToken()
        {
            var requestUrl = _baseUrl + _requestTokenPath;

            var response = SendRequest("POST", requestUrl, new Dictionary<string, string>(), HttpStatusCode.OK);

            var responseParams = GetResponseParameters(response);

            if (responseParams.ContainsKey("oauth_token") && responseParams.ContainsKey("oauth_token_secret"))
            {
                _requestToken = responseParams["oauth_token"];
                _tokenSecret = responseParams["oauth_token_secret"];                
            } 

            return !string.IsNullOrEmpty(_requestToken) && _tokenSecret.Length > 0;
        }

        public bool GetAccessToken(string requestToken, string tokenSecret)
        {
            _requestToken = requestToken;
            _tokenSecret = tokenSecret;

            var requestUrl = _baseUrl + _accessTokenPath;

            var response = SendRequest("POST", requestUrl, new Dictionary<string, string>(), HttpStatusCode.OK);

            var responseParams = GetResponseParameters(response);

            if (responseParams.ContainsKey("oauth_token") && responseParams.ContainsKey("oauth_token_secret"))
            {
                _requestToken = responseParams["oauth_token"];
                _tokenSecret = responseParams["oauth_token_secret"];
            }

            return !string.IsNullOrEmpty(_requestToken) && _tokenSecret.Length > 0;
        }

        private const string UnreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

        public static string UrlEncode(string value)
        {
            var result = new StringBuilder();

            foreach (var symbol in value)
            {
                if (UnreservedChars.IndexOf(symbol) >= 0)
                {
                    result.Append(symbol);
                }
                else
                {
                    result.AppendFormat("%{0:X2}", (int) symbol);
                }
            }

            return result.ToString();
        }
    }
}
