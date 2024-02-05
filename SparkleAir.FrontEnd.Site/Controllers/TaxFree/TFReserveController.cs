using SparkleAir.BLL.Service.TaxFree;
using SparkleAir.DAL.EFRepository.TaxFree;
using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.IDAL.IRepository.TaxFree;
using SparkleAir.Infa.Dto.TaxFree;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.ViewModel.TaxFree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.TaxFree
{
    [StaffAuthorize(PageName = "TFReserve")]
    public class TFReserveController : BaseController
    {

        ITFReserve repo = new TFReseveEFRepository();
        // GET: TFReservelist
        public ActionResult Index()
        {
            List<TFReservesVm> data = Get();
            return View(data);
        }


        [HttpPost]
        private List<TFReservesVm> Get()
        {
            var service = new TFReserveService(repo);
            List<TFReservesDto> dto = service.Get();
            List<TFReservesVm> vm = dto.Select(p => new TFReservesVm
            {
                Id = p.Id,
                MemberId = p.MemberId,
                MemberChineseFirstName = p.MemberChineseFirstName,
                MemberChineseLastName = p.MemberChineseLastName,
                MemberEnglishFirstName = p.MemberEnglishFirstName,
                MemberEnglishLastName = p.MemberEnglishLastName,
                MemberPassportNumber = p.MemberPassportNumber,
                MemberEmail = p.MemberEmail,
                MemberPhone = p.MemberPhone,
                Discount = p.Discount,
                TotalPrice = p.TotalPrice,
                TransferPaymentId = p.TransferPaymentId,
            }).ToList();
            return vm;

        }

        public ActionResult Details(int id)
        {
            TFReservesVm vm = Getid(id);
            return View(vm);
        }


        private TFReservesVm Getid(int id)
        {
            var service = new TFReserveService(repo);
            var dto = service.Getid(id);

            return new TFReservesVm
            {
                Id = dto.Id,
                MemberId = dto.MemberId,
                Discount = dto.Discount,
                TotalPrice = dto.TotalPrice,
                TransferPaymentId = dto.TransferPaymentId,

            };

        }

        public ActionResult Delete(int id)
        {
            DeleteItem(id);
            return View("Index");
        }

        private void DeleteItem(int id)
        {
            var service = new TFReserveService(repo);
            service.Delete(id);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TFReservesVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                CreateItem(vm);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(vm);
            }

        }

        private void CreateItem(TFReservesVm vm)
        {
            var service = new TFReserveService(repo);
            TFReservesDto dto = new TFReservesDto
            {
                Id = vm.Id,
                MemberId = vm.MemberId,
                Discount = vm.Discount.HasValue ? vm.Discount.Value : 0,
                TotalPrice = vm.TotalPrice,
                TransferPaymentId = vm.TransferPaymentId,

            };
            service.Create(dto);
        }

        public ActionResult Edit(int id)
        {
            var TFReserves = Getid(id);
            return View(TFReserves);
        }

        [HttpPost]
        public ActionResult Edit(TFReservesVm vm)
        {
            if (!ModelState.IsValid) { return View(); }
            try
            {
                UpdateItem(vm);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(vm);

        }
        [HttpPost]
        private void UpdateItem(TFReservesVm vm)
        {
            var service = new TFReserveService(repo);
            TFReservesDto dto = new TFReservesDto
            {
                Id = vm.Id,
                MemberId = vm.MemberId,
                Discount = vm.Discount.HasValue ? vm.Discount.Value : 0,
                TotalPrice = vm.TotalPrice,
                TransferPaymentId = vm.TransferPaymentId,

            }; service.Update(dto);
        }

    }
}