using SparkleAir.BLL.Service.TaxFree;
using SparkleAir.DAL.EFRepository.TaxFree;
using SparkleAir.IDAL.IRepository.TaxFree;
using SparkleAir.Infa.Dto.TaxFree;
using SparkleAir.Infa.ViewModel.TaxFree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.TaxFree
{
    public class TFOrderlistController : Controller
    {
        ITFOrderRepository TFOrderRepo = new TFOrderlistEFRepository();
        // GET: TFOrderlist
        public ActionResult Index()
        {
            List<TFOrderlistsVm> data = Get();
            return View(data);
        }

        public ActionResult Details(int id)
        {
            TFOrderlistsVm vm = Getid(id);
            return View(vm);
        }
        [HttpPost]
        private List<TFOrderlistsVm> Get()
        {
            var service = new TFOrderlistService(TFOrderRepo);

            List<TFOrderlistsDto> dto = service.Get();
            List<TFOrderlistsVm> vm = dto.Select(p => new TFOrderlistsVm
            {
                Id = p.Id,
                MemberId = p.MemberId,
                TFItemsId = p.TFItemsId,
                Quantity = p.Quantity,
                UnitPrice = p.UnitPrice,

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
            var service = new TFOrderlistService(TFOrderRepo);
            service.Delete(id);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TFOrderlistsVm vm)
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

        private void CreateItem(TFOrderlistsVm vm)
        {
            var service = new TFOrderlistService(TFOrderRepo);
            TFOrderlistsDto dto = new TFOrderlistsDto
            {
                Id = vm.Id,
                MemberId = vm.MemberId,
                TFItemsId = vm.TFItemsId,
                Quantity = vm.Quantity,
                UnitPrice = vm.UnitPrice
            };
            service.Create(dto);
        }

        public ActionResult Edit(int id)
        {
            var TFOrderlist = Getid(id);
            return View(TFOrderlist);
        }

        [HttpPost]
        public ActionResult Edit(TFOrderlistsVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

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

        private TFOrderlistsVm Getid(int id)
        {
            var service = new TFOrderlistService(TFOrderRepo);
            var dto = service.Getid(id);
               
            return new TFOrderlistsVm
            {
                Id = dto.Id,
                MemberId = dto.MemberId,
                TFItemsId = dto.TFItemsId,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice

            };
        }

        [HttpPost]
        private void UpdateItem(TFOrderlistsVm vm)
        {
            var service = new TFOrderlistService(TFOrderRepo);
            TFOrderlistsDto dto = new TFOrderlistsDto
            {
                Id = vm.Id,
                MemberId = vm.MemberId,
                TFItemsId = vm.TFItemsId,
                Quantity = vm.Quantity,
                UnitPrice = vm.UnitPrice
            };
            service.Update(dto);
        }
    }
}