using SparkleAir.BLL.Service.Basics;
using SparkleAir.DAL.EFRepository.Basics;
using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.IDAL.IRepository.Basics;
using SparkleAir.Infa.Dto.Basics;
using SparkleAir.Infa.Dto.CompanyAndPermission;
using SparkleAir.Infa.ViewModel.Basics;
using SparkleAir.Infa.ViewModel.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.Basics
{
    [StaffAuthorize(PageName = "Countries")]
    public class CountriesController : BaseController
    {
        private readonly CountryService _service;
        private readonly ICountryRepository _repo;

        public CountriesController()
        {
            _repo = new CountryEFRepository();
            _service = new CountryService(_repo);
        }
        // GET: Countries
        public ActionResult Index()
        {
           var  dtos = _service.Search();
            var vm = dtos.Select(dto => new CountryIndexVm
            {
                Id = dto.Id,
                ChineseName = dto.ChineseName,
                EnglishName = dto.EnglishName
            })
            .ToList();

            return View(vm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CountryIndexVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var dto = new CountryDto()
                {
                    ChineseName = vm.ChineseName,
                    EnglishName = vm.EnglishName
                };
                _service.Create(dto);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vm);
            }
        }

        public ActionResult Edit(int id)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");

            try
            {
                var dto = _service.Get(id);

                var vm = new CountryIndexVm
                {
                    Id = dto.Id,
                    ChineseName = dto.ChineseName,
                    EnglishName = dto.EnglishName
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(CountryIndexVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var dto = new CountryDto
                {
                    Id = vm.Id,
                    ChineseName = vm.ChineseName,
                    EnglishName = vm.EnglishName
                };

                _service.Update(dto);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vm);
            }
        }

        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");

            try
            {
                _service.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}