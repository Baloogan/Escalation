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
            ViewBag.GameId = (Session["Game"] as Game).GameId;
            return View();
        }
    }
}