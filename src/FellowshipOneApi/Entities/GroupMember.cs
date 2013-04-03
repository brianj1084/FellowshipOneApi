using System;

namespace FellowshipOneApi.Entities
{
    public class GroupMember
    {
        public bool? Array { get; set; }
        public long? Id { get; set; }
        public string Uri { get; set; }

        public GroupMemberGroup Group { get; set; }
        public GroupMemberPerson Person { get; set; }
        public GroupMemberType MemberType { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }

        public CreatedByPerson CreatedByPerson { get; set; }
        public LastUpdatedByPerson LastUpdatedByPerson { get; set; }
    }
}
