using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FellowshipOneApi
{
    public class RequestSigner
    {
        public static string BuildSignature(string consumerSecret, string tokenSecret, string httpMethod, string url, Dictionary<string, string> oAuthOptions)
        {
            tokenSecret = tokenSecret ?? "";

            var baseString = GetSignatureBaseString(httpMethod, url, oAuthOptions);

            var key = Encoding.ASCII.GetBytes(string.Format("{0}&{1}", UrlEncode(consumerSecret), string.IsNullOrEmpty(tokenSecret) ? "" : UrlEncode(tokenSecret)));
            var hmacsha1 = new HMACSHA1(key);

            var b64String = Convert.ToBase64String(hmacsha1.ComputeHash(Encoding.UTF8.GetBytes(baseString)));
            return b64String;
        }

        private static string GetSignatureBaseString(string httpMethod, string url, Dictionary<string, string> oAuthOptions)
        {
            var uri = new Uri(url);

            var normalizedUrl = string.Format("{0}://{1}{2}", uri.Scheme, uri.Host, uri.AbsolutePath);

            var queryString = uri.Query;

            var queryParameters = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(queryString))
            {
                var querySegments = queryString.Split('&');
                foreach (string segment in querySegments)
                {
                    var parts = segment.Split('=');
                    if (parts.Length > 0)
                    {
                        var key = parts[0].Trim(new[] { '?', ' ' });
                        var val = parts[1].Trim();

                        queryParameters.Add(key, val);
                    }
                }                
            }

            var signableOptionsRaw = oAuthOptions.Concat(queryParameters).OrderBy(k => k.Key);

            var signableOptions = new Dictionary<string, string>();
            foreach (var option in signableOptionsRaw)
            {
                var key = UrlEncode(option.Key);
                var val = UrlEncode(option.Value);

                signableOptions.Add(key,val);
            }

            IOrderedEnumerable<KeyValuePair<string, string>> orderedSignableOptions = signableOptions.OrderBy(k => k.Key);

            var signableOptionParts = orderedSignableOptions.Select(option => String.Format("{0}%3D{1}", option.Key, option.Value)).ToList();

            var signableOptionString = string.Join("%26", signableOptionParts);

            var signatureParts = new List<string> {httpMethod, UrlEncode(normalizedUrl), signableOptionString};

            return string.Join("&", signatureParts);
        }

        private const string UnreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

        private static string UrlEncode(string value)
        {
            var result = new StringBuilder();

            foreach (var symbol in value)
            {
                if (UnreservedChars.IndexOf(symbol) != -1)
                {
                    result.Append(symbol);
                }
                else
                {
                    result.Append('%' + String.Format("{0:X2}", (int)symbol));
                }
            }

            return result.ToString();
        }
    }
}
