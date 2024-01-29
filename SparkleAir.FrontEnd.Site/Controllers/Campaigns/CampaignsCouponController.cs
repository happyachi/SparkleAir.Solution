using SparkleAir.BLL.Service.Campaigns;
using SparkleAir.DAL.EFRepository.Campaigns;
using SparkleAir.FrontEnd.Site.Models.ViewModels.Campaigns;
using SparkleAir.IDAL.IRepository.Campaigns;
using SparkleAir.Infa.Dto.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Dapper.SqlMapper;

namespace SparkleAir.FrontEnd.Site.Controllers.Campaigns
{
    public class CampaignsCouponController : Controller
    {
        CampaignsCouponsEFRepository repo = new CampaignsCouponsEFRepository();


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
            }).ToList();

            return vm;
        }

        #region Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CampaignsCouponVm coupon)
        {
            if (!ModelState.IsValid) return View();
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
                Campaign = vm.Campaign
            };
            service.Create(dto);
        }


        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            var coupon = Get(id);
            return View(coupon);
        }

        private CampaignsCouponVm Get(int id)
        {
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
            var service = new CampaignsCouponsService(repo);
            CampaignsCouponDto dto = new CampaignsCouponDto
            {
                Id = vm.Id,
                Name = vm.Name,
                CampaignId = 4,
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

        public ActionResult GetData()
        {
            List<CampaignsCouponIndexVm> coupons = GetAll();
            return Json(new {data= coupons},JsonRequestBehavior.AllowGet);
        }
       

    }
}