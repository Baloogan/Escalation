using Escalation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Escalation.Controllers
{
    public class GameManagementController : Controller
    {
        // GET: GameManagement

        public ActionResult StartNew()
        {
            return View();
        }
        public ActionResult StartNewSubmit(Game game)
        {


            using (var db = Context.GameContext.Create())
            {
                /*if (User != null)
                {
                    var user = db.Users.First(F => F.Name == User.Identity.Name);
                    game.User = user;
                }*/
                State start = new State();
                start.VertexName = "Start_Step1";
                start.Game = game;
                start.DateTime = DateTime.Now;
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