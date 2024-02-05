using Microsoft.Ajax.Utilities;
using SparkleAir.BLL.Service.AirFlights;
using SparkleAir.BLL.Service.Campaigns;
using SparkleAir.BLL.Service.Members;
using SparkleAir.BLL.Service.TaxFree;
using SparkleAir.DAL.EFRepository.Campaigns;
using SparkleAir.DAL.EFRepository.Members;
using SparkleAir.DAL.EFRepository.TaxFree;
using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.FrontEnd.Site.Models.ViewModels.Campaigns;
using SparkleAir.IDAL.IRepository.TaxFree;
using SparkleAir.Infa.Criteria.Campaigns;
using SparkleAir.Infa.Dto.Campaigns;
using SparkleAir.Infa.Dto.TaxFree;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.ViewModel.Campaigns;
using SparkleAir.Infa.ViewModel.TaxFree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace SparkleAir.FrontEnd.Site.Controllers.Campaigns
{
    [StaffAuthorize(PageName = "CampaignsDiscount")]
    public class CampaignsDiscountController : BaseController
    {

        CampaignsDiscountsEFRepository repo = new CampaignsDiscountsEFRepository();
        MemberClassEFRepository memberRepo = new MemberClassEFRepository();
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
                Id = d.Id,
                CampaignId=d.CampaignId,
                Name = d.Name,
                DateStart = d.DateStart,
                DateEnd = d.DateEnd,
                DateCreated = d.DateCreated,
                Status = d.Status,
                Type = d.Type
            }).ToList();

            return vm;
        }

        #region Create
        public ActionResult Create()
        {
            var memberservice = new MemberClassService(memberRepo);
            ViewBag.Member = memberservice.Search();
            ViewBag.List = CreateSelectProducts();
            return View();
        }

        [HttpPost]
        public ActionResult Create(CampaignsDiscountVm discount)
        {
            if (!ModelState.IsValid) return View();
            var memberservice = new MemberClassService(memberRepo);
            ViewBag.Member = memberservice.Search();
            ViewBag.List = CreateSelectProducts();

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
                //Id = vm.Id,
                Name = vm.Name,
                CampaignId = vm.CampaignId,
                DateStart = vm.DateStart,
                DateEnd = vm.DateEnd,
                DateCreated = vm.DateCreated,
                Status = vm.Status,
                DiscountValue = vm.DiscountValue,
                Value = vm.Value,
                BundleSKUs = vm.BundleSKUs,
                MemberCriteria = vm.MemberCriteria,
                TFItemsCriteria = vm.TFItemsCriteria,
                //Campaign = "促銷組合"
            };

            service.Create(dto);
        }

        public ActionResult SelectProduct()
        {
            if (!ModelState.IsValid) return View();
            try
            {
                var vms = CreateSelectProducts();
                return PartialView("SelectProduct", vms);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        private IEnumerable<SparkleAir.Infa.ViewModel.TaxFree.TFItemVm> CreateSelectProducts()
        {
            var dtos = new TaxFreeService(new TFItemEFRepository()).Get();
            var products = dtos.Select(x => new TFItemVm
            {
                Id = x.Id,
                TFCategoriesId = x.TFCategoriesId,
                TFCategoriesName = x.TFCategoriesName,
                Name = x.Name,
                SerialNumber = x.SerialNumber,
                Image = x.Image,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice,
                Description = x.Description,
                IsPublished = x.IsPublished
            }).ToList();

            return products;
        }

        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            var memberservice = new MemberClassService(memberRepo);
            ViewBag.Member = memberservice.Search();
            if (ViewBag.Member == null)  return RedirectToAction("Error");
    
            var discount = Get(id);
            return View(discount);
        }

        private CampaignsDiscountVm Get(int id)
        {
            var memberservice = new MemberClassService(memberRepo);
            //ViewBag.Member = memberservice.Get(id);
            var service = new CampaignsDiscountsService(repo);
            var get = service.Get(id);
            return new CampaignsDiscountVm
            {
                Name = get.Name,
                CampaignId = get.CampaignId,
                DateStart = get.DateStart,
                DateEnd = get.DateEnd,
                DateCreated = get.DateCreated,
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
            var memberservice = new MemberClassService(memberRepo);
            //ViewBag.Member = memberservice.Get(id);
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
            var memberservice = new MemberClassService(memberRepo);
            //ViewBag.Member = memberservice.Get();
            var service = new CampaignsDiscountsService(repo);
            CampaignsDiscountDto dto = new CampaignsDiscountDto
            {
                Id = vm.Id,
                Name = vm.Name,
                CampaignId = vm.CampaignId,
                DateStart = vm.DateStart,
                DateEnd = vm.DateEnd,
                DateCreated = vm.DateCreated,
                Status = vm.Status,
                DiscountValue = vm.DiscountValue,
                Value = vm.Value,
                BundleSKUs = vm.BundleSKUs,
                MemberCriteria = vm.MemberCriteria,
                TFItemsCriteria = vm.TFItemsCriteria,
                //Campaign = "促銷組合"
            };
            service.Update(dto);
        }

        #endregion

        #region Delete
      
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

        #region Details
        public ActionResult Details(int id)
        {
            var discount = Get(id);
            return View(discount);
        }
        #endregion

        #region Search
        public ActionResult SearchPartialCamapign(CampaignsDiscountSearchCriteria vm)
        {
            var viewModel = SearchDiscounts(vm);
            return PartialView("_SearchPartialCamapign", viewModel);
        }
        private List<CampaignsDiscountIndexVm> SearchDiscounts(CampaignsDiscountSearchCriteria vm)
        {
            var service = new CampaignsDiscountsService(repo);
            var list = service.Search(vm);

            return list.Select(data => new CampaignsDiscountIndexVm
            {
                Id = data.Id,
                CampaignId = data.CampaignId,
                Name = data.Name,
                DateCreated = data.DateCreated,
                DateStart = data.DateStart,
                DateEnd = data.DateEnd,
                Status = data.Status,
                Type = data.Type
            }).ToList();
        }
        #endregion

        #region GetDetail
        public ActionResult GetDetail(int id)
        {
            var service = new CampaignsDiscountsService(repo);
            var data = service.Get(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}