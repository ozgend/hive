using Denolk.XchangeWrapper.Helper;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denolk.XchangeWrapper.Model
{
    public class Event
    {
        public Event(Appointment a)
        {
            this.Title = a.Subject;
            this.Description = a.Body.Text;
            this.Location = a.Location;
            this.Start = a.Start;
            this.End = a.End;
            this.Type = a.GetType().Name;
            this.Invited = GetPersons(a);
            this.MyResponse = a.MyResponseType.ToString();
            this.Id = a.Id.UniqueId;
            this.ResponseRequired = a.MyResponseType == MeetingResponseType.NoResponseReceived;
        }

        public Event(MeetingRequest m)
        {
            this.Title = m.Subject;
            this.Description = m.Body.Text;
            this.Location = m.Location;
            this.Start = m.Start;
            this.End = m.End;
            this.Type = m.GetType().Name;
            this.Invited = GetPersons(m);
            this.MyResponse = m.MyResponseType.ToString();
            this.Id = m.Id.UniqueId;
            this.ResponseRequired = m.MyResponseType == MeetingResponseType.NoResponseReceived;
        }

        public Event(CalendarEvent c)
        {
            this.Title = c.Details.Subject;
            this.Description = c.Details.Subject;
            this.Location = c.Details.Location;
            this.Type = c.GetType().Name;
            this.Start = c.StartTime;
            this.End = c.EndTime;
            this.Id = c.Details.StoreId;
            this.ResponseRequired = false;
        }

        public Event() { }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<Person> Invited { get; set; }
        public string Type { get; set; }
        public string MyResponse { get; set; }
        public bool ResponseRequired { get; set; }

        public string StartStringLong { get { return DataHelper.FormatDateLong(this.Start); } }
        public string EndStringLong { get { return DataHelper.FormatDateLong(this.End); } }
        public string StartStringFull { get { return DataHelper.FormatDateFull(this.Start); } }
        public string EndStringFull { get { return DataHelper.FormatDateFull(this.End); } }
        public string StartStringISO { get { return DataHelper.FormatDateISO(this.Start); } }
        public string EndStringISO { get { return DataHelper.FormatDateISO(this.End); } }
        public int Duration { get { return (int)TimeSpan.FromTicks(this.End.Subtract(this.Start).Ticks).TotalSeconds; } }
        public bool IsPast { get { return (this.End.CompareTo(DateTime.Now) < 0); } }


        private List<Person> GetPersons(Appointment a)
        {
            List<Person> list = new List<Person>();
            List<Attendee> all = new List<Attendee>(a.RequiredAttendees);
            all.AddRange(a.OptionalAttendees);
            foreach (Attendee at in all)
            {
                list.Add(new Person(at));
            }
            return list;
        }

        private List<Person> GetPersons(MeetingRequest m)
        {
            List<Person> list = new List<Person>();
            List<Attendee> all = new List<Attendee>(m.RequiredAttendees);
            all.AddRange(m.OptionalAttendees);
            foreach (Attendee at in all)
            {
                list.Add(new Person(at));
            }
            return list;
        }




    }
}
