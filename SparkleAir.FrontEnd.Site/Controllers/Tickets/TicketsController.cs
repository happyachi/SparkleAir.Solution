using SparkleAir.FrontEnd.Site.Models.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.Tickets
{
    [StaffAuthorize(PageName = "Tickets")]
    public class TicketsController : Controller
    {
        // GET: Tickets
        public ActionResult Index()
        {
            return View();
        }
    }
}