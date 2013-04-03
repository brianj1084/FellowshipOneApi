using System;

namespace FellowshipOneApi.Entities
{
    public class Group
    {
        public bool? Array { get; set; }
        public long? Id { get; set; }
        public string Uri { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? IsOpen { get; set; }
        public bool? IsPublic { get; set; }
        public bool? HasChildcare { get; set; }
        public bool? IsSearchable { get; set; }
        public ChurchCampus ChurchCampus { get; set; }
        public GroupType GroupType { get; set; }
        public string GroupUrl { get; set; }
        public TimeZone TimeZone { get; set; }
        public Gender Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string StartAgeRange { get; set; }
        public string EndAgeRange { get; set; }
        public DateRangeType DateRangeType { get; set; }
        public long? LeadersCount { get; set; }
        public long? MembersCount { get; set; }
        public long? OpenProspectsCount { get; set; }
        public Event Event { get; set; }
        public Location Location { get; set; }
        public DateTime? CreatedDate { get; set; }
        public CreatedByPerson CreatedByPerson { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public LastUpdatedByPerson LastUpdatedByPerson { get; set; }
    }
}
