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
    [HubName("GameHub")]
    public class GameHub : Hub
    {
        public string choose_option(string EdgeName)
        {
            return null;
        }
        public void client_report(string s)
        {

            //AutoBaloogan.baloogan_chatDB.transmit("es_control", Context.ConnectionId.Substring(0, 4) + " (" + Context.User.Identity.Name + ")" + ": " + s);
            if (Context.User != null && Context.User.Identity != null && Context.User.Identity.Name != null)
                if (Context.User.Identity.Name != "Baloogan")
                    Mailslot.Transmit(Context.ConnectionId.Substring(0, 4) + " (" + Context.User.Identity.Name + ")" + ": " + s);
        }
        public string download_game()
        {
            using (var db = GameContext.CreateDisableLazyLoading())
            {
                int GameId = int.Parse(this.Context.QueryString["GameId"]);

                Game game = db.Games
                    .Include(G => G.User)
                    //.Include(G => G.States)
                    .First(F => F.GameId == GameId);

                return Json.package(game);
            }
        }
        public string download_game_state() // the LATEST state
        {
            using (var db = GameContext.CreateDisableLazyLoading())
            {
                int GameId = int.Parse(this.Context.QueryString["GameId"]);

                var states = db.States
                    //.Include(F => F.Game)
                    .Where(F => F.CurrentState && F.Game.GameId == GameId);

                Debug.Assert(states.Count() == 1);

                State state = states.First();

                Debug.Assert(string.IsNullOrEmpty(state.EdgeName));

                return Json.package(state);
            }
        }
        public void choose_edge(int StateId, string EdgeName) // returns a state
        {
            using (var db = GameContext.Create())
            {

                State old_state = db.States
                    .Include(F => F.Game)
                    .First(S => S.StateId == StateId);

                Vertex v = GraphManager.GetVertex(old_state);

                State new_state = v.Edges.First(F => F.Name == EdgeName).State;

                new_state.StateId = 0;

                old_state.CurrentState = false;
                old_state.EdgeName = EdgeName;

                new_state.CurrentState = true;

                old_state.Game.States.Add(new_state);

                db.States.Add(new_state);
                db.SaveChanges();
            }
        }
        public string download_vertex(int StateId)
        {
            using (var db = GameContext.CreateDisableLazyLoading())
            {

                State state = db.States
                    //.Include(F => F.Game)
                    .First(S => S.StateId == StateId);

                Vertex v = GraphManager.GetVertex(state);


                return Json.package(v);
            }
        }
    }
}