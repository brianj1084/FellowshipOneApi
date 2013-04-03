using System;

namespace FellowshipOneApi.Entities
{
    public class Location
    {
        public long? Id { get; set; }
        public string Uri { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsOnline { get; set; }
        public string Url { get; set; }
        public LocationAddress LocationAddress { get; set; }
        public DateTime? CreatedDate { get; set; }
        public CreatedByPerson CreatedByPerson { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public LastUpdatedByPerson LastUpdatedByPerson { get; set; }
    }
}
