using SparkleAir.BLL.Service.CompanyAndPermission;
using SparkleAir.DAL.EFRepository.CompanyAndPermission;
using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using SparkleAir.Infa.Criteria.CompanyAndPermission;
using SparkleAir.Infa.Dto.CompanyAndPermission;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.ViewModel.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.CompaniesAndPermissions
{
    [StaffAuthorize(PageName = "PermissionSettings")]
    public class PermissionSettingsController : BaseController
    {
        private readonly PermissionSettingService _service;
        private readonly IPermissionSettingRepository _repo;

        public PermissionSettingsController()
        {
            _repo = new PermissionSettingEFRepository();
            _service = new PermissionSettingService(_repo);
        }

        // GET: PermissionSettings
        public ActionResult Index()
        {
            var dtos = _service.Search();
            var vm = dtos.Select(dto => new PermissionSettingIndexVm
            {
                Id = dto.Id,
                PermissionGroupsId = dto.PermissionGroupsId,
                PermissionGroupsName = dto.PermissionGroupsName,
                PermissionPageInfoId = dto.PermissionPageInfoId,
                PermissionPageInfoName = dto.PermissionPageInfoName,
                ViewPermission = dto.ViewPermission,
                EditPermission = dto.EditPermission,
                DeletePermission = dto.DeletePermission,
                CreatePermission = dto.CreatePermission
            }).ToList();

            return View(vm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PermissionSettingIndexVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var dto = new PermissionSettingDto()
                {
                    PermissionGroupsId = vm.PermissionGroupsId,
                    PermissionGroupsName = vm.PermissionGroupsName,
                    PermissionPageInfoId = vm.PermissionPageInfoId,
                    PermissionPageInfoName = vm.PermissionPageInfoName,
                    ViewPermission = vm.ViewPermission,
                    EditPermission = vm.EditPermission,
                    DeletePermission = vm.DeletePermission,
                    CreatePermission = vm.CreatePermission
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

                var vm = new PermissionSettingIndexVm
                {
                    Id = dto.Id,
                    PermissionGroupsId = dto.PermissionGroupsId,
                    PermissionGroupsName = dto.PermissionGroupsName,
                    PermissionPageInfoId = dto.PermissionPageInfoId,
                    PermissionPageInfoName = dto.PermissionPageInfoName,
                    ViewPermission = dto.ViewPermission,
                    EditPermission = dto.EditPermission,
                    DeletePermission = dto.DeletePermission,
                    CreatePermission = dto.CreatePermission
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
        public ActionResult Edit(PermissionSettingIndexVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var dto = new PermissionSettingDto()
                {
                    Id = vm.Id,
                    PermissionGroupsId = vm.PermissionGroupsId,
                    PermissionGroupsName = vm.PermissionGroupsName,
                    PermissionPageInfoId = vm.PermissionPageInfoId,
                    PermissionPageInfoName = vm.PermissionPageInfoName,
                    ViewPermission = vm.ViewPermission,
                    EditPermission = vm.EditPermission,
                    DeletePermission = vm.DeletePermission,
                    CreatePermission = vm.CreatePermission
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