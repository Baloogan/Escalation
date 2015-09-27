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
using Escalation.Graph;
using System.Diagnostics;
using static Escalation.Graph.GraphManager;

namespace Escalation.Client
{
    [HubName("AdminHub")]
    public class AdminHub : Hub
    {


    }
}