using denolk.GitNotifier.Hubs;
using denolk.GitNotifierLibrary.Model;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace denolk.GitNotifier.Controllers
{
    public class HookController : ApiController
    {
        [HttpPost]
        [HttpGet]
        public void Notify()
        {
            bool isFormData = Request.Content.IsFormData();
            if (!isFormData) { return; }

            string data = HttpContext.Current.Request.Form["payload"];

            GitPayload payload = JsonConvert.DeserializeObject<GitPayload>(data);

            string message = string.Format("'{0}' pushed on '{1}'", payload.commits[0].author.name, payload.repository.name);

            GlobalHost.ConnectionManager.GetHubContext<ClientNotificationHub>().Clients.All.Send(message);

        }

    }
}
