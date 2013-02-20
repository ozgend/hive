using Denolk.XchangeViewer.Models;
using Denolk.XchangeWrapper;
using Denolk.XchangeWrapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Denolk.XchangeViewer.Business
{
    public class XChangeBusiness
    {

        public XChangeBusiness()
        {

        }

        private XService _service {
            get {
                return XChangeApplication.Service;
            }
        }


        public void SendMeeting(Meeting m)
        {
            _service.CreateAndSaveMeeting(m);
        }

        public List<Person> GetContactList()
        {
            return _service.GetAddressBook();
        }

        internal object GetEventList()
        {
            return _service.GetEventList();
        }

        internal void RejectMeetingRequest(string id)
        {
            _service.RejectMeetingRequest(id);
        }

        internal void CreateAndSaveMeeting(Meeting meeting)
        {
            _service.CreateAndSaveMeeting(meeting);
        }

        internal void ApproveMeetingRequest(string id)
        {
            _service.ApproveMeetingRequest(id);
        }
    }
}