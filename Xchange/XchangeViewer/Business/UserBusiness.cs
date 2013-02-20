using Denolk.XchangeViewer.Models;
using Denolk.XchangeWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Denolk.XchangeViewer.Business
{
    public class UserBusiness
    {

        public bool Login(string name, string password)
        {
            XChangeApplication.Service = XService.Init(name, password);
            return true;
        }

        public bool IsAuthenticated()
        {
            //ozgend: really??
            var service = XChangeApplication.Service;
            if (service != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}