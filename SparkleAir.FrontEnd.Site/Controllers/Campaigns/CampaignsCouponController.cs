using SparkleAir.BLL.Service.AirFlights;
using SparkleAir.BLL.Service.Campaigns;
using SparkleAir.BLL.Service.LuggageOrderService;
using SparkleAir.BLL.Service.Members;
using SparkleAir.DAL.EFRepository.AirFlights;
using SparkleAir.DAL.EFRepository.Campaigns;
using SparkleAir.DAL.EFRepository.Members;
using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.FrontEnd.Site.Models.ViewModels.Campaigns;
using SparkleAir.IDAL.IRepository.Campaigns;
using SparkleAir.Infa.Criteria.AirFlights;
using SparkleAir.Infa.Criteria.Campaigns;
using SparkleAir.Infa.Dto.Campaigns;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.ViewModel.AirFlights;
using SparkleAir.Infa.ViewModel.TaxFree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using static Dapper.SqlMapper;

namespace SparkleAir.FrontEnd.Site.Controllers.Campaigns
{
    [StaffAuthorize(PageName = "CampaignsCoupon")]
    public class CampaignsCouponController : BaseController
    {
        CampaignsCouponsEFRepository repo = new CampaignsCouponsEFRepository();
        MemberClassEFRepository memberRepo = new MemberClassEFRepository();

        public ActionResult Index()
        {
            List<CampaignsCouponIndexVm> coupons = GetAll();
            return View(coupons);
        }

        private List<CampaignsCouponIndexVm> GetAll()
        {
            var service = new CampaignsCouponsService(repo);

            List<CampaignsCouponDto> dto = service.GetAll();
            List<CampaignsCouponIndexVm> vm = dto.Select(c => new CampaignsCouponIndexVm
            {
                Id = c.Id,
                Name = c.Name,
                DateStart = c.DateStart,
                DateEnd = c.DateEnd,
                DateCreated = c.DateCreated,
                Status = c.Status,
                Code = c.Code,
                Type = c.Type
            }).ToList();

            return vm;
        }
     
        #region Create
        public ActionResult Create()
        {
            var memberservice = new MemberClassService(memberRepo);
            ViewBag.Member = memberservice.Search();
            ViewBag.List = CreateSelectFlights();
            return View();
        }

        [HttpPost]
        public ActionResult Create(CampaignsCouponVm coupon)
        {
            if (!ModelState.IsValid) return View();
            var memberservice = new MemberClassService(memberRepo);
            ViewBag.Member = memberservice.Search();
            ViewBag.List = CreateSelectFlights();

            try
            {
                CreateCoupon(coupon);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(coupon);
            }
        }

        private void CreateCoupon(CampaignsCouponVm vm)
        {
            var service = new CampaignsCouponsService(repo);

            CampaignsCouponDto dto = new CampaignsCouponDto
            {
                //Id = vm.Id,
                Name = vm.Name,
                CampaignId =vm.CampaignId,
                DateStart = vm.DateStart,
                DateEnd = vm.DateEnd,
                DateCreated = vm.DateCreated,
                Status = vm.Status,
                DiscountQuantity = vm.DiscountQuantity,
                DiscountValue = vm.DiscountValue,
                AvailableQuantity = vm.AvailableQuantity,
                MinimumOrderValue = vm.MinimumOrderValue,
                MaximumDiscountAmount = vm.MaximumDiscountAmount,
                Code = vm.Code,
                DisplayDescription = vm.DisplayDescription,
                MemberCriteria = vm.MemberCriteria,
                AirFlightsCriteria = vm.AirFlightsCriteria,
                Campaign = "優惠券"
            };
            service.Create(dto);
        }

        public ActionResult SelectFlights()
        {
            if (!ModelState.IsValid) return View();
            try
            {
                List<AirFlightVm> vms = CreateSelectFlights();
                return PartialView("SelectFlights", vms);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        private List<AirFlightVm> CreateSelectFlights()
        {
            var dtos = new AirFlightService(new AirFlightEFRepository()).GetAll();
            var flights = dtos.Select(x => new AirFlightVm
            {
                Id = x.Id,
                AirOwnId = x.AirOwnId,
                AirFlightManagementId = x.AirFlightManagementId,
                ScheduledDeparture = x.ScheduledDeparture,
                ScheduledArrival = x.ScheduledArrival,
                AirFlightSaleStatus = x.AirFlightSaleStatus,
                FlightModel = x.FlightModel,
                FlightCode = x.FlightCode,
                AirFlightSaleStatusId = x.AirFlightSaleStatusId,
            }).ToList();

            return flights;
        }

        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            var memberservice = new MemberClassService(memberRepo);
            ViewBag.Member = memberservice.Search();
            if (ViewBag.Member == null) return RedirectToAction("Error");

            var coupon = Get(id);
            return View(coupon);
        }

        private CampaignsCouponVm Get(int id)
        {
            var memberservice = new MemberClassService(memberRepo);
            //ViewBag.Member = memberservice.Search();
            var service = new CampaignsCouponsService(repo);
            var get = service.Get(id);
            return new CampaignsCouponVm
            {
                Id = id,
                Name = get.Name,
                CampaignId = get.CampaignId,
                DateStart = get.DateStart,
                DateEnd = get.DateEnd,
                DateCreated = DateTime.Now,
                Status = get.Status,
                DiscountQuantity = get.DiscountQuantity,
                DiscountValue = get.DiscountValue,
                AvailableQuantity = get.AvailableQuantity,
                MinimumOrderValue = get.MinimumOrderValue,
                MaximumDiscountAmount = get.MaximumDiscountAmount,
                Code = get.Code,
                DisplayDescription = get.DisplayDescription,
                MemberCriteria = get.MemberCriteria,
                AirFlightsCriteria = get.AirFlightsCriteria,
                Campaign = get.Campaign
            };
        }

        [HttpPost]
        public ActionResult Edit(CampaignsCouponVm coupon)
        {
            var memberservice = new MemberClassService(memberRepo);
            //ViewBag.Member = memberservice.Search();
            if (!ModelState.IsValid) return View();
            try
            {
                Update(coupon);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(coupon);
            }
        }

        private void Update(CampaignsCouponVm vm)
        {
            var memberservice = new MemberClassService(memberRepo);
            //ViewBag.Member = memberservice.Search();
            var service = new CampaignsCouponsService(repo);
            CampaignsCouponDto dto = new CampaignsCouponDto
            {
                Id = vm.Id,
                Name = vm.Name,
                CampaignId = vm.CampaignId,
                DateStart = vm.DateStart,
                DateEnd = vm.DateEnd,
                DateCreated = vm.DateCreated,
                Status = vm.Status,
                DiscountQuantity = vm.DiscountQuantity,
                DiscountValue = vm.DiscountValue,
                AvailableQuantity = vm.AvailableQuantity,
                MinimumOrderValue = vm.MinimumOrderValue,
                MaximumDiscountAmount = vm.MaximumDiscountAmount,
                Code = vm.Code,
                DisplayDescription = vm.DisplayDescription,
                MemberCriteria = vm.MemberCriteria,
                AirFlightsCriteria = vm.AirFlightsCriteria,
                Campaign = vm.Campaign
            };
            service.Update(dto);
        }

        #endregion

        #region Delete
        //public ActionResult Delete()
        //{
        //    return View();
        //}

        
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid) return View();
            try
            {  
                DeleteCoupon(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        private void DeleteCoupon(int id)
        {
            var service = new CampaignsCouponsService(repo);
            service.Delete(id);
        }
        #endregion

        #region Details
        public ActionResult Details(int id)
        {
            var coupon = Get(id);
            return View(coupon);
        }
        #endregion

        #region Search
        public ActionResult SearchPartialCamapign(CampaignsCouponSearchCriteria vm)
        {
            var viewModel = SearchCoupons(vm);
            return PartialView("_SearchPartialCamapign", viewModel);
        }
        private List<CampaignsCouponIndexVm> SearchCoupons(CampaignsCouponSearchCriteria vm)
        {
            var service = new CampaignsCouponsService(repo);
            var list = service.Search(vm);

            return list.Select(data => new CampaignsCouponIndexVm
            {
                Id = data.Id,
                Name = data.Name,
                DateCreated = data.DateCreated,
                DateStart = data.DateStart,
                DateEnd = data.DateEnd,
                Status = data.Status,
                Code = data.Code,
                Type = data.Type                
            }).ToList();
        }
        #endregion

        //public ActionResult GetData()
        //{
        //    List<CampaignsCouponIndexVm> coupons = GetAll();
        //    return Json(new { data = coupons }, JsonRequestBehavior.AllowGet);
        //}

        #region GetDetail
        public ActionResult GetDetail(int id)
        {
            var service = new CampaignsCouponsService(repo);
            var data = service.Get(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}