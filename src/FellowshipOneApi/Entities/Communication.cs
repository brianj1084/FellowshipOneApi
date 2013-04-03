using System;

namespace FellowshipOneApi.Entities
{
    public class Communication
    {
        public bool? Array { get; set; }
        public long? Id { get; set; }
        public string Uri { get; set; }

        public CommunicationType CommunicationType { get; set; }
        public string CommunicationGeneralType { get; set; }
        public string CommunicationValue { get; set; }
        public string SearchCommunicationValue { get; set; }
        public bool? Listed { get; set; }
        public string CommunicationComment { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
}
