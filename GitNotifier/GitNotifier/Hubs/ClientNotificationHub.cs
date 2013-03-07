﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;

namespace denolk.GitNotifier.Hubs
{
    [HubName("ClientNotificationHub")]
    public class ClientNotificationHub : Hub
    {

        public void Send(string message)
        {
            Clients.All.send(message);
        }


        //public static IHubConnectionContext Clients
        //{
        //    get
        //    {
        //        return GlobalHost.ConnectionManager.GetHubContext<ClientNotificationHub>().Clients;
        //    }
        //}

        public override Task OnConnected()
        {
            return base.OnConnected();
        }
    }
}