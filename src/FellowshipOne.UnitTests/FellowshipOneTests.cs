﻿using System;
using System.Collections.Generic;
using FellowshipOneApi;
using Moq;
using NUnit.Framework;

namespace FellowshipOne.UnitTests
{
    [TestFixture]
    public class FellowshipOneTests
    {
        [Test]
        public void ParsePersonTest()
        {
            var fOneClientMock = new Mock<IFellowshipOneClient>();

            fOneClientMock.Setup(f => f.BaseUrl).Returns("https://madgravity.staging.fellowshiponeapi.com");
            fOneClientMock.Setup(f => f.RequestToken).Returns("12345");
            fOneClientMock.Setup(f => f.TokenSecret).Returns("12345");

            var fOneClient = fOneClientMock.Object;

            var requestUrl = fOneClient.BaseUrl + FellowshipOneConfig.F1PeopleSearch + "?lastUpdatedDate=1900-01-01&page=1";
            fOneClientMock.Setup(f => f.Request(requestUrl, new Dictionary<string, string>())).Returns("<?xml version=\"1.0\" encoding=\"utf-8\"?><results count=\"5\" pageNumber=\"1\" totalRecords=\"5\" additionalPages=\"0\">  <person array=\"true\" id=\"38900459\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/People/38900459\" imageURI=\"\" oldID=\"\" iCode=\"Gqb9CEjMnYEPe+VPqnVmNw==\" householdID=\"23900746\" oldHouseholdID=\"\">    <title></title>    <salutation></salutation>    <prefix></prefix>    <firstName>Brian</firstName>    <lastName>Jones</lastName>    <suffix></suffix>    <middleName></middleName>    <goesByName></goesByName>    <formerName></formerName>    <gender>Male</gender>    <dateOfBirth>1984-10-01T00:00:00</dateOfBirth>    <maritalStatus>Married</maritalStatus>    <householdMemberType id=\"1\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/People/HouseholdMemberTypes/1\">      <name>Head</name>    </householdMemberType>    <isAuthorized>true</isAuthorized>    <status id=\"4\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/People/Statuses/4\">      <name>Attendee</name>      <comment></comment>      <date>1994-09-18T00:00:00</date>      <subStatus id=\"\" uri=\"\">        <name></name>      </subStatus>    </status>    <occupation id=\"\" uri=\"\">      <name></name>      <description></description>    </occupation>    <employer></employer>    <school id=\"\" uri=\"\">      <name></name>    </school>    <denomination id=\"\" uri=\"\">      <name></name>    </denomination>    <formerChurch></formerChurch>    <barCode></barCode>    <memberEnvelopeCode></memberEnvelopeCode>    <defaultTagComment></defaultTagComment>    <weblink>      <userID></userID>      <passwordHint></passwordHint>      <passwordAnswer></passwordAnswer>    </weblink>    <solicit></solicit>    <thank>true</thank>    <firstRecord>2011-10-25T09:34:20</firstRecord>    <attributes />    <addresses />    <communications>      <communication array=\"true\" id=\"40822866\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/40822866\">        <household id=\"23900746\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Households/23900746\" />        <person id=\"\" uri=\"\" />        <communicationType id=\"1\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/CommunicationTypes/1\">          <name>Home Phone</name>        </communicationType>        <communicationGeneralType>Telephone</communicationGeneralType>        <communicationValue>4237809339</communicationValue>        <searchCommunicationValue>4237809339</searchCommunicationValue>        <listed>true</listed>        <communicationComment></communicationComment>        <createdDate>2011-10-25T09:34:21</createdDate>        <lastUpdatedDate>2011-10-25T09:34:21</lastUpdatedDate>      </communication>      <communication array=\"true\" id=\"40822920\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/40822920\">        <household id=\"23900746\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Households/23900746\" />        <person id=\"38900459\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/People/38900459\" />        <communicationType id=\"4\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/CommunicationTypes/4\">          <name>Email</name>        </communicationType>        <communicationGeneralType>Email</communicationGeneralType>        <communicationValue>bjones03@gmail.com</communicationValue>        <searchCommunicationValue>bjones03@gmail.com</searchCommunicationValue>        <listed>true</listed>        <communicationComment> </communicationComment>        <createdDate>2011-10-31T10:52:31</createdDate>        <lastUpdatedDate>2011-10-31T10:52:31</lastUpdatedDate>      </communication>    </communications>    <lastMatchDate></lastMatchDate>    <createdDate>2011-10-25T09:34:20</createdDate>    <lastUpdatedDate>2011-10-25T09:34:20</lastUpdatedDate>  </person>  <person array=\"true\" id=\"38900440\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/People/38900440\" imageURI=\"\" oldID=\"23260045\" iCode=\"vsbtDJCuhxTTJPLlW2lkYA==\" householdID=\"23900734\" oldHouseholdID=\"15023395\">    <title></title>    <salutation></salutation>    <prefix></prefix>    <firstName>Jacob</firstName>    <lastName>Angel</lastName>    <suffix></suffix>    <middleName></middleName>    <goesByName>Jake</goesByName>    <formerName></formerName>    <gender>Male</gender>    <dateOfBirth>1996-05-22T00:00:00</dateOfBirth>    <maritalStatus>Child/Yth</maritalStatus>    <householdMemberType id=\"3\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/People/HouseholdMemberTypes/3\">      <name>Child</name>    </householdMemberType>    <isAuthorized>true</isAuthorized>    <status id=\"3\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/People/Statuses/3\">      <name>Child of Member</name>      <comment></comment>      <date>2008-11-01T00:00:00</date>      <subStatus id=\"\" uri=\"\">        <name></name>      </subStatus>    </status>    <occupation id=\"\" uri=\"\">      <name></name>      <description></description>    </occupation>    <employer></employer>    <school id=\"\" uri=\"\">      <name></name>    </school>    <denomination id=\"\" uri=\"\">      <name></name>    </denomination>    <formerChurch></formerChurch>    <barCode></barCode>    <memberEnvelopeCode></memberEnvelopeCode>    <defaultTagComment></defaultTagComment>    <weblink>      <userID></userID>      <passwordHint></passwordHint>      <passwordAnswer></passwordAnswer>    </weblink>    <solicit></solicit>    <thank>true</thank>    <firstRecord>2009-01-30T09:37:22</firstRecord>    <attributes />    <addresses />    <communications>      <communication array=\"true\" id=\"40822819\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/40822819\">        <household id=\"23900734\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Households/23900734\" />        <person id=\"\" uri=\"\" />        <communicationType id=\"1\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/CommunicationTypes/1\">          <name>Home Phone</name>        </communicationType>        <communicationGeneralType>Telephone</communicationGeneralType>        <communicationValue>469-442-0100</communicationValue>        <searchCommunicationValue>4694420100</searchCommunicationValue>        <listed>true</listed>        <communicationComment></communicationComment>        <createdDate>2011-10-20T18:02:19</createdDate>        <lastUpdatedDate>2009-01-30T09:37:22</lastUpdatedDate>      </communication>      <communication array=\"true\" id=\"40822818\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/40822818\">        <household id=\"23900734\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Households/23900734\" />        <person id=\"\" uri=\"\" />        <communicationType id=\"4\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/CommunicationTypes/4\">          <name>Email</name>        </communicationType>        <communicationGeneralType>Email</communicationGeneralType>        <communicationValue>sales@fellowshiptech.com</communicationValue>        <searchCommunicationValue>sales@fellowshiptech.com</searchCommunicationValue>        <listed>true</listed>        <communicationComment></communicationComment>        <createdDate>2011-10-20T18:02:19</createdDate>        <lastUpdatedDate>2009-01-30T16:10:00</lastUpdatedDate>      </communication>    </communications>    <lastMatchDate></lastMatchDate>    <createdDate>2011-10-20T18:02:18</createdDate>    <lastUpdatedDate>2009-01-30T10:57:38</lastUpdatedDate>  </person>  <person array=\"true\" id=\"38900438\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/People/38900438\" imageURI=\"\" oldID=\"23260043\" iCode=\"PPFK9qZrnUOkl388RIXlcQ==\" householdID=\"23900734\" oldHouseholdID=\"15023395\">    <title></title>    <salutation></salutation>    <prefix></prefix>    <firstName>John</firstName>    <lastName>Angel</lastName>    <suffix></suffix>    <middleName></middleName>    <goesByName></goesByName>    <formerName></formerName>    <gender>Male</gender>    <dateOfBirth>1968-08-12T00:00:00</dateOfBirth>    <maritalStatus>Married</maritalStatus>    <householdMemberType id=\"1\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/People/HouseholdMemberTypes/1\">      <name>Head</name>    </householdMemberType>    <isAuthorized>true</isAuthorized>    <status id=\"1\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/People/Statuses/1\">      <name>Member</name>      <comment></comment>      <date>2008-11-01T00:00:00</date>      <subStatus id=\"\" uri=\"\">        <name></name>      </subStatus>    </status>    <occupation id=\"21\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/People/Occupations/21\">      <name>Accounting</name>      <description></description>    </occupation>    <employer>H&amp;R Block</employer>    <school id=\"\" uri=\"\">      <name></name>    </school>    <denomination id=\"\" uri=\"\">      <name></name>    </denomination>    <formerChurch>1st Church of God</formerChurch>    <barCode></barCode>    <memberEnvelopeCode></memberEnvelopeCode>    <defaultTagComment></defaultTagComment>    <weblink>      <userID></userID>      <passwordHint></passwordHint>      <passwordAnswer></passwordAnswer>    </weblink>    <solicit></solicit>    <thank>true</thank>    <firstRecord>2009-01-30T09:37:22</firstRecord>    <attributes />    <addresses />    <communications>      <communication array=\"true\" id=\"40822819\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/40822819\">        <household id=\"23900734\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Households/23900734\" />        <person id=\"\" uri=\"\" />        <communicationType id=\"1\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/CommunicationTypes/1\">          <name>Home Phone</name>        </communicationType>        <communicationGeneralType>Telephone</communicationGeneralType>        <communicationValue>469-442-0100</communicationValue>        <searchCommunicationValue>4694420100</searchCommunicationValue>        <listed>true</listed>        <communicationComment></communicationComment>        <createdDate>2011-10-20T18:02:19</createdDate>        <lastUpdatedDate>2009-01-30T09:37:22</lastUpdatedDate>      </communication>      <communication array=\"true\" id=\"40822818\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/40822818\">        <household id=\"23900734\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Households/23900734\" />        <person id=\"\" uri=\"\" />        <communicationType id=\"4\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/CommunicationTypes/4\">          <name>Email</name>        </communicationType>        <communicationGeneralType>Email</communicationGeneralType>        <communicationValue>sales@fellowshiptech.com</communicationValue>        <searchCommunicationValue>sales@fellowshiptech.com</searchCommunicationValue>        <listed>true</listed>        <communicationComment></communicationComment>        <createdDate>2011-10-20T18:02:19</createdDate>        <lastUpdatedDate>2009-01-30T16:10:00</lastUpdatedDate>      </communication>    </communications>    <lastMatchDate></lastMatchDate>    <createdDate>2011-10-20T18:02:18</createdDate>    <lastUpdatedDate>2009-01-30T14:15:46</lastUpdatedDate>  </person>  <person array=\"true\" id=\"38900439\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/People/38900439\" imageURI=\"\" oldID=\"23260046\" iCode=\"9KUqklHOXmEVREgKJpBdsg==\" householdID=\"23900734\" oldHouseholdID=\"15023395\">    <title></title>    <salutation></salutation>    <prefix></prefix>    <firstName>Michael</firstName>    <lastName>Angel</lastName>    <suffix></suffix>    <middleName></middleName>    <goesByName></goesByName>    <formerName></formerName>    <gender>Male</gender>    <dateOfBirth>2000-04-07T00:00:00</dateOfBirth>    <maritalStatus>Child/Yth</maritalStatus>    <householdMemberType id=\"3\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/People/HouseholdMemberTypes/3\">      <name>Child</name>    </householdMemberType>    <isAuthorized>true</isAuthorized>    <status id=\"3\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/People/Statuses/3\">      <name>Child of Member</name>      <comment></comment>      <date>2008-11-01T00:00:00</date>      <subStatus id=\"\" uri=\"\">        <name></name>      </subStatus>    </status>    <occupation id=\"\" uri=\"\">      <name></name>      <description></description>    </occupation>    <employer></employer>    <school id=\"\" uri=\"\">      <name></name>    </school>    <denomination id=\"\" uri=\"\">      <name></name>    </denomination>    <formerChurch></formerChurch>    <barCode></barCode>    <memberEnvelopeCode></memberEnvelopeCode>    <defaultTagComment></defaultTagComment>    <weblink>      <userID></userID>      <passwordHint></passwordHint>      <passwordAnswer></passwordAnswer>    </weblink>    <solicit></solicit>    <thank>true</thank>    <firstRecord>2009-01-30T09:37:22</firstRecord>    <attributes />    <addresses />    <communications>      <communication array=\"true\" id=\"40822819\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/40822819\">        <household id=\"23900734\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Households/23900734\" />        <person id=\"\" uri=\"\" />        <communicationType id=\"1\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/CommunicationTypes/1\">          <name>Home Phone</name>        </communicationType>        <communicationGeneralType>Telephone</communicationGeneralType>        <communicationValue>469-442-0100</communicationValue>        <searchCommunicationValue>4694420100</searchCommunicationValue>        <listed>true</listed>        <communicationComment></communicationComment>        <createdDate>2011-10-20T18:02:19</createdDate>        <lastUpdatedDate>2009-01-30T09:37:22</lastUpdatedDate>      </communication>      <communication array=\"true\" id=\"40822818\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/40822818\">        <household id=\"23900734\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Households/23900734\" />        <person id=\"\" uri=\"\" />        <communicationType id=\"4\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/CommunicationTypes/4\">          <name>Email</name>        </communicationType>        <communicationGeneralType>Email</communicationGeneralType>        <communicationValue>sales@fellowshiptech.com</communicationValue>        <searchCommunicationValue>sales@fellowshiptech.com</searchCommunicationValue>        <listed>true</listed>        <communicationComment></communicationComment>        <createdDate>2011-10-20T18:02:19</createdDate>        <lastUpdatedDate>2009-01-30T16:10:00</lastUpdatedDate>      </communication>    </communications>    <lastMatchDate></lastMatchDate>    <createdDate>2011-10-20T18:02:18</createdDate>    <lastUpdatedDate>2009-01-30T09:48:19</lastUpdatedDate>  </person>  <person array=\"true\" id=\"38900437\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/People/38900437\" imageURI=\"\" oldID=\"23260044\" iCode=\"b3CEJBqGgq46PvyEWbDVlQ==\" householdID=\"23900734\" oldHouseholdID=\"15023395\">    <title></title>    <salutation></salutation>    <prefix></prefix>    <firstName>Patricia</firstName>    <lastName>Angel</lastName>    <suffix></suffix>    <middleName></middleName>    <goesByName>Patty</goesByName>    <formerName></formerName>    <gender>Female</gender>    <dateOfBirth>1969-11-16T00:00:00</dateOfBirth>    <maritalStatus>Married</maritalStatus>    <householdMemberType id=\"2\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/People/HouseholdMemberTypes/2\">      <name>Spouse</name>    </householdMemberType>    <isAuthorized>true</isAuthorized>    <status id=\"1\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/People/Statuses/1\">      <name>Member</name>      <comment></comment>      <date>2008-11-01T00:00:00</date>      <subStatus id=\"\" uri=\"\">        <name></name>      </subStatus>    </status>    <occupation id=\"25\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/People/Occupations/25\">      <name>Homemaker</name>      <description></description>    </occupation>    <employer></employer>    <school id=\"\" uri=\"\">      <name></name>    </school>    <denomination id=\"\" uri=\"\">      <name></name>    </denomination>    <formerChurch>1st Church of God</formerChurch>    <barCode></barCode>    <memberEnvelopeCode></memberEnvelopeCode>    <defaultTagComment></defaultTagComment>    <weblink>      <userID></userID>      <passwordHint></passwordHint>      <passwordAnswer></passwordAnswer>    </weblink>    <solicit></solicit>    <thank>true</thank>    <firstRecord>2009-01-30T09:37:22</firstRecord>    <attributes />    <addresses />    <communications>      <communication array=\"true\" id=\"40822819\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/40822819\">        <household id=\"23900734\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Households/23900734\" />        <person id=\"\" uri=\"\" />        <communicationType id=\"1\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/CommunicationTypes/1\">          <name>Home Phone</name>        </communicationType>        <communicationGeneralType>Telephone</communicationGeneralType>        <communicationValue>469-442-0100</communicationValue>        <searchCommunicationValue>4694420100</searchCommunicationValue>        <listed>true</listed>        <communicationComment></communicationComment>        <createdDate>2011-10-20T18:02:19</createdDate>        <lastUpdatedDate>2009-01-30T09:37:22</lastUpdatedDate>      </communication>      <communication array=\"true\" id=\"40822818\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/40822818\">        <household id=\"23900734\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Households/23900734\" />        <person id=\"\" uri=\"\" />        <communicationType id=\"4\" uri=\"https://madgravity.staging.fellowshiponeapi.com/v1/Communications/CommunicationTypes/4\">          <name>Email</name>        </communicationType>        <communicationGeneralType>Email</communicationGeneralType>        <communicationValue>sales@fellowshiptech.com</communicationValue>        <searchCommunicationValue>sales@fellowshiptech.com</searchCommunicationValue>        <listed>true</listed>        <communicationComment></communicationComment>        <createdDate>2011-10-20T18:02:19</createdDate>        <lastUpdatedDate>2009-01-30T16:10:00</lastUpdatedDate>      </communication>    </communications>    <lastMatchDate></lastMatchDate>    <createdDate>2011-10-20T18:02:18</createdDate>    <lastUpdatedDate>2009-01-30T14:15:13</lastUpdatedDate>  </person></results>");

            var personService = new PersonService(fOneClient);

            var personPage = personService.GetPersonPage();

            Assert.That(personPage.Count, Is.EqualTo(5));
            Assert.That(personPage.PageNumber, Is.EqualTo(1));
            Assert.That(personPage.TotalRecords, Is.EqualTo(5));
            Assert.That(personPage.AdditionalPages, Is.EqualTo(0));

            Assert.That(personPage.PersonList.Count, Is.EqualTo(5));
            Assert.That(personPage.PersonList[0].Communications.Count, Is.EqualTo(2));
            Assert.That(personPage.PersonList[0].Communications[0].CommunicationValue, Is.EqualTo("4237809339"));
            Assert.That(personPage.PersonList[0].Communications[1].CommunicationValue, Is.EqualTo("bjones03@gmail.com"));

        }

        [Test]
        public void ParseGroupMemberTest()
        {
            var fOneClientMock = new Mock<IFellowshipOneClient>();

            fOneClientMock.Setup(f => f.BaseUrl).Returns("https://madgravity.staging.fellowshiponeapi.com");
            fOneClientMock.Setup(f => f.RequestToken).Returns("12345");
            fOneClientMock.Setup(f => f.TokenSecret).Returns("12345");

            var fOneClient = fOneClientMock.Object;

            var requestUrl = fOneClient.BaseUrl + string.Format(FellowshipOneConfig.F1GroupMembers, 235812) + string.Format("?page={0}", 1); ;
            fOneClientMock.Setup(f => f.Request(requestUrl, new Dictionary<string, string>())).Returns("<?xml version=\"1.0\" encoding=\"utf-8\"?> <members count=\"2\" pageNumber=\"1\" totalRecords=\"2\" additionalPages=\"0\"> <member array=\"true\" id=\"649\" uri=\"https://demo.fellowshiponeapi.com/groups/v1/groups/235812/members/649\"> <group id=\"235812\" uri=\"https://demo.fellowshiponeapi.com/groups/v1/groups/235812\"> <name>Test</name> </group> <person id=\"13745947\" uri=\"{{CONSUMER_ROOT_DOMAIN}}/people/13745947\"> <name>Jeff Coulson</name> </person> <membertype id=\"2\" uri=\"https://demo.fellowshiponeapi.com/groups/v1/membertypes/2\"> <name>Member</name> </membertype> <createdDate>2007-11-14T14:29:20</createdDate> <createdByPerson id=\"1999191\" uri=\"{{CONSUMER_ROOT_DOMAIN}}/people/1999191\" /> <lastUpdatedDate></lastUpdatedDate> <lastUpdatedByPerson id=\"\" uri=\"\" /> </member> <member array=\"true\" id=\"648\" uri=\"https://demo.fellowshiponeapi.com/groups/v1/groups/235812/members/648\"> <person id=\"1632378\" uri=\"{{CONSUMER_ROOT_DOMAIN}}/people/1632378\"> <name>Jeff Hook</name> </person> </member> </members>");

            var groupService = new GroupService(fOneClient);

            var groupMemberPage = groupService.GetGroupMemberPageForGroup(235812);

            Assert.That(groupMemberPage.Count, Is.EqualTo(2));
            Assert.That(groupMemberPage.PageNumber, Is.EqualTo(1));
            Assert.That(groupMemberPage.TotalRecords, Is.EqualTo(2));
            Assert.That(groupMemberPage.AdditionalPages, Is.EqualTo(0));

            Assert.That(groupMemberPage.GroupMemberList.Count, Is.EqualTo(2));
            Assert.That(groupMemberPage.GroupMemberList[0].Id, Is.EqualTo(649));
            Assert.That(groupMemberPage.GroupMemberList[0].Group.Id, Is.EqualTo(235812));
            Assert.That(groupMemberPage.GroupMemberList[0].Group.Name, Is.EqualTo("Test"));
            Assert.That(groupMemberPage.GroupMemberList[0].Person.Id, Is.EqualTo(13745947));
            Assert.That(groupMemberPage.GroupMemberList[0].Person.Name, Is.EqualTo("Jeff Coulson"));
            Assert.That(groupMemberPage.GroupMemberList[0].MemberType.Id, Is.EqualTo(2));
            Assert.That(groupMemberPage.GroupMemberList[0].MemberType.Name, Is.EqualTo("Member"));
            Assert.That(groupMemberPage.GroupMemberList[0].CreatedDate, Is.EqualTo(new DateTime(2007, 11, 14, 14, 29, 20)));
            Assert.That(groupMemberPage.GroupMemberList[0].CreatedByPerson.Id, Is.EqualTo(1999191));
        }
    }
}