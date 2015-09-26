using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Newtonsoft.Json;
using Escalation.Context;
using Escalation.Model;

namespace Escalation.Client
{
    [HubName("GameHub")]
    public class ChatHub : Hub
    {
        public State choose_option()
        {
            return null;
        }
        public void client_report(string s)
        {
            //if (Context.User.Identity.Name != "Baloogan")
            AutoBaloogan.baloogan_chatDB.transmit("es_control", Context.ConnectionId.Substring(0, 4) + " (" + Context.User.Identity.Name + ")" + ": " + s);
        }

    }
}