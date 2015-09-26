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

            return View();
        }
    }
}