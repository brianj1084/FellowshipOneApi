using System;


namespace FellowshipOneApi.Entities
{
    public class Address
    {
        public bool? Array { get; set; }
        public long? Id { get; set; }
        public string Uri { get; set; }

        public AddressType AddressType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string StateProvince { get; set; }
        public string CarrierRoute { get; set; }
        public string DeliveryPoint { get; set; }
        public DateTime? AddressDate { get; set; }
        public string AddressComment { get; set; }
        public bool? UspsVerified { get; set; }
        public DateTime? AddressVerifiedDate { get; set; }
        public DateTime? LastVerificationAttemptDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
}
