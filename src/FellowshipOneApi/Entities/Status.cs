using System;

namespace FellowshipOneApi.Entities
{
    public class Status
    {
        public long? Id { get; set; }
        public string Uri { get; set; }

        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public SubStatus SubStatus { get; set; }
    }
}
