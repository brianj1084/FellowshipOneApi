namespace FellowshipOneApi
{
    public static class FellowshipOneConfig
    {
        /********************************Relative Paths for requesting tokens*****************/
        // Path to request an unauthorized request token
        public static string RequestTokenPath = "/v1/Tokens/RequestToken";
        // Path to request access token
        public static string AccessTokenPath = "/v1/Tokens/AccessToken";
        // 2nd PARTY
        //public static string accesstoken_path = "/v1/PortalUser/AccessToken";
        // The path consumer redirects the user to so that user can authenticate himself on the
        // service provider side
        public static string AuthPath = "/v1/PortalUser/Login";
    
        /********************************API Specific paths***********************************/
        public static string F1HouseholdCreate = "/v1/Households";
        public static string F1HouseholdPeople = "/v1/Households/{0}/People";
        public static string F1PeopleEdit = "/v1/People/{0}/Edit";
        public static string F1PeopleCreate = "/v1/People";
        public static string F1PeopleShow = "/v1/People/{0}";
        public static string F1PeopleUpdate = "/v1/People/{0}";
        public static string F1PeopleNew = "/v1/People/New";
        public static string F1StatusesList = "/v1/People/Statuses";
        public static string F1HouseholdMemberTypesList = "/v1/People/HouseholdMemberTypes";
        public static string F1HouseholdMemberTypesShow = "/v1/People/HouseholdMemberTypes/{0}";
        public static string F1PeopleSearch = "/v1/People/Search";
        public static string F1PeopleAddress = "/v1/People/{0}/Addresses";
        public static string F1PeopleAddressUpdate = "/v1/People/{0}/Addresses/{1}";
        public static string F1PeopleCommunications = "/v1/People/{0}/Communications";
        public static string F1PeopleCommunicationsUpdate = "/v1/People/{0}/Communications/{1}";
        public static string F1Addresstypes = "/v1/Addresses/AddressTypes";
        public static string F1Communicationtypes = "/v1/Communications/CommunicationType";

        public static string F1HouseholdAddress = "/v1/Households/{0}/Addresses";
        public static string F1HouseholdAddressShow = "/v1/Households/{0}/Addresses/{1}";

        public static string F1HouseholdAddressNew = "/v1/Households/{0}/Addresses/New";
        public static string F1HouseholdAddressEdit = "/v1/Households/{0}/Addresses/{1}/Edit";
        public static string F1HouseholdAddressUpdate = "/v1/Households/{0}/Addresses/{1}";
        public static string F1HouseholdAddressDelete = "/v1/Households/{0}/Addresses/{1}";
        public static string F1HouseholdCommunications = "/v1/Households/{0}/Communications";
        public static string F1HouseholdCommunicationShow = "/v1/Households/{0}/Communications/{1}";

        public static string F1PeopleAddressList = "/v1/People/{0}/Addresses";
        public static string F1PeopleAddressShow = "/v1/People/{0}/Addresses/{1}";
        public static string F1PeopleAddressNew = "/v1/People/{0}/Addresses/New";
        public static string F1PeopleAddressEdit = "/v1/People/{0}/Addresses/{1}/Edit";
        public static string F1PeopleAddressCreate = "/v1/People/{0}/Addresses";
        public static string F1PeopleAddressDelete = "/v1/People/{0}/Addresses/{1}";

        public static string F1HouseholdCommunicationsList = "/v1/Households/{0}/Communications";
        public static string F1HouseholdCommunicationsShow = "/v1/Households/{0}/Communications/{1}";
        public static string F1HouseholdCommunicationsNew = "/v1/Households/{0}/Communications/New";
        public static string F1HouseholdCommunicationsEdit = "/v1/Households/{0}/Communications/{1}/Edit";
        public static string F1HouseholdCommunicationsCreate = "/v1/Households/{0}/Communications";
        public static string F1HouseholdCommunicationsUpdate = "/v1/Households/{0}/Communications/{1}";
        public static string F1HouseholdCommunicationsDelete = "/v1/Households/{0}/Communications/{1}";

        public static string F1PeopleCommunicationsList = "/v1/People/{0}/Communications";
        public static string F1PeopleCommunicationsShow = "/v1/People/{0}/Communications/{1}";
        public static string F1PeopleCommunicationsNew = "/v1/People/{0}/Communications/New";
        public static string F1PeopleCommunicationsEdit = "v1/People/{0}/Communications/{1}/Edit";
        public static string F1PeopleCommunicationsCreatet = "/v1/People/{0}/Communications";
        public static string F1PeopleCommunicationsDelete = "/v1/People/{0}/Communications/{1}";

        public static string F1HouseholdShow = "/v1/Households/{0}";
        public static string F1HouseholdEdit = "/v1/Households/{0}/Edit";
        public static string F1HouseholdNew = "/v1/Households/New";
        public static string F1HouseholdUpdate = "/v1/Households/{0}";
        public static string F1HouseholdSearch = "/v1/Households/Search";

        public static string F1PeopleAttributesList ="/v1/People/{0}/Attributes";
        public static string F1PeopleAttributesShow ="v1/People/{0}/Attributes/{1}";
        public static string F1PeopleAttributesNew ="/v1/People/{0}/Attributes/New";
        public static string F1PeopleAttributesEdit ="/v1/People/{0}/Attributes/{1}/Edit";
        public static string F1PeopleAttributesCreate ="/v1/People/{0}/Attributes";
        public static string F1PeopleAttributesUpdate ="/v1/People/{0}/Attributes/{1}";
        public static string F1PeopleAttributesDelete  ="/v1/People/{0}/Attributes/{1}";

        public static string F1AddresstypeShow ="/v1/Addresses/AddressTypes/{0}";

        public static string F1AddressShow ="/v1/Addresses/{0}";
        public static string F1AddressNew ="/v1/Addresses/New";
        public static string F1AddressEdit ="/v1/Addresses/{0}/Edit";
        public static string F1AddressCreate ="/v1/Addresses";
        public static string F1AddressUpdate ="/v1/Addresses/{0}";
        public static string F1AddressDelete ="/v1/Addresses/{0}";

        public static string F1AttributeGroupsList = "/v1/People/AttributeGroups";
        public static string F1AttributeGroupsShow = "/v1/People/AttributeGroups/{0}";

        public static string F1AttributeList = "/v1/People/AttributeGroups/{0}/Attributes";
        public static string F1AttributeShow ="/v1/People/AttributeGroups/{0}/Attributes/{1}";

        public static string F1CommunicationsShow = "/v1/Communications/{0}";
        public static string F1CommunicationsNew = "/v1/Communications/New";
        public static string F1CommunicationsEdit = "/v1/Communications/{0}/Edit";
        public static string F1CommunicationsCreate = "/v1/Communications";
        public static string F1CommunicationsUpdate = "/v1/Communications/{0}";
        public static string F1CommunicationsDelete = "/v1/Communications/{0}";

        public static string F1CommunicationtypesShow = "/v1/Communications/CommunicationTypes/{0}";

        public static string F1DenominationsList = "/v1/People/Denominations";
        public static string F1DenominationsShow ="/v1/People/Denominations/{0}";

        public static string F1OccupationsList = "/v1/People/Occupations";
        public static string F1OccupationsShow = "/v1/People/Occupations/{0}";

        public static string F1SchoolsList = "/v1/People/Schools";
        public static string F1SchoolsShow = "/v1/People/Schools/{0}";

        public static string F1StatusesShow = "/v1/People/Statuses/{0}";

        public static string F1SubstatusesList = "/v1/People/Statuses/{0}/SubStatuses";
        public static string F1SubstatusesShow = "/v1/People/Statuses/{0}/SubStatuses/{1}";

        public static string F1GroupsSearch = "/Groups/v1/Groups/Search";
        public static string F1GroupMembers = "/Groups/v1/Groups/{0}/Members";
    }
}
