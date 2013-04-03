using System;

namespace FellowshipOneApi.Entities
{
    public class Attribute
    {
        public bool? Array { get; set; }
        public long? Id { get; set; }
        public string Uri { get; set; }

        public AttributeGroup AttributeGroup { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Comment { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
}
