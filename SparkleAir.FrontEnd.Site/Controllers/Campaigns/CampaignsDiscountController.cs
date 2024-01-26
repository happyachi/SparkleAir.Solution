using SparkleAir.BLL.Service.Campaigns;
using SparkleAir.DAL.EFRepository.Campaigns;
using SparkleAir.FrontEnd.Site.Models.ViewModels.Campaigns;
using SparkleAir.Infa.Dto.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.Campaigns
{
    public class CampaignsDiscountController : Controller
    {
        CampaignsDiscountsEFRepository repo = new CampaignsDiscountsEFRepository();


        public ActionResult Index()
        {
            List<CampaignsDiscountIndexVm> discount = GetAll();
            return View(discount);
        }

        private List<CampaignsDiscountIndexVm> GetAll()
        {
            var service = new CampaignsDiscountsService(repo);

            List<CampaignsDiscountDto> dto = service.GetAll();

            List<CampaignsDiscountIndexVm> vm = dto.Select(d => new CampaignsDiscountIndexVm
            {
                //Id = d.Id,
                //CampaignId=d.CampaignId,
                Name = d.Name,
                DateStart = d.DateStart,
                DateEnd = d.DateEnd,
                DateCreated = d.DateCreated,
                Status = d.Status
            }).ToList();

            return vm;
        }

        #region Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CampaignsDiscountVm discount)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                CreateDiscount(discount);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(discount);
            }
        }

        private void CreateDiscount(CampaignsDiscountVm vm)
        {
            var service = new CampaignsDiscountsService(repo);

            CampaignsDiscountDto dto = new CampaignsDiscountDto
            {
                Id = vm.Id,
                Name = vm.Name,
                CampaignId = vm.CampaignId,
                DateStart = vm.DateStart,
                DateEnd = vm.DateEnd,
                DateCreated = DateTime.Now,
                Status = vm.Status,
                DiscountValue = vm.DiscountValue,
                Value = vm.Value,
                BundleSKUs = vm.BundleSKUs,
                MemberCriteria = vm.MemberCriteria,
                TFItemsCriteria = vm.TFItemsCriteria,
                Campaign=vm.Campaign
            };

            service.Create(dto);
        }
        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            var discount = Get(id);
            return View(discount);
        }

        private CampaignsDiscountVm Get(int id)
        {
            var service = new CampaignsDiscountsService(repo);
            var get = service.Get(id);
            return new CampaignsDiscountVm
            {
                Name = get.Name,
                CampaignId = get.CampaignId,
                DateStart = get.DateStart,
                DateEnd = get.DateEnd,
                DateCreated = DateTime.Now,
                Status = get.Status,
                DiscountValue = get.DiscountValue,
                Value= get.Value,
                BundleSKUs= get.BundleSKUs,
                MemberCriteria = get.MemberCriteria,
                TFItemsCriteria = get.TFItemsCriteria,
                Campaign = get.Campaign
            };
        }

        [HttpPost]
        public ActionResult Edit(CampaignsDiscountVm discount)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                Update(discount);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(discount);
            }
        }

        private void Update(CampaignsDiscountVm vm)
        {
            var service = new CampaignsDiscountsService(repo);
            CampaignsDiscountDto dto = new CampaignsDiscountDto
            {
                Id = vm.Id,
                Name = vm.Name,
                CampaignId = vm.CampaignId,
                DateStart = vm.DateStart,
                DateEnd = vm.DateEnd,
                DateCreated = DateTime.Now,
                Status = vm.Status,
                DiscountValue = vm.DiscountValue,
                Value = vm.Value,
                BundleSKUs = vm.BundleSKUs,
                MemberCriteria = vm.MemberCriteria,
                TFItemsCriteria = vm.TFItemsCriteria,
                Campaign = vm.Campaign
            };
            service.Update(dto);
        }

        #endregion

        #region Delete
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                DeleteDiscount(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        private void DeleteDiscount(int id)
        {
            var service = new CampaignsDiscountsService(repo);
            service.Delete(id);
        }

        #endregion
    }
}