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
    public class TFItemController : BaseController
    {

        ITFRepository TFRepository = new TFItemEFRepository();

        // GET: TFItem
        public ActionResult Index()
        {
            List<TFItemVm> data = Get();
            return View(data);
        }
        public ActionResult Details(int id)
        {
            TFItemVm vm =Getid(id);
            return View(vm);
        }
        [HttpPost]
        private List<TFItemVm> Get()
        {

            var service = new TaxFreeService(TFRepository); //告訴service要用接收哪個資料庫

            List<TFItemDto> dto = service.Get();

            List<TFItemVm> vm = dto.Select(p => new TFItemVm
            {
                Id = p.Id,
                TFCategoriesName = p.TFCategoriesName,
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

        public ActionResult Delete(int id)
        {
            DeleteItem(id);
            return View("Index");
        }

        private void DeleteItem(int id)
        {
            var service = new TaxFreeService(TFRepository);
            service.Delete(id);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TFItemVm vm)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                CreateItem(vm);
                return RedirectToAction("Index");
            }catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(vm);
            }
            
        }

        private void CreateItem(TFItemVm vm)
        {
            var service = new TaxFreeService(TFRepository);
            TFItemDto dto = new TFItemDto
            {
                Id = vm.Id,
                Name = vm.Name,
                TFCategoriesId = vm.TFCategoriesId,
                SerialNumber = vm.SerialNumber,
                Image = vm.Image,
                Quantity = vm.Quantity,
                UnitPrice = vm.UnitPrice,
                Description = vm.Description,
                IsPublished = vm.IsPublished,

            };
            service.Create(dto);
        }
        
        public ActionResult Edit(int id)
        {
            var TFItem = Getid(id);
            return View(TFItem);
        }

        [HttpPost]
        public ActionResult Edit(TFItemVm vm)
        {
            if (!ModelState.IsValid) { return View(); }
            try
            {
                UpdateItem(vm);
                return RedirectToAction("Index");
            }catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(vm);

        }
        [HttpPost]
        private void UpdateItem(TFItemVm vm)
        {
            var service = new TaxFreeService(TFRepository);
            TFItemDto dto = new TFItemDto
            {
                Id = vm.Id,
                Name = vm.Name,
                TFCategoriesId = vm.TFCategoriesId,
                SerialNumber = vm.SerialNumber,
                Image = vm.Image,
                Quantity = vm.Quantity,
                UnitPrice = vm.UnitPrice,
                Description = vm.Description,
                IsPublished = vm.IsPublished,

            }; service.Update(dto);
        }

        private TFItemVm Getid(int id)
        {
            var service = new TaxFreeService(TFRepository);
            var dto = service.Getid(id);

            return new TFItemVm
            {
                Id = dto.Id,
                TFCategoriesId = dto.TFCategoriesId,
                Name = dto.Name,
                SerialNumber = dto.SerialNumber,
                Image = dto.Image,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
                Description = dto.Description,
                IsPublished = dto.IsPublished,
            };
        }
    }
}