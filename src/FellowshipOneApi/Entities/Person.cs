using System;
using System.Collections.Generic;

namespace FellowshipOneApi.Entities
{
    public class Person
    {
        public bool? Array { get; set; }
        public long? Id { get; set; } 
        public string Uri { get; set; }
        public string ImageUri { get; set; }
        public long? OldId { get; set; }
        public string ICode { get; set; }
        public long? HouseholdId { get; set; }
        public long? OldHouseholdId { get; set; }

        public string Title { get; set; }
        public string Salutation { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string MiddleName { get; set; }
        public string GoesByName { get; set; }
        public string FormerName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        public HouseholdMemberType HouseholdMemberType { get; set; }
        public bool? IsAuthorized { get; set; }
        public Status Status { get; set; }
        public Occupation Occupation { get; set; }
        public string Employer { get; set; }
        public School School { get; set; }
        public Denomination Denomination { get; set; }
        public string FormerChurch { get; set; }
        public string BarCode { get; set; }
        public string MemberEnvelopeCode { get; set; }
        public string DefaultTagComment { get; set; }
        public Weblink Weblink { get; set; }
        public string Solicit { get; set; }
        public bool? Thank { get; set; }
        public DateTime? FirstRecord { get; set; }
        public List<Attribute> Attributes { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Communication> Communications { get; set; }
        public DateTime LastMatchDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
