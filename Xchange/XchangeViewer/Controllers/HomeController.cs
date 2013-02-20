using Denolk.XchangeViewer.Business;
using Denolk.XchangeViewer.Filters;
using Denolk.XchangeWrapper;
using Denolk.XchangeWrapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Denolk.XchangeViewer.Controllers
{
    [AuthenticationRequired]
    [XChangeErrorHandler]
    public class HomeController : Controller
    {

        private XChangeBusiness _bus = new XChangeBusiness();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            return View("Calendar");
        }

        public ActionResult Contacts()
        {
            return View("Contacts");
        }

        [HttpPost]
        public ActionResult SendMeeting(Meeting meeting)
        {
            _bus.CreateAndSaveMeeting(meeting);
            return Json(new { ok = true });
        }

        [HttpPost]
        public ActionResult ApproveMeeting(Meeting meeting)
        {
            _bus.ApproveMeetingRequest(meeting.Id);
            return Json(new { ok = true });
        }

        [HttpPost]
        public ActionResult DeclineMeeting(Meeting meeting)
        {
            _bus.RejectMeetingRequest(meeting.Id);
            return Json(new { ok = true });
        }

        [HttpPost]
        public ActionResult GetEventList()
        {
            var events = _bus.GetEventList();
            return Json(new { ok = true, EventList = events });
        }

        [HttpPost]
        public ActionResult GetContactList()
        {
            var contacts = _bus.GetContactList();
            return Json(new { ok = true, ContactList = contacts });
        }

    }
}
