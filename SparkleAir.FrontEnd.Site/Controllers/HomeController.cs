using SparkleAir.FrontEnd.Site.Models.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers
{
    [StaffAuthorize(PageName = "Home")]
    public class HomeController : BaseController
    {
        public ActionResult Index()
		{

			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

        public ActionResult Error404()
		{
			return View();
        }

        public ActionResult Error405()
        {
            return View();
        }
        public ActionResult Error500()
        {
            return View();
        }

    }
}