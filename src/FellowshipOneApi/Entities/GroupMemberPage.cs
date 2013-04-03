using System.Collections.Generic;

namespace FellowshipOneApi.Entities
{
    public class GroupMemberPage
    {
        public int Count { get; set; }
        public int PageNumber { get; set; }
        public int TotalRecords { get; set; }
        public int AdditionalPages { get; set; }
        public List<GroupMember> GroupMemberList { get; set; } 
    }
}
