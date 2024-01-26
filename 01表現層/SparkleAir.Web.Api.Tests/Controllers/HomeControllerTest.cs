using Microsoft.VisualStudio.TestTools.UnitTesting;
using SparkleAir.Web.Api;
using SparkleAir.Web.Api.Controllers;
using System.Web.Mvc;

namespace SparkleAir.Web.Api.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // 排列
            HomeController controller = new HomeController();

            // 作用
            ViewResult result = controller.Index() as ViewResult;

            // 判斷提示
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
