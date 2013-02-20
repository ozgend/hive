using Denolk.XchangeWrapper.Exceptions;
using Denolk.XchangeWrapper.Helper;
using Denolk.XchangeWrapper.Model;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Denolk.XchangeWrapper
{
    public class XService
    {

        struct XView
        {
            public static ItemView CalendarView { get { return new ItemView(100); } }
            public static CalendarView AppoinmentView { get { return new CalendarView(DateTime.Now.AddYears(-1), DateTime.Now.AddYears(1)); } }
            public static ItemView PersonView { get { return new ItemView(100); } }
            public static ItemView InboxView { get { return new ItemView(50); } }
        }

        struct XProp
        {
            public static string HostURL { get { return ConfigHelper.XChangeHost; } }
            public static ExchangeVersion Version { get { return ExchangeVersion.Exchange2010_SP1; } }
        }

        struct XFolder
        {
            public static WellKnownFolderName Contacts { get { return WellKnownFolderName.Contacts; } }
            public static WellKnownFolderName Calendar { get { return WellKnownFolderName.Calendar; } }
            public static WellKnownFolderName Tasks { get { return WellKnownFolderName.Tasks; } }
            public static WellKnownFolderName Sent { get { return WellKnownFolderName.SentItems; } }
        }

        private ExchangeService service;
        private static XService instance;

        private XService(string username, string password)
        {
            CreateConnection(username,password);
        }

        public static XService Init(string username, string password)
        {
            if (instance == null)
            {
                instance = new XService(username, password);
            }
            return instance ;
        }

        private void CreateConnection(string username, string password)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate(Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) { return true; };

            service = new ExchangeService(XProp.Version);
            service.Url = new Uri(XProp.HostURL);
            service.Credentials = new WebCredentials(username, password);

        }

        public void CreateAndSaveMeeting(Meeting m)
        {
            try
            {
                Appointment a = new Appointment(service);
                a.Subject = m.Title;
                a.Body = m.Description;
                a.Start = DataHelper.StringToDate(m.Start, DataHelper.DateStringLong);
                a.End = DataHelper.StringToDate(m.End, DataHelper.DateStringLong);
                a.Location = m.Location;
                foreach (string email in m.Invited)
                {
                    a.RequiredAttendees.Add(email);
                }
                a.Save(SendInvitationsMode.SendToAllAndSaveCopy);
            }
            catch (Exception e)
            {
                throw new ServiceException("Cannot create meeting", e);
            }
        }

        public List<Person> GetAddressBook()
        {
            try
            {
                FindItemsResults<Item> items = service.FindItems(XFolder.Contacts, XView.PersonView);
                List<Person> contacts = new List<Person>();
                foreach (Item i in items)
                {
                    if (i is Contact)
                    {
                        contacts.Add(new Person(i as Contact));
                    }
                }
                contacts.Sort(delegate(Person p1, Person p2)
                {
                    return p1.DisplayName.CompareTo(p2.DisplayName);
                });
                return contacts;
            }
            catch (Exception e)
            {
                throw new ServiceException("Cannot get contact list", e);
            }
        }

        public List<Event> GetEventList()
        {
            try
            {
                List<Item> list = service.FindItems(XFolder.Calendar, XView.CalendarView).ToList();
                service.LoadPropertiesForItems(list, PropertySet.FirstClassProperties);
                List<Event> events = new List<Event>();

                foreach (Item item in list)
                {
                    if (item is MeetingRequest)
                    {
                        events.Add(new Event(item as MeetingRequest));
                    }
                    else if (item is Appointment)
                    {
                        events.Add(new Event(item as Appointment));
                    }
                }

                events.Sort(delegate(Event e1, Event e2)
                {
                    return e2.Start.CompareTo(e1.Start);
                });


                return events;
            }
            catch (Exception e)
            {
                throw new ServiceException("Cannot get event list", e);
            }
        }

        public object GetCalendarList(string email)
        {
            FindItemsResults<Item> list = service.FindItems(WellKnownFolderName.Calendar, email, XView.CalendarView);
            service.LoadPropertiesForItems(list, PropertySet.FirstClassProperties);
            return list;
        }

        public void ApproveMeetingRequest(string id)
        {
            MeetingRequest r = MeetingRequest.Bind(service, new ItemId(id));
            r.IsRead = true;
            r.CreateAcceptMessage(false).SendAndSaveCopy(XFolder.Sent);
        }

        public void RejectMeetingRequest(string id)
        {
            MeetingRequest r = MeetingRequest.Bind(service, new ItemId(id));
            r.IsRead = true;
            r.CreateDeclineMessage().SendAndSaveCopy(XFolder.Sent);
        }

    }
}
