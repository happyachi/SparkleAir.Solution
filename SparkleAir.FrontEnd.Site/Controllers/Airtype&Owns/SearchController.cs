using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.Infa.Dto.Airtype_Owns;
using SparkleAir.Infa.EFModel.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace SparkleAir.FrontEnd.Site.Controllers.Airtype_Owns
{
    [StaffAuthorize(PageName = "Search")]
    public class SearchController : BaseController
    {
        private readonly AppDbContext _dbContext;


        public SearchController()
        {
            _dbContext = new AppDbContext();
        }

        //public SearchController(AppDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        // GET: Api

        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public JsonResult Search([FromBody] SearchDto searchdto)
        {

            IQueryable<AirOwn> result = null;

            // 根据关键字搜索
            if (!string.IsNullOrEmpty(searchdto.keyword))
            {
                result = _dbContext.AirOwns.Where(s => s.RegistrationNum.Contains(searchdto.keyword));
            }
            else
            {
                result = _dbContext.AirOwns.Where(s => s.RegistrationNum.Contains("B"));
            }

            // 排序
            if (!string.IsNullOrEmpty(searchdto.sortType) && !string.IsNullOrEmpty(searchdto.sortBy))
            {

                result = searchdto.sortType == "asc" && searchdto.sortBy == "airTypeId" ? result.OrderBy(s => s.AirTypeId) : result.OrderByDescending(s => s.AirTypeId);

            }

            return Json(result.Select(item => new
            {
                FlightModel = item.AirType.FlightModel,
                AirTypeId = item.AirTypeId,
                RegistrationNum = item.RegistrationNum,
                Status = item.Status,
                ManufactureYear = item.ManufactureYear,
                Id = item.Id
            }).ToList());




        }
    }
}
