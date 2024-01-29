using SparkleAir.BLL.Service.Airports;
using SparkleAir.BLL.Service.TaxFree;
using SparkleAir.DAL.EFRepository.TaxFree;
using SparkleAir.IDAL.IRepository.TaxFree;
using SparkleAir.Infa.Dto.Airport;
using SparkleAir.Infa.Dto.TaxFree;
using SparkleAir.Infa.ViewModel.Airports;
using SparkleAir.Infa.ViewModel.TaxFree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.TaxFree
{
    public class TFItemController : Controller
    {

        ITFRepository TFRepository = new TFItemEFRepository();

        // GET: TFItem
        public ActionResult Index()
        {
            List<TFItemVm> data = Get();
            return View(data);
        }

        private List<TFItemVm> Get()
        {

            var service = new TaxFreeService(TFRepository); //告訴service要用接收哪個資料庫

            List<TFItemDto> dto = service.Get();

            List<TFItemVm> vm = dto.Select(p => new TFItemVm
            {
                Id = p.Id,
                TFCategoriesId = p.TFCategoriesId,
                Name = p.Name,
                SerialNumber = p.SerialNumber,
                Image = p.Image,
                Quantity = p.Quantity,
                UnitPrice = p.UnitPrice,
                Description = p.Description,
                IsPublished = p.IsPublished,
                

            }).ToList();

            return vm;
        }
    }
}