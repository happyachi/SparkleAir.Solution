using SparkleAir.BLL.Service.CompanyAndPermission;
using SparkleAir.DAL.EFRepository.CompanyAndPermission;
using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using SparkleAir.Infa.Criteria.CompanyAndPermission;
using SparkleAir.Infa.Dto.CompanyAndPermission;
using SparkleAir.Infa.ViewModel.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.CompaniesAndPermissions
{
    [StaffAuthorize(PageName = "PermissionPageInfos")]
    public class PermissionPageInfosController : BaseController
    {
        private readonly IPermissionPageInfoRepository _repo;
        private readonly PermissionPageInfoService _service;

        public PermissionPageInfosController()
        {
            _repo = new PermissionPageInfoEFRepository();
            _service = new PermissionPageInfoService(_repo);
        }

        // GET: PermissionPageInfos
        public ActionResult Index()
        {
            var dto = _service.Search();
            var vm = dto.Select(p => new PermissionPageInfoIndexVm
            {
                Id = p.Id,
                PageNumber = p.PageNumber,
                PageName = p.PageName,
                PageDescription = p.PageDescription
            }).ToList();

            return View(vm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PermissionPageInfoIndexVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var dto = new PermissionPageInfoDto()
                {
                    PageNumber = vm.PageNumber,
                    PageName = vm.PageName,
                    PageDescription = vm.PageDescription
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

                var vm = new PermissionPageInfoIndexVm
                {
                    Id = dto.Id,
                    PageNumber = dto.PageNumber,
                    PageName = dto.PageName,
                    PageDescription = dto.PageDescription
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
        public ActionResult Edit(PermissionPageInfoIndexVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var dto = new PermissionPageInfoDto()
                {
                    Id = vm.Id,
                    PageNumber = vm.PageNumber,
                    PageName = vm.PageName,
                    PageDescription = vm.PageDescription
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