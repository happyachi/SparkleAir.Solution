using SparkleAir.BLL.Service.Luggage;
using SparkleAir.BLL.Service.LuggageOrderService;
using SparkleAir.DAL.EFRepository.LuggageOrders;
using SparkleAir.IDAL.IRepository.LuggageOrders;
using SparkleAir.Infa.Dto.Luggage;
using SparkleAir.Infa.Dto.LuggageOrders;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.ViewModel.Luggage;
using SparkleAir.Infa.ViewModel.LuggageOrders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;
using SparkleAir.BLL.Service.Airports;
using SparkleAir.IDAL.IRepository.TaxFree;
using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.DAL.EFRepository.AirFlights;
using SparkleAir.BLL.Service.AirFlights;
using SparkleAir.Infa.ViewModel.Airports;
using SparkleAir.FrontEnd.Site.Models.Authorize;

namespace SparkleAir.FrontEnd.Site.Controllers.LuggageOrders
{
    [StaffAuthorize(PageName = "LuggageOrders")]
    public class LuggageOrdersController : BaseController
    {
        ILuggageOrderRepository efRLuggageorder = new LuggageOrderEFRepository();
        IAirFlightManagementRepository efAirFlightManagement = new AirFlightManagementEFRepository();
        // GET: LuggageOrders
        public ActionResult Index()
        {
            var service = new LuggageOrderService(efRLuggageorder);
            
            var flightService = new AirFlightManagementService(efAirFlightManagement);

            List<LuggageOrderIndexVm> data = GetAll();

            ViewBag.luggageorder = flightService.GetAll(); //回傳所有的資料


            return View(data);
        }

        //bootstrap 的傳回資料
        public ActionResult GetDetail(int id)
        {
            var service = new LuggageOrderService(efRLuggageorder);

            var data = service.Get(id);

            return Json(data, JsonRequestBehavior.AllowGet); //一定要加 "JsonRequestBehavior.AllowGet " 才可傳回Json檔
        }
        
        public ActionResult PartialIndex(string flightcode)
        {
            //var service = new LuggageOrderService(efRLuggageorder);
            //var flightService = new AirFlightManagementService(efAirFlightManagement);

            List<LuggageOrderIndexVm> data = GetAll();


            List<LuggageOrderIndexVm> select;

            if (flightcode ==null)
            {
                return PartialView("PartialIndex", data) ;
            }
            else
            {
                select = data.Where(p => p.FlightCode==flightcode ).ToList();
               
                return PartialView("PartialIndex", select);

            }

            

        }


        private List<LuggageOrderIndexVm> GetAll()
        {
            var service = new LuggageOrderService(efRLuggageorder); //告訴service要用接收哪個資料庫

            List<LuggageOrderDto> dto = service.GetAll();

            List<LuggageOrderIndexVm> vm = dto.Select(p => new LuggageOrderIndexVm
            {

                Id = p.Id,
                FlightCode= p.FlightCode,
                TicketInvoicingDetailId = p.TicketInvoicingDetailId,
                TicketInvoicingDetailName = p.TicketInvoicingDetailName,
                LuggageId = p.LuggageId,
                LuggagePrice = p.LuggagePrice,
                Amount = p.Amount,
                Price = p.Price,
                OrderTime = p.OrderTime,
                TransferPaymentsId = p.TransferPaymentsId,
                OrderStatus = p.OrderStatus,
                LuggageNum = p.LuggageNum,


            }).ToList();

            //if(!String.IsNullOrEmpty(Price))

            return vm;
        }


        #region Create
        public ActionResult Create()
        {         
            return View();
        }

        [HttpPost]
        public ActionResult Create(LuggageOrderCreateVm luggageorder)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                CreateLuggageorder(luggageorder);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(luggageorder);
            }
        }
        private void CreateLuggageorder(LuggageOrderCreateVm luggageorder)
        {
            var service = new LuggageOrderService(efRLuggageorder); //告訴service要用接收哪個資料庫

            LuggageOrderDto dto = new LuggageOrderDto
            {
                Id = luggageorder.Id,
                TicketInvoicingDetailId = luggageorder.TicketInvoicingDetailId,
                LuggageId = luggageorder.LuggageId,
                Amount = luggageorder.Amount,
                Price = luggageorder.Price,
                OrderTime = luggageorder.OrderTime,
                TransferPaymentsId = luggageorder.TransferPaymentsId,
                OrderStatus = luggageorder.OrderStatus,
                LuggageNum = luggageorder.LuggageNum,


            };
            service.Create(dto);
        }

        #endregion



        public List<LuggageOrderIndexVm> Search(int price)
        {
            //儲存查詢出來的UserId
            var searchUserId = new List<LuggageOrderIndexVm>();
            using (AppDbContext db = new AppDbContext())
            {
                searchUserId = db.LuggageOrders.AsNoTracking()
                               .Include(p => p.TicketInvoicingDetail)
                               .Include(p => p.Luggage)
                               .Include(p => p.TransferPayment)
                               .Where(p => p.Price == price)
                               .Select(p => new LuggageOrderIndexVm
                               {

                                   Id = p.Id,
                                   TicketInvoicingDetailId = p.TicketInvoicingDetailId,
                                   TicketInvoicingDetailName = p.TicketInvoicingDetail.FirstName + p.TicketInvoicingDetail.LastName,
                                   LuggageId = p.LuggageId,
                                   LuggagePrice = p.Luggage.BookPrice,
                                   Amount = p.Amount,
                                   Price = p.Price,
                                   OrderTime = p.OrderTime,
                                   TransferPaymentsId = p.TransferPaymentsId,
                                   OrderStatus = p.OrderStatus,
                                   LuggageNum = p.LuggageNum,


                               }).ToList();

                return searchUserId;
            }
        }


        public ActionResult Details(int id)
        {
            LuggageOrderIndexVm vm = Get(id);
            return View(vm);
        }

        private LuggageOrderIndexVm Get(int id)
        {
            var service = new LuggageOrderService(efRLuggageorder);
            var get = service.Get(id);

            return new LuggageOrderIndexVm
            {

                Id = get.Id,
                FlightCode = get.FlightCode,
                TicketInvoicingDetailId = get.TicketInvoicingDetailId,
                TicketInvoicingDetailName = get.TicketInvoicingDetailName,
                LuggageId = get.LuggageId,
                LuggagePrice = get.LuggagePrice,
                Amount = get.Amount,
                Price = get.Price,
                OrderTime = get.OrderTime,
                TransferPaymentsId = get.TransferPaymentsId,
                OrderStatus = get.OrderStatus,
                LuggageNum = get.LuggageNum,
            };
        }




    }
    public class ttt
    {
        public string flightcode { get; set; }
    }


}



        