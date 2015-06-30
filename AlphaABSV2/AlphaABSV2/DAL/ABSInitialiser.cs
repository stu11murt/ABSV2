using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AlphaABSV2.Models;


namespace AlphaABSV2.DAL
{
    public class ABSInitialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<ABSContext>
    {
        protected override void Seed(ABSContext context)
        {
            var bookings = new List<BookingForm>
            {
                new BookingForm{BookingRef="Bref"+DateTime.Now.ToShortTimeString(), DateOfEvent=DateTime.Now, VenueID=1, OfficeRef=1, Purpose=1, Source=1, GroupOrganiserFName="Steve", GroupOrganiserLName="Rodgers", TelNo="07493664335", Email="steve@shield.com", PartyName="Avengers", GroupSize=12, StartTime=DateTime.Now.AddDays(3), EndTime=DateTime.Now.AddDays(3).AddHours(2), GroupOrganiser="Steve Rodgers", BookingStatus=1, Created=DateTime.Now  },
                new BookingForm{BookingRef="Bref"+DateTime.Now.ToShortTimeString(), DateOfEvent=DateTime.Now, VenueID=1, OfficeRef=2, Purpose=2, Source=3, GroupOrganiserFName="Tony", GroupOrganiserLName="Stark", TelNo="074934743292", Email="tony@shield.com", PartyName="Avengers2", GroupSize=22, StartTime=DateTime.Now.AddDays(4), EndTime=DateTime.Now.AddDays(4).AddHours(2), GroupOrganiser="Tony Stark", BookingStatus=2, Created=DateTime.Now  },
                new BookingForm{BookingRef="Bref"+DateTime.Now.ToShortTimeString(), DateOfEvent=DateTime.Now, VenueID=2, OfficeRef=3, Purpose=3, Source=1, GroupOrganiserFName="Bruce", GroupOrganiserLName="Banner", TelNo="07493111111", Email="bruce@shield.com", PartyName="Avengers3", GroupSize=8, StartTime=DateTime.Now.AddDays(3), EndTime=DateTime.Now.AddDays(3).AddHours(2), GroupOrganiser="Bruce Banner", BookingStatus=1, Created=DateTime.Now  },
                new BookingForm{BookingRef="Bref"+DateTime.Now.ToShortTimeString(), DateOfEvent=DateTime.Now, VenueID=1, OfficeRef=2, Purpose=1, Source=2, GroupOrganiserFName="Natasha", GroupOrganiserLName="Romanoff", TelNo="0749322222", Email="nat@shield.com", PartyName="Avengers4", GroupSize=9, StartTime=DateTime.Now.AddDays(3), EndTime=DateTime.Now.AddDays(6).AddHours(6), GroupOrganiser="Natasha Romanoff", BookingStatus=1, Created=DateTime.Now  },
                new BookingForm{BookingRef="Bref"+DateTime.Now.ToShortTimeString(), DateOfEvent=DateTime.Now, VenueID=3, OfficeRef=2, Purpose=2, Source=1, GroupOrganiserFName="Thor", GroupOrganiserLName="Thorson", TelNo="07493342343", Email="thor@shield.com", PartyName="Avengers5", GroupSize=14, StartTime=DateTime.Now.AddDays(3), EndTime=DateTime.Now.AddDays(8).AddHours(8), GroupOrganiser="Thor Thorsen", BookingStatus=1, Created=DateTime.Now  },
                new BookingForm{BookingRef="Bref"+DateTime.Now.ToShortTimeString(), DateOfEvent=DateTime.Now, VenueID=1, OfficeRef=1, Purpose=1, Source=3, GroupOrganiserFName="Clint", GroupOrganiserLName="Barton", TelNo="0749399999", Email="clint@shield.com", PartyName="Avengers6", GroupSize=15, StartTime=DateTime.Now.AddDays(3), EndTime=DateTime.Now.AddDays(9).AddHours(9), GroupOrganiser="Clint Barton", BookingStatus=1, Created=DateTime.Now  },
                new BookingForm{BookingRef="Bref"+DateTime.Now.ToShortTimeString(), DateOfEvent=DateTime.Now, VenueID=2, OfficeRef=1, Purpose=3, Source=1, GroupOrganiserFName="Nick", GroupOrganiserLName="Fury", TelNo="07493443322", Email="nick@shield.com", PartyName="Avengers7", GroupSize=18, StartTime=DateTime.Now.AddDays(3), EndTime=DateTime.Now.AddDays(4).AddHours(4), GroupOrganiser="Nick Fury", BookingStatus=1, Created=DateTime.Now  },
                new BookingForm{BookingRef="Bref"+DateTime.Now.ToShortTimeString(), DateOfEvent=DateTime.Now, VenueID=2, OfficeRef=3, Purpose=1, Source=2, GroupOrganiserFName="Phil", GroupOrganiserLName="Coulson", TelNo="07497543444", Email="phil@shield.com", PartyName="Avengers8", GroupSize=26, StartTime=DateTime.Now.AddDays(3), EndTime=DateTime.Now.AddDays(1).AddHours(1), GroupOrganiser="Phil Coulson", BookingStatus=1, Created=DateTime.Now  },
                new BookingForm{BookingRef="Bref"+DateTime.Now.ToShortTimeString(), DateOfEvent=DateTime.Now, VenueID=1, OfficeRef=1, Purpose=2, Source=1, GroupOrganiserFName="Maria", GroupOrganiserLName="Hill", TelNo="07493999876", Email="maria@shield.com", PartyName="Avengers9", GroupSize=14, StartTime=DateTime.Now.AddDays(3), EndTime=DateTime.Now.AddDays(7).AddHours(7), GroupOrganiser="Maria Hill", BookingStatus=1, Created=DateTime.Now  },
                new BookingForm{BookingRef="Bref"+DateTime.Now.ToShortTimeString(), DateOfEvent=DateTime.Now, VenueID=3, OfficeRef=3, Purpose=1, Source=3, GroupOrganiserFName="Scott", GroupOrganiserLName="Lang", TelNo="07493000001", Email="scott@shield.com", PartyName="Avengers10", GroupSize=15, StartTime=DateTime.Now.AddDays(3), EndTime=DateTime.Now.AddDays(3).AddHours(3), GroupOrganiser="Scott Lang", BookingStatus=1, Created=DateTime.Now  }
                
            };

            bookings.ForEach(s => context.Bookings.Add(s));
            context.SaveChanges();

            var eventParents = new List<EventParent>
            {
                new EventParent{EventName="Paintball"},
                new EventParent{EventName="LaserTag"},
                new EventParent{EventName="Airsoft"}
            };

            eventParents.ForEach(e => context.EventParents.Add(e));
            context.SaveChanges();

            var events = new List<Event>
            {
                new Event{EventType="Adult Package", Duration=TimeSpan.Parse("01:00:00"), EventCost=20, EventDeposit=10, EventParentID=1, MinNumber=1, MaxNumber=12, MultiSession=false, SessionNumber=1},
                new Event{EventType="Student Package", Duration=TimeSpan.Parse("02:00:00"), EventCost=15, EventDeposit=5, EventParentID=1, MinNumber=1, MaxNumber=20, MultiSession=false, SessionNumber=1},
                new Event{EventType="Corp Package", Duration=TimeSpan.Parse("01:00:00"), EventCost=30, EventDeposit=10, EventParentID=1, MinNumber=10, MaxNumber=40, MultiSession=false, SessionNumber=1},
                new Event{EventType="Space Aliens", Duration=TimeSpan.Parse("02:30:00"), EventCost=40, EventDeposit=10, EventParentID=2, MinNumber=1, MaxNumber=50, MultiSession=false, SessionNumber=1},
                new Event{EventType="War Scenario", Duration=TimeSpan.Parse("04:00:00"), EventCost=60, EventDeposit=20, EventParentID=1, MinNumber=1, MaxNumber=100, MultiSession=false, SessionNumber=1}
            
            };

            events.ForEach(ev => context.Events.Add(ev));
            context.SaveChanges();

            var venues = new List<Venue>
            {
                new Venue{VenueName="Base Camp"},
                new Venue{VenueName="Second Base"},
                new Venue{VenueName="Off Site"},
                new Venue{VenueName="Client Premises"},
                new Venue{VenueName="Other"}
            };

            venues.ForEach(v => context.Venues.Add(v));
            context.SaveChanges();

            var officeRefs = new List<OfficeRef>
            {
                new OfficeRef{OfficeRefPeople="Stu"},
                new OfficeRef{OfficeRefPeople="Sam"},
                new OfficeRef{OfficeRefPeople="Rich"},
                new OfficeRef{OfficeRefPeople="Dave"},
                new OfficeRef{OfficeRefPeople="Ronnie"}
            };

            officeRefs.ForEach(v => context.OfficeRefs.Add(v));
            context.SaveChanges();


            var purposes = new List<Purpose>
            {
                new Purpose{PurposeOfEvent="Hen Do"},
                new Purpose{PurposeOfEvent="Stag Do"},
                new Purpose{PurposeOfEvent="Birthday"},
                new Purpose{PurposeOfEvent="Work Event"},
                new Purpose{PurposeOfEvent="Other"}
            };

            purposes.ForEach(p => context.Purposes.Add(p));
            context.SaveChanges();


            var sources = new List<Source>
            {
                new Source{SourceName="Google"},
                new Source{SourceName="Yahoo"},
                new Source{SourceName="Other Search"},
                new Source{SourceName="Magazine"},
                new Source{SourceName="Newspaper"},
                new Source{SourceName="Recommendation"},
                new Source{SourceName="Other"}
            };

            sources.ForEach(sc => context.Sources.Add(sc));
            context.SaveChanges();


            var bookingstats = new List<BookingStatus>
            {
                new BookingStatus{BookingStatusText="Provisional"},
                new BookingStatus{BookingStatusText="Confirmed"},
                new BookingStatus{BookingStatusText="Postponed"},
                new BookingStatus{BookingStatusText="Cancelled"}
            };

            bookingstats.ForEach(b => context.BookingStatuses.Add(b));
            context.SaveChanges();
        }
    }
}