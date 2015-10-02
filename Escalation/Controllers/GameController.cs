using Escalation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Escalation.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);

            // Stop Caching in Firefox
            Response.Cache.SetNoStore();
            ViewBag.GameId = (Session["Game"] as Game).GameId;
            return View();
        }
    }
}