using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using FellowshipOneApi.Entities;
using Attribute = FellowshipOneApi.Entities.Attribute;

namespace FellowshipOneApi
{
    public class PersonService
    {
        private readonly IFellowshipOneClient _fOneClient;
        public PersonService (IFellowshipOneClient fOneClient)
        {
            _fOneClient = fOneClient;
        }

        public Person GetPersonById(string id)
        {
            var requestUrl = _fOneClient.BaseUrl + FellowshipOneConfig.F1PeopleSearch + string.Format("?id={0}&include=communications", id);

            var response = _fOneClient.Request(requestUrl, new Dictionary<string, string>());

            var rootElement = XElement.Parse(response);

            var personElement = rootElement.Elements().FirstOrDefault();

            if (personElement == null)
                return null;

            var person = ParsePerson(personElement);

            return person;
        }

        public PersonPage GetPersonPage(int page = 1, string searchParam = null)
        {
            var requestUrl = _fOneClient.BaseUrl + FellowshipOneConfig.F1PeopleSearch;

            if (!string.IsNullOrEmpty(searchParam))
            {
                requestUrl += string.Format("?searchFor={0}&page={1}", searchParam, page);
            }
            else
            {
                requestUrl += string.Format("?lastUpdatedDate=1900-01-01&page={0}", page);
            }
                
            var response = _fOneClient.Request(requestUrl, new Dictionary<string, string>());

            var rootElement = XElement.Parse(response);

            var personPage = new PersonPage();

            foreach (var attribute in rootElement.Attributes())
            {
                switch(attribute.Name.LocalName)
                {
                    case "count":
                        int count;
                        if (int.TryParse(attribute.Value, out count))
                            personPage.Count = count;
                        break;

                    case "pageNumber":
                        int pageNumber;
                        if (int.TryParse(attribute.Value, out pageNumber))
                            personPage.PageNumber = pageNumber;
                        break;

                    case "totalRecords":
                        int totalRecords;
                        if (int.TryParse(attribute.Value, out totalRecords))
                            personPage.TotalRecords = totalRecords;
                        break;

                    case "additionalPages":
                        int additionalPages;
                        if (int.TryParse(attribute.Value, out additionalPages))
                            personPage.AdditionalPages = additionalPages;
                        break;
                }
            }

            personPage.PersonList = rootElement.Elements().Select(ParsePerson).ToList();
            
            return personPage;
        }

        private static Person ParsePerson(XElement personElement)
        {
            var person = new Person();

            foreach (var attribute in personElement.Attributes())
            {
                switch(attribute.Name.LocalName)
                {
                    case "array":
                        bool array;
                        if (bool.TryParse(attribute.Value, out array))
                            person.Array = array;
                        break;

                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            person.Id = id;
                        break;

                    case "uri":
                        person.Uri = attribute.Value;
                        break;

                    case "imageURI":
                        person.ImageUri = attribute.Value;
                        break;

                    case "oldID":
                        long oldId;
                        if (long.TryParse(attribute.Value, out oldId))
                            person.OldId = oldId;
                        break;

                    case "iCode":
                        person.ICode = attribute.Value;
                        break;

                    case "householdID":
                        long householdId;
                        if (long.TryParse(attribute.Value, out householdId))
                            person.HouseholdId = householdId;
                        break;

                    case "oldHouseholdID":
                        long oldHouseholdId;
                        if (long.TryParse(attribute.Value, out oldHouseholdId))
                            person.OldHouseholdId = oldHouseholdId;
                        break;
                }
            }

            foreach (var element in personElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "title":
                        person.Title = element.Value;
                        break;

                    case "salutation":
                        person.Salutation = element.Value;
                        break;

                    case "prefix":
                        person.Prefix = element.Value;
                        break;
                    
                    case "firstName":
                        person.FirstName = element.Value;
                        break;

                    case "lastName":
                        person.LastName = element.Value;
                        break;
                        
                    case "suffix":
                        person.Suffix = element.Value;
                        break;
                        
                    case "middleName":
                        person.MiddleName = element.Value;
                        break;

                    case "goesByName":
                        person.GoesByName = element.Value;
                        break;

                    case "formerName":
                        person.FormerName = element.Value;
                        break;

                    case "gender":
                        person.Gender = element.Value;
                        break;

                    case "dateOfBirth":
                        DateTime dateOfBirth;
                        if (DateTime.TryParse(element.Value, out dateOfBirth))
                            person.DateOfBirth = dateOfBirth;
                        break;

                    case "maritalStatus":
                        person.MaritalStatus = element.Value;
                        break;

                    case "householdMemberType":
                        person.HouseholdMemberType = ParseHouseholdMemberType(element);
                        break;

                    case "isAuthorized":
                        bool isAuthorized;
                        if (bool.TryParse(element.Value, out isAuthorized))
                            person.IsAuthorized = isAuthorized;
                        break;

                    case "status":
                        person.Status = ParseStatus(element);
                        break;

                    case "occupation":
                        person.Occupation = ParseOccupation(element);
                        break;

                    case "employer":
                        person.Employer = element.Value;
                        break;

                    case "school":
                        person.School = ParseSchool(element);
                        break;

                    case "denomination":
                        person.Denomination = ParseDenomination(element);
                        break;

                    case "formerChurch":
                        person.FormerChurch = element.Value;
                        break;
                     
                    case "barCode":
                        person.BarCode = element.Value;
                        break;

                    case "memberEnvelopeCode":
                        person.MemberEnvelopeCode = element.Value;
                        break;

                    case "defaultTagComment":
                        person.DefaultTagComment = element.Value;
                        break;

                    case "weblink":
                        person.Weblink = ParseWeblink(element);
                        break;

                    case "solicit":
                        person.Solicit = element.Value;
                        break;

                    case "thank":
                        bool thank;
                        if (bool.TryParse(element.Value, out thank))
                            person.Thank = thank;
                        break;

                    case "firstRecord":
                        DateTime firstRecord;
                        if (DateTime.TryParse(element.Value, out firstRecord))
                            person.FirstRecord = firstRecord;
                        break;

                    case "attributes":
                        person.Attributes = element.Elements().Select(ParseAttribute).ToList();
                        break;

                    case "addresses":
                        person.Addresses = element.Elements().Select(ParseAddress).ToList();
                        break;

                    case "communications":
                        person.Communications = element.Elements().Select(ParseCommunication).ToList();
                        break;

                    case "lastMatchDate":
                        DateTime lastMatchDate;
                        if (DateTime.TryParse(element.Value, out lastMatchDate))
                            person.LastMatchDate = lastMatchDate;
                        break;

                    case "createdDate":
                        DateTime createdDate;
                        if (DateTime.TryParse(element.Value, out createdDate))
                            person.CreatedDate = createdDate;
                        break;

                    case "lastUpdatedDate":
                        DateTime lastUpdatedDate;
                        if (DateTime.TryParse(element.Value, out lastUpdatedDate))
                            person.LastUpdatedDate = lastUpdatedDate;
                        break;
                }
            }

            return person;
        }

        private static HouseholdMemberType ParseHouseholdMemberType(XElement householdMemberTypeElement)
        {
            var householdMemberType = new HouseholdMemberType();

            foreach (var attribute in householdMemberTypeElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            householdMemberType.Id = id;
                        break;

                    case "uri":
                        householdMemberType.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in householdMemberTypeElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        householdMemberType.Name = element.Value;
                        break;
                }
            }

            return householdMemberType;
        }

        private static Status ParseStatus(XElement statusElement)
        {
            var status = new Status();

            foreach (var attribute in statusElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            status.Id = id;
                        break;

                    case "uri":
                        status.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in statusElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        status.Name = element.Value;
                        break;

                    case "comment":
                        status.Comment = element.Value;
                        break;

                    case "date":
                        DateTime date;
                        if (DateTime.TryParse(element.Value, out date))
                            status.Date = date;
                        break;

                    case "subStatus":
                        status.SubStatus = ParseSubStatus(element);
                        break;
                }
            }

            return status;
        }

        private static SubStatus ParseSubStatus(XElement subStatusElement)
        {
            var subStatus = new SubStatus();

            foreach (var attribute in subStatusElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            subStatus.Id = id;
                        break;

                    case "uri":
                        subStatus.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in subStatusElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        subStatus.Name = element.Value;
                        break;
                }
            }

            return subStatus;
        }

        private static Occupation ParseOccupation(XElement occupationElement)
        {
            var occupation = new Occupation();

            foreach (var attribute in occupationElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            occupation.Id = id;
                        break;

                    case "uri":
                        occupation.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in occupationElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        occupation.Name = element.Value;
                        break;

                    case "description":
                        occupation.Description = element.Value;
                        break;
                }
            }

            return occupation;
        }

        private static School ParseSchool(XElement schoolElement)
        {
            var school = new School();

            foreach (var attribute in schoolElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            school.Id = id;
                        break;

                    case "uri":
                        school.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in schoolElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        school.Name = element.Value;
                        break;
                }
            }

            return school;
        }

        private static Denomination ParseDenomination(XElement denominationElement)
        {
            var denomination = new Denomination();

            foreach (var attribute in denominationElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            denomination.Id = id;
                        break;

                    case "uri":
                        denomination.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in denominationElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        denomination.Name = element.Value;
                        break;
                }
            }

            return denomination;
        }

        private static Weblink ParseWeblink(XElement weblinkElement)
        {
            var weblink = new Weblink();

            foreach (var element in weblinkElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "userID":
                        long userId;
                        if (long.TryParse(element.Value, out userId))
                            weblink.UserId = userId;
                        break;

                    case "passwordHint":
                        weblink.PasswordHint = element.Value;
                        break;

                    case "passwordAnswer":
                        weblink.PasswordAnswer = element.Value;
                        break;
                }
            }

            return weblink;
        }

        private static Attribute ParseAttribute(XElement attributeElement)
        {
            var attributeItem = new Attribute();

            foreach (var attribute in attributeElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "array":
                        bool array;
                        if (bool.TryParse(attribute.Value, out array))
                            attributeItem.Array = array;
                        break;
                            
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            attributeItem.Id = id;
                        break;

                    case "uri":
                        attributeItem.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in attributeElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "attributeGroup":
                        attributeItem.AttributeGroup = ParseAttributeGroup(element);
                        break;

                    case "startDate":
                        DateTime startDate;
                        if (DateTime.TryParse(element.Value, out startDate))
                            attributeItem.StartDate = startDate;
                        break;

                    case "endDate":
                        DateTime endDate;
                        if (DateTime.TryParse(element.Value, out endDate))
                            attributeItem.EndDate = endDate;
                        break;

                    case "comment":
                        attributeItem.Comment = element.Value;
                        break;

                    case "createdDate":
                        DateTime createdDate;
                        if (DateTime.TryParse(element.Value, out createdDate))
                            attributeItem.CreatedDate = createdDate;
                        break;

                    case "lastUpdatedDate":
                        DateTime lastUpdatedDate;
                        if (DateTime.TryParse(element.Value, out lastUpdatedDate))
                            attributeItem.LastUpdatedDate = lastUpdatedDate;
                        break;
                }
            }

            return attributeItem;
        }

        private static AttributeGroup ParseAttributeGroup(XElement attributeGroupElement)
        {
            var attributeGroup = new AttributeGroup();

            foreach (var attribute in attributeGroupElement.Attributes())
            {
                switch(attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            attributeGroup.Id = id;
                        break;

                    case "uri":
                        attributeGroup.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in attributeGroupElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        attributeGroup.Name = element.Value;
                        break;
                    case "attribute":
                        attributeGroup.GroupAttribute = ParseGroupAttribute(element);
                        break;
                }
            }

            return attributeGroup;
        }

        private static GroupAttribute ParseGroupAttribute(XElement groupAttributeElement)
        {
            var groupAttribute = new GroupAttribute();

            foreach (var attribute in groupAttributeElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            groupAttribute.Id = id;
                        break;

                    case "uri":
                        groupAttribute.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in groupAttributeElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        groupAttribute.Name = element.Value;
                        break;
                }
            }

            return groupAttribute;
        }

        private static Address ParseAddress(XElement addressElement)
        {
            var address = new Address();

            foreach (var attribute in addressElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "array":
                        bool array;
                        if (bool.TryParse(attribute.Value, out array))
                            address.Array = array;
                        break;

                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            address.Id = id;
                        break;

                    case "uri":
                        address.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in addressElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "addressType":
                        address.AddressType = ParseAddressType(element);
                        break;

                    case "address1":
                        address.Address1 = element.Value;
                        break;

                    case "address2":
                        address.Address2 = element.Value;
                        break;

                    case "address3":
                        address.Address3 = element.Value;
                        break;

                    case "city":
                        address.City = element.Value;
                        break;

                    case "postalCode":
                        address.PostalCode = element.Value;
                        break;

                    case "county":
                        address.County = element.Value;
                        break;

                    case "country":
                        address.Country = element.Value;
                        break;

                    case "stProvice":
                        address.StateProvince = element.Value;
                        break;

                    case "carrierRoute":
                        address.CarrierRoute = element.Value;
                        break;

                    case "deliveryPoint":
                        address.DeliveryPoint = element.Value;
                        break;

                    case "addressDate":
                        DateTime addressDate;
                        if (DateTime.TryParse(element.Value, out addressDate))
                            address.AddressDate = addressDate;
                        break;

                    case "addressComment":
                        address.AddressComment = element.Value;
                        break;

                    case "uspsVerified":
                        bool uspsVerified;
                        if (bool.TryParse(element.Value, out uspsVerified))
                            address.UspsVerified = uspsVerified;
                        break;

                    case "addressVerifidDate":
                        DateTime addressVerifiedDate;
                        if (DateTime.TryParse(element.Value, out addressVerifiedDate))
                            address.AddressVerifiedDate = addressVerifiedDate;
                        break;

                    case "lastVerificationAttemptDate":
                        DateTime lastVerificationAttemptDate;
                        if (DateTime.TryParse(element.Value, out lastVerificationAttemptDate))
                            address.LastVerificationAttemptDate = lastVerificationAttemptDate;
                        break;

                    case "createdDate":
                        DateTime createdDate;
                        if (DateTime.TryParse(element.Value, out createdDate))
                            address.CreatedDate = createdDate;
                        break;

                    case "lastUpdatedDate":
                        DateTime lastUpdatedDate;
                        if (DateTime.TryParse(element.Value, out lastUpdatedDate))
                            address.LastUpdatedDate = lastUpdatedDate;
                        break;
                }
            }

            return address;
        }

        private static AddressType ParseAddressType(XElement addressTypeElement)
        {
            var addressType = new AddressType();

            foreach (var attribute in addressTypeElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            addressType.Id = id;
                        break;

                    case "uri":
                        addressType.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in addressTypeElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        addressType.Name = element.Value;
                        break;
                }
            }

            return addressType;
        }

        private static Communication ParseCommunication(XElement communicationElement)
        {
            var communication = new Communication();

            foreach (var attribute in communicationElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "array":
                        bool array;
                        if (bool.TryParse(attribute.Value, out array))
                            communication.Array = array;
                        break;

                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            communication.Id = id;
                        break;

                    case "uri":
                        communication.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in communicationElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "communicationType":
                        communication.CommunicationType = ParseCommunicationType(element);
                        break;

                    case "communicationGeneralType":
                        communication.CommunicationGeneralType = element.Value;
                        break;

                    case "communicationValue":
                        communication.CommunicationValue = element.Value;
                        break;

                    case "searchCommunicationValue":
                        communication.SearchCommunicationValue = element.Value;
                        break;

                    case "listed":
                        bool listed;
                        if (bool.TryParse(element.Value, out listed))
                            communication.Listed = listed;
                        break;

                    case "communicationComment":
                        communication.CommunicationComment = element.Value;
                        break;

                    case "createdDate":
                        DateTime createdDate;
                        if (DateTime.TryParse(element.Value, out createdDate))
                            communication.CreatedDate = createdDate;
                        break;
                        
                    case "lastUpdatedDate":
                        DateTime lastUpdatedDate;
                        if (DateTime.TryParse(element.Value, out lastUpdatedDate))
                            communication.LastUpdatedDate = lastUpdatedDate;
                        break;
                }
            }

            return communication;
        }

        private static CommunicationType ParseCommunicationType(XElement communicationTypeElement)
        {
            var communicationType = new CommunicationType();

            foreach (var attribute in communicationTypeElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            communicationType.Id = id;
                        break;

                    case "uri":
                        communicationType.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in communicationTypeElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        communicationType.Name = element.Value;
                        break;
                }
            }

            return communicationType;
        }
    }
}
