using System;

namespace FellowshipOneApi.Entities
{
    public class LocationAddress
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string CarrierRoute { get; set; }
        public string DeliveryPoint { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime? CreatedDate { get; set; }
        public CreatedByPerson CreatedByPerson { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public LastUpdatedByPerson LastUpdatedByPerson { get; set; }
    }
}
