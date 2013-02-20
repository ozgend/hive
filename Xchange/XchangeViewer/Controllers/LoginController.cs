using Denolk.XchangeViewer.Business;
using Denolk.XchangeViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Denolk.XchangeViewer.Controllers
{
    public class LoginController : Controller
    {

        UserBusiness _bus = new UserBusiness();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Process(string name, string password)
        {
            bool result = _bus.Login(name, password);
            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Index();
            }
        }

    }
}
