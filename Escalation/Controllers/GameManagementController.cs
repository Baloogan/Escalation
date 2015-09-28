
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
using System.Web.Mvc;

namespace Escalation.Controllers
{
    public class GameManagementController : Controller
    {
        public class GameListing
        {
            public GameListing(Game g)
            {
                Game = g;
                State = g.States.First(F => F.CurrentState);
                StateCount = g.States.Count();
            }
            public int StateCount;
            public Game Game;
            public State State;
            public static List<GameListing> factory(IEnumerable<Game> gs)
            {
                return gs.Select(F => new GameListing(F)).ToList();
            }
        }

        // GET: GameManagement
        [Authorize]
        public ActionResult Resume()
        {
            using (var db = Context.GameContext.Create())
            {
                var user = db.Users.First(F => F.Name == User.Identity.Name);
                var games = GameListing.factory(db.Games.Where(G => G.User.UserId == user.UserId));
                if (games.Count() == 0)
                    return RedirectToAction("StartNew");
                else
                    return View(games);
            }
        }
        [Authorize]
        public ActionResult ResumeSubmit(int GameId)
        {
            using (var db = Context.GameContext.Create())
            {
                var game = db.Games.First(F => F.GameId == GameId);
                var user = db.Users.First(F => F.Name == User.Identity.Name);
                Debug.Assert(game.User.UserId == user.UserId);
                Session["Game"] = game;
                return RedirectToAction("Index", "Game");
            }

        }
        public ActionResult StartNew()
        {
            return View();
        }
        public ActionResult StartNewSubmit(Game game)
        {


            using (var db = Context.GameContext.Create())
            {
                if (User != null && !string.IsNullOrEmpty(User.Identity.Name))
                {
                    var user = db.Users.First(F => F.Name == User.Identity.Name);
                    game.User = user;
                }
                State start = new State();
                start.VertexName = "Start_Initial";
                start.Game = game;
                start.DateTime = new DateTime(2016, 1, 1);
                start.ShowDelta = true;
                start.ShowDebug = false;
                start.EdgeName = "";
                start.Title = "Escalation";
                start.CurrentState = true;
                game.States.Add(start);
                db.Games.Add(game);


                db.SaveChanges();
            }
            Session["Game"] = game;
            return RedirectToAction("Index", "Game");
        }
    }
}