using SparkleAir.BLL.Service.Airports;
using SparkleAir.DAL.EFRepository.Airports;
using SparkleAir.Infa.Dto.Airport;
using SparkleAir.Infa.ViewModel.Airports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.Airports
{
   
    
    public class AirportsController : Controller
    {

        //EF
        AirportEFRepository efRepository = new AirportEFRepository();

        // GET: Airports
        public ActionResult Index()
        {
            List<AirportIndexVm> data = GetAll();
            return View(data);
        }


        private List<AirportIndexVm> GetAll()
        {
            var service = new AirportService(efRepository);

            List<AirportDto> dto = service.GetAll();

            List<AirportIndexVm> vm = dto.Select(p => new AirportIndexVm
            {
                Id = p.Id,
                Lata = p.Lata,
                Gps = p.Gps,
                Country = p.Country,
                City = p.City,
                AirPortName = p.AirPortName,
                TimeArea = p.TimeArea,
                Zone = p.Zone,
                CityIntroduction = p.CityIntroduction,
                Img = p.Img,
                Continent = p.Continent,

            }).ToList();

            return vm;
        }




    }
}