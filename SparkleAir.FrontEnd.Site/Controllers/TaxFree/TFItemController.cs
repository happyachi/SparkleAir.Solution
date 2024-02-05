using SparkleAir.BLL.Service.Airports;
using SparkleAir.BLL.Service.TaxFree;
using SparkleAir.DAL.EFRepository.TaxFree;
using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.IDAL.IRepository.TaxFree;
using SparkleAir.Infa.Dto.Airport;
using SparkleAir.Infa.Dto.TaxFree;
using SparkleAir.Infa.Utility;
using SparkleAir.Infa.ViewModel.Airports;
using SparkleAir.Infa.ViewModel.TaxFree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SparkleAir.Infa.Utility.UploadImgHelper;

namespace SparkleAir.FrontEnd.Site.Controllers.TaxFree
{
    [StaffAuthorize(PageName = "TFItem")]
    public class TFItemController : BaseController
    {

        ITFRepository TFRepository = new TFItemEFRepository();

        // GET: TFItem
        public ActionResult Index()
        {
            List<TFItemVm> data = Get();
            return View(data);
        }

        //public ActionResult IndexTFItem()
        //{
        //    List<TFItemVm> data = Get();
        //    return PartialView("IndexTFItem", data);
        //}


        public ActionResult Details(int id)
        {
            TFItemVm vm = Getid(id);
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
            return RedirectToAction("Index", "TFItem");
        }

        private void DeleteItem(int id)
        {
            var service = new TaxFreeService(TFRepository);
            service.Delete(id);
        }

        public ActionResult Create()
        {
            var service = new TaxFreeService(TFRepository);
            var category = service.Get();
            var data = category.Select(x => x.TFCategoriesName).Distinct().ToList();
            ViewBag.TFCategories = data;

            return View();
        }

        [HttpPost]
        public ActionResult Create(TFItemVm vm, HttpPostedFileBase file)
        {
            var service = new TaxFreeService(TFRepository);
            var category1 = service.Get();
            var data = category1.Select(x => x.TFCategoriesName).Distinct().ToList();

            ViewBag.TFCategories = data;

            string path = Server.MapPath("~/Files/Images");

            var helper = new UploadImgHelper();

            try
            {
                //UpdateItem(model);
                string result = helper.SaveAs(path, file);
                vm.Image = System.IO.Path.GetFullPath(result);
                vm.FileName = result;
                var server = new TaxFreeService(TFRepository);
                var dto = new TFItemDto
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    TFCategoriesId = vm.TFCategoriesId,
                    TFCategoriesName = vm.TFCategoriesName,
                    SerialNumber = vm.SerialNumber,
                    Image = vm.FileName,
                    Quantity = vm.Quantity,
                    UnitPrice = vm.UnitPrice,
                    Description = vm.Description,
                    IsPublished = vm.IsPublished,

                };
                var category = server.Create(dto);
                //Create(model);

                return RedirectToAction("Index", "TFItem");
            }

            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "上傳檔案失敗: " + ex.Message);

            }
            return View(vm);

            //return RedirectToAction("Index", "TFItem");
        }

        //private void CreateItem(TFItemVm vm)
        //{
        //    var service = new TaxFreeService(TFRepository);

        //    TFItemDto dto = new TFItemDto
        //    {
        //        Id = vm.Id,
        //        Name = vm.Name,
        //        TFCategoriesId = vm.TFCategoriesId,
        //        TFCategoriesName = vm.TFCategoriesName,
        //        SerialNumber = vm.SerialNumber,
        //        Image = vm.Image,
        //        Quantity = vm.Quantity,
        //        UnitPrice = vm.UnitPrice,
        //        Description = vm.Description,
        //        IsPublished = vm.IsPublished,

        //    };
        //    service.Create(dto);
        //}

        public ActionResult Edit(int id)
        {
            var TFItem = Getid(id);
            var service = new TaxFreeService(TFRepository);
            var category1 = service.Get();
            var data = category1.Select(x => x.TFCategoriesName).Distinct().ToList();
            ViewBag.TFCategories = category1;
            return View(TFItem);
        }

        //[HttpPost]
        //public ActionResult Edit(TFItemVm vm)
        //{
        //    if (!ModelState.IsValid) { return View(); }
        //    try
        //    {
        //        UpdateItem(vm);
        //        return RedirectToAction("Index");
        //    }catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, ex.Message);
        //    }
        //    return View(vm);

        //}

        [HttpPost]
        public ActionResult Edit(TFItemVm model, HttpPostedFileBase file)
        {
            var service = new TaxFreeService(TFRepository);
            var category1 = service.Get();
            //var data = category1.Select(x => x.TFCategoriesName).Distinct().ToList();
            ViewBag.TFCategories = category1;


            // save uploaded file
            string path = Server.MapPath("~/Files/Images");
            var helper = new UploadImgHelper();

            try
            {
                //UpdateItem(model);
                string result = helper.SaveAs(path, file);
                model.Image = System.IO.Path.GetFullPath(result);
                model.FileName = result;

                UpdateItem(model);
                //Create(model);

                return RedirectToAction("Index", "TFItem");
            }

            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "上傳檔案失敗: " + ex.Message);

            }

            UpdateItem(model);
            return RedirectToAction("Index", "TFItem");
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
                TFCategoriesName = vm.TFCategoriesName,
                SerialNumber = vm.SerialNumber,
                Image = vm.FileName,
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
                TFCategoriesName = dto.TFCategoriesName,
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


