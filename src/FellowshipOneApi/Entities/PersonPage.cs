using System.Collections.Generic;

namespace FellowshipOneApi.Entities
{
    public class PersonPage
    {
        public int Count { get; set; }
        public int PageNumber { get; set; }
        public int TotalRecords { get; set; }
        public int AdditionalPages { get; set; }
        public List<Person> PersonList { get; set; } 
    }
}
