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
    [StaffAuthorize(PageName = "TFReservelist")]
    public class TFReservelistController : BaseController
    {

        ITFReservelist repo = new TFResevelistEFRepository();
        // GET: TFReservelist
        public ActionResult Index()
        {
            List<TFReservelistsVm> data = Get();
            return View(data);
        }


        [HttpPost]
        private List<TFReservelistsVm> Get()
        {
            var service = new TFReservelistService(repo);
            List<TFReservelistsDto> dto = service.Get();
            List<TFReservelistsVm> vm = dto.Select(p => new TFReservelistsVm
            {
                Id = p.Id,
                TFItemsId = p.TFItemsId,
                TFItemsName = p.TFItemsName,
                TFItemsImage = p.TFItemsImage,
                TFItemsSerialNumber = p.TFItemsSerialNumber,
                TFItemsQuantity = p.TFItemsQuantity,
                TFItemsUnitPrice = p.TFItemsUnitPrice,
                Quantity = p.Quantity,
                UnitPrice = p.UnitPrice,
                Discount = p.Discount,
                TotalPrice = p.TotalPrice,
                TFReserveId = p.TFReserveId,
                MemberChineseFirstName = p.MemberChineseFirstName,
                MemberChineseLastName = p.MemberChineseLastName,
                MemberEnglishFirstName = p.MemberEnglishFirstName,
                MemberEnglishLastName = p.MemberEnglishLastName,
                MemberPassportNumber = p.MemberPassportNumber,
                MemberEmail = p.MemberEmail,
                MemberPhone = p.MemberPhone 
            }).ToList();
            return vm;

        }

        public ActionResult Details(int id)
        {
            TFReservelistsVm vm = Getid(id);
            return View(vm);
        }

        
        private TFReservelistsVm Getid(int id)
        {
            var service = new TFReservelistService(repo);
            var dto = service.Getid(id);

            return new TFReservelistsVm
            {
                Id = dto.Id,
                TFItemsId = dto.TFItemsId,
                TFItemsName = dto.TFItemsName,
                TFItemsImage = dto.TFItemsImage,
                TFItemsSerialNumber = dto.TFItemsSerialNumber,
                TFItemsQuantity = dto.TFItemsQuantity,
                TFItemsUnitPrice = dto.TFItemsUnitPrice,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
                Discount = dto.Discount,
                TotalPrice = dto.TotalPrice,
                TFReserveId = dto.TFReserveId,
                MemberChineseFirstName = dto.MemberChineseFirstName,
                MemberChineseLastName = dto.MemberChineseLastName,
                MemberEnglishFirstName = dto.MemberEnglishFirstName,
                MemberEnglishLastName = dto.MemberEnglishLastName,
                MemberPassportNumber = dto.MemberPassportNumber,
                MemberEmail = dto.MemberEmail,
                MemberPhone = dto.MemberPhone

            };

        }

        public ActionResult Delete(int id)
        {
            DeleteItem(id);
            return View("Index");
        }

        private void DeleteItem(int id)
        {
            var service = new TFReservelistService(repo);
            service.Delete(id);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TFReservelistsVm vm)
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

        private void CreateItem(TFReservelistsVm vm)
        {
            var service = new TFReservelistService(repo);
            TFReservelistsDto dto = new TFReservelistsDto
            {
                Id = vm.Id,
                TFItemsId = vm.TFItemsId,
                Quantity = vm.Quantity,
                UnitPrice = vm.UnitPrice,
                Discount = vm.Discount.HasValue ? vm.Discount.Value : 0,
                TotalPrice = vm.TotalPrice,
                TFReserveId = vm.TFReserveId

            };
            service.Create(dto);
        }

        public ActionResult Edit(int id)
        {
            var TFItem = Getid(id);
            return View(TFItem);
        }

        [HttpPost]
        public ActionResult Edit(TFReservelistsVm vm)
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
        private void UpdateItem(TFReservelistsVm vm)
        {
            var service = new TFReservelistService(repo);
            TFReservelistsDto dto = new TFReservelistsDto
            {
                Id = vm.Id,
                TFItemsId = vm.TFItemsId,
                Quantity = vm.Quantity,
                UnitPrice = vm.UnitPrice,
                Discount = vm.Discount.HasValue ? vm.Discount.Value : 0,
                TotalPrice = vm.TotalPrice,
                TFReserveId = vm.TFReserveId

            }; service.Update(dto);
        }

    }
}