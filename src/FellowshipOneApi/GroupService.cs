using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using FellowshipOneApi.Entities;
using TimeZone = FellowshipOneApi.Entities.TimeZone;

namespace FellowshipOneApi
{
    public class GroupService
    {
        private readonly IFellowshipOneClient _fOneClient;
        public GroupService(IFellowshipOneClient fOneClient)
        {
            _fOneClient = fOneClient;
        }

        public List<Group> GetGroupList()
        {
            var requestUrl = _fOneClient.BaseUrl + FellowshipOneConfig.F1GroupsSearch + "?issearchable=true ";
            var response = _fOneClient.Request(requestUrl, new Dictionary<string, string>());

            var rootElement = XElement.Parse(response);

            return rootElement.Elements().Select(ParseGroup).ToList();
        }
 
        public GroupMemberPage GetGroupMemberPageForGroup(long groupId, int page = 1)
        {
            var requestUrl = _fOneClient.BaseUrl + string.Format(FellowshipOneConfig.F1GroupMembers, groupId) + string.Format("?page={0}", page);
            var response = _fOneClient.Request(requestUrl, new Dictionary<string, string>());

            var rootElement = XElement.Parse(response);

            var groupMemberPage = new GroupMemberPage();

            foreach (var attribute in rootElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "count":
                        int count;
                        if (int.TryParse(attribute.Value, out count))
                            groupMemberPage.Count = count;
                        break;

                    case "pageNumber":
                        int pageNumber;
                        if (int.TryParse(attribute.Value, out pageNumber))
                            groupMemberPage.PageNumber = pageNumber;
                        break;

                    case "totalRecords":
                        int totalRecords;
                        if (int.TryParse(attribute.Value, out totalRecords))
                            groupMemberPage.TotalRecords = totalRecords;
                        break;

                    case "additionalPages":
                        int additionalPages;
                        if (int.TryParse(attribute.Value, out additionalPages))
                            groupMemberPage.AdditionalPages = additionalPages;
                        break;
                }
            }

            groupMemberPage.GroupMemberList = rootElement.Elements().Select(ParseGroupMember).ToList();

            return groupMemberPage;
        }

        private static GroupMember ParseGroupMember(XElement groupMemberElement)
        {
            var groupMember = new GroupMember();

            foreach (var attribute in groupMemberElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "array":
                        bool array;
                        if (bool.TryParse(attribute.Value, out array))
                            groupMember.Array = array;
                        break;

                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            groupMember.Id = id;
                        break;

                    case "uri":
                        groupMember.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in groupMemberElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "group":
                        groupMember.Group = ParseGroupMemberGroup(element);
                        break;

                    case "person":
                        groupMember.Person = ParseGroupMemberPerson(element);
                        break;

                    case "membertype":
                        groupMember.MemberType = ParseGroupMemberType(element);
                        break;

                    case "createdDate":
                        DateTime createdDate;
                        if (DateTime.TryParse(element.Value, out createdDate))
                            groupMember.CreatedDate = createdDate;
                        break;

                    case "lastUpdatedDate":
                        DateTime lastUpdatedDate;
                        if (DateTime.TryParse(element.Value, out lastUpdatedDate))
                            groupMember.LastUpdatedDate = lastUpdatedDate;
                        break;

                    case "createdByPerson":
                        groupMember.CreatedByPerson = ParseCreatedByPerson(element);
                        break;

                    case "lastUpdatedByPerson":
                        groupMember.LastUpdatedByPerson = ParseLastUpdatedByPerson(element);
                        break;
                }
            }

            return groupMember;
        }

        private static GroupMemberGroup ParseGroupMemberGroup(XElement groupMemberGroupElement)
        {
            var groupMemberGroup = new GroupMemberGroup();

            foreach (var attribute in groupMemberGroupElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            groupMemberGroup.Id = id;
                        break;

                    case "uri":
                        groupMemberGroup.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in groupMemberGroupElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        groupMemberGroup.Name = element.Value;
                        break;
                }
            }

            return groupMemberGroup;
        }

        private static GroupMemberPerson ParseGroupMemberPerson(XElement groupMemberPersonElement)
        {
            var groupMemberPerson = new GroupMemberPerson();

            foreach (var attribute in groupMemberPersonElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            groupMemberPerson.Id = id;
                        break;

                    case "uri":
                        groupMemberPerson.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in groupMemberPersonElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        groupMemberPerson.Name = element.Value;
                        break;
                }
            }

            return groupMemberPerson;
        }

        private static GroupMemberType ParseGroupMemberType(XElement groupMemberTypeElement)
        {
            var groupMemberType = new GroupMemberType();

            foreach (var attribute in groupMemberTypeElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            groupMemberType.Id = id;
                        break;

                    case "uri":
                        groupMemberType.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in groupMemberTypeElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        groupMemberType.Name = element.Value;
                        break;
                }
            }

            return groupMemberType;
        }

        private static Group ParseGroup(XElement groupElement)
        {
            var group = new Group();

            foreach (var attribute in groupElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "array":
                        bool array;
                        if (bool.TryParse(attribute.Value, out array))
                            group.Array = array;
                        break;

                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            group.Id = id;
                        break;

                    case "uri":
                        group.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in groupElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        group.Name = element.Value;
                        break;
                        
                    case "description":
                        group.Description = element.Value;
                        break;

                    case "startDate":
                        DateTime startDate;
                        if (DateTime.TryParse(element.Value, out startDate))
                            group.StartDate = startDate;
                        break;

                    case "expirationDate":
                        DateTime expirationDate;
                        if (DateTime.TryParse(element.Value, out expirationDate))
                            group.ExpirationDate = expirationDate;
                        break;

                    case "isOpen":
                        bool isOpen;
                        if (bool.TryParse(element.Value, out isOpen))
                            group.IsOpen = isOpen;
                        break;

                    case "isPublic":
                        bool isPublic;
                        if (bool.TryParse(element.Value, out isPublic))
                            group.IsPublic = isPublic;
                        break;

                    case "hasChildcare":
                        bool hasChildcare;
                        if (bool.TryParse(element.Value, out hasChildcare))
                            group.HasChildcare = hasChildcare;
                        break;

                    case "isSearchable":
                        bool isSearchable;
                        if (bool.TryParse(element.Value, out isSearchable))
                            group.IsSearchable = isSearchable;
                        break;

                    case "campusChurch":
                        group.ChurchCampus = ParseCampusChurch(element);
                        break;

                    case "groupType":
                        group.GroupType = ParseGroupType(element);
                        break;

                    case "groupURL":
                        group.GroupUrl = element.Value;
                        break;

                    case "timeZone":
                        group.TimeZone = ParseTimeZone(element);
                        break;

                    case "gender":
                        group.Gender = ParseGender(element);
                        break;

                    case "maritalStatus":
                        group.MaritalStatus = ParseMaritalStatus(element);
                        break;

                    case "startAgeRange":
                        group.StartAgeRange = element.Value;
                        break;

                    case "endAgeRange":
                        group.EndAgeRange = element.Value;
                        break;

                    case "dateRangeType":
                        group.DateRangeType = ParseDateRangeType(element);
                        break;

                    case "leadersCount":
                        long leadersCount;
                        if (long.TryParse(element.Value, out leadersCount))
                            group.LeadersCount = leadersCount;
                        break;
                       
                    case "membersCount":
                        long membersCount;
                        if (long.TryParse(element.Value, out membersCount))
                            group.MembersCount = membersCount;
                        break;

                    case "openProspectsCount":
                        long openProspectsCount;
                        if (long.TryParse(element.Value, out openProspectsCount))
                            group.OpenProspectsCount = openProspectsCount;
                        break;

                    case "event":
                        group.Event = ParseEvent(element);
                        break;

                    case "location":
                        group.Location = ParseLocation(element);
                        break;

                    case "createdDate":
                        DateTime createdDate;
                        if (DateTime.TryParse(element.Value, out createdDate))
                            group.CreatedDate = createdDate;
                        break;

                    case "createdByPerson":
                        group.CreatedByPerson = ParseCreatedByPerson(element);
                        break;

                    case "lastUpdatedDate":
                        DateTime lastUpdatedDate;
                        if (DateTime.TryParse(element.Value, out lastUpdatedDate))
                            group.LastUpdatedDate = lastUpdatedDate;
                        break;

                    case "lastUpdatedByPerson":
                        group.LastUpdatedByPerson = ParseLastUpdatedByPerson(element);
                        break;
                }
            }

            return group;
        }

        private static ChurchCampus ParseCampusChurch(XElement churchCampusElement)
        {
            var churchCampus = new ChurchCampus();
            foreach (var attribue in churchCampusElement.Attributes())
            {
                switch (attribue.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribue.Value, out id))
                            churchCampus.Id = id;
                        break;

                }
            }

            foreach (var element in churchCampusElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        churchCampus.Name = element.Value;
                        break;
                }
            }

            return churchCampus;
        }

        private static GroupType ParseGroupType(XElement groupTypeElement)
        {
            var groupType = new GroupType();

            foreach (var attribute in groupTypeElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            groupType.Id = id;
                        break;

                    case "uri":
                        groupType.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in groupTypeElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        groupType.Name = element.Value;
                        break;
                }
            }

            return groupType;
        }

        private static TimeZone ParseTimeZone(XElement timeZoneElement)
        {
            var timeZone = new TimeZone();

            foreach (var attribute in timeZoneElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            timeZone.Id = id;
                        break;

                    case "uri":
                        timeZone.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in timeZoneElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        timeZone.Name = element.Value;
                        break;
                }
            }

            return timeZone;
        }

        private static Gender ParseGender(XElement genderElement)
        {
            var gender = new Gender();

            foreach (var attribute in genderElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            gender.Id = id;
                        break;

                    case "uri":
                        gender.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in genderElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        gender.Name = element.Value;
                        break;
                }
            }

            return gender;
        }

        private static MaritalStatus ParseMaritalStatus(XElement maritalStatusElement)
        {
            var maritalStatus = new MaritalStatus();

            foreach (var attribute in maritalStatusElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            maritalStatus.Id = id;
                        break;

                    case "uri":
                        maritalStatus.Uri = attribute.Value;
                        break;
                }                
            }

            foreach (var element in maritalStatusElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        maritalStatus.Name = element.Value;
                        break;
                }
            }

            return maritalStatus;
        }

        private static DateRangeType ParseDateRangeType(XElement dateRangeTypeElement)
        {
            var dateRangeType = new DateRangeType();

            foreach (var attribute in dateRangeTypeElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            dateRangeType.Id = id;
                        break;

                    case "uri":
                        dateRangeType.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in dateRangeTypeElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        dateRangeType.Name = element.Value;
                        break;
                }
            }

            return dateRangeType;
        }

        private static Event ParseEvent(XElement eventElement)
        {
            var @event = new Event();

            foreach (var attribute in eventElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            @event.Id = id;
                        break;

                    case "uri":
                        @event.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in eventElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        @event.Name = element.Value;
                        break;
                }
            }

            return @event;
        }

        private static Location ParseLocation(XElement locationElement)
        {
            var location = new Location();

            foreach (var attribute in locationElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            location.Id = id;
                        break;

                    case "uri":
                        location.Uri = attribute.Value;
                        break;
                }
            }

            foreach (var element in locationElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "name":
                        location.Name = element.Value;
                        break;

                    case "description":
                        location.Description = element.Value;
                        break;

                    case "isOnline":
                        bool isOnline;
                        if (bool.TryParse(element.Value, out isOnline))
                            location.IsOnline = isOnline;
                        break;

                    case "url":
                        location.Url = element.Value;
                        break;

                    case "address":
                        location.LocationAddress = ParseLocationAddress(element);
                        break;
                        
                    case "createdDate":
                        DateTime createdDate;
                        if (DateTime.TryParse(element.Value, out createdDate))
                            location.CreatedDate = createdDate;
                        break;

                    case "createdByPerson":
                        location.CreatedByPerson = ParseCreatedByPerson(element);
                        break;

                    case "lastUpdatedDate":
                        DateTime lastUpdatedDate;
                        if (DateTime.TryParse(element.Value, out lastUpdatedDate))
                            location.LastUpdatedDate = lastUpdatedDate;
                        break;

                    case "lastUpdatedByPerson":
                        location.LastUpdatedByPerson = ParseLastUpdatedByPerson(element);
                        break;
                }
            }

            return location;
        }

        private static LocationAddress ParseLocationAddress(XElement locationAddressElement)
        {
            var locationAddress = new LocationAddress();

            foreach (var element in locationAddressElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "address1":
                        locationAddress.Address1 = element.Value;
                        break;

                    case "address2":
                        locationAddress.Address2 = element.Value;
                        break;

                    case "address3" :
                        locationAddress.Address3 = element.Value;
                        break;

                    case "city":
                        locationAddress.City = element.Value;
                        break;

                    case "stProvince":
                        locationAddress.StateProvince = element.Value;
                        break;

                    case "postalCode":
                        locationAddress.PostalCode = element.Value;
                        break;

                    case "county":
                        locationAddress.County = element.Value;
                        break;

                    case "country":
                        locationAddress.Country = element.Value;
                        break;

                    case "carrieRoute":
                        locationAddress.CarrierRoute = element.Value;
                        break;

                    case "deliveryPoint":
                        locationAddress.DeliveryPoint = element.Value;
                        break;

                    case "latitude":
                        locationAddress.Latitude = element.Value;
                        break;

                    case "longitude":
                        locationAddress.Longitude = element.Value;
                        break;

                    case "createdDate":
                        DateTime createdDate;
                        if (DateTime.TryParse(element.Value, out createdDate))
                            locationAddress.CreatedDate = createdDate;
                        break;

                    case "createdByPerson":
                        locationAddress.CreatedByPerson = ParseCreatedByPerson(element);
                        break;

                    case "lastUpdatedDate":
                        DateTime lastUpdatedDate;
                        if (DateTime.TryParse(element.Value, out lastUpdatedDate))
                            locationAddress.LastUpdatedDate = lastUpdatedDate;
                        break;

                    case "lastUpdatedByPerson":
                        locationAddress.LastUpdatedByPerson = ParseLastUpdatedByPerson(element);
                        break;
                }
            }

            return locationAddress;
        }

        private static CreatedByPerson ParseCreatedByPerson(XElement createdByPersonElement)
        {
            var createdByPerson = new CreatedByPerson();

            foreach (var attribute in createdByPersonElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            createdByPerson.Id = id;
                        break;

                    case "uri":
                        createdByPerson.Uri = attribute.Value;
                        break;
                }
            }

            return createdByPerson;
        }

        private static LastUpdatedByPerson ParseLastUpdatedByPerson(XElement lastUpdatedByPersonElement)
        {
            var lastUpdatedByPerson = new LastUpdatedByPerson();
            foreach (var attribute in lastUpdatedByPersonElement.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "id":
                        long id;
                        if (long.TryParse(attribute.Value, out id))
                            lastUpdatedByPerson.Id = id;
                        break;

                    case "uri":
                        lastUpdatedByPerson.Uri = attribute.Value;
                        break;
                }
            }

            return lastUpdatedByPerson;
        }
    }
}
