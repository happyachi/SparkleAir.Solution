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
    [StaffAuthorize(PageName = "PermissionGroupsAddStaffs")]
    public class PermissionGroupsAddStaffsController : BaseController
    {
        private readonly PermissionGroupsAddStaffService _service ;
        private readonly IPermissionGroupsAddStaffRepository _repo;

        public PermissionGroupsAddStaffsController()
        {
            _repo = new PermissionGroupsAddStaffEFRepository();
            _service = new PermissionGroupsAddStaffService(_repo);
        }

        // GET: PermissionGroupsAddStaffs
        public ActionResult Index()
        {
            var dto = _service.Search();
            var vm = dto.Select(p => new PermissionGroupsAddStaffIndexVm
            {
                Id = p.Id,
                PermissionGroupsId = p.PermissionGroupsId,
                PermissionGroupsName = p.PermissionGroupsName,
                CompanyStaffsId = p.CompanyStaffsId,
                CompanyStaffsName = p.CompanyStaffsName
            }).ToList();

            return View(vm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PermissionGroupsAddStaffIndexVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var dto = new PermissionGroupsAddStaffDto()
                {
                    PermissionGroupsId = vm.PermissionGroupsId,
                    PermissionGroupsName = vm.PermissionGroupsName,
                    CompanyStaffsId = vm.CompanyStaffsId,
                    CompanyStaffsName = vm.CompanyStaffsName
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

                var vm = new PermissionGroupsAddStaffIndexVm
                {
                    Id = dto.Id,
                    PermissionGroupsId = dto.PermissionGroupsId,
                    PermissionGroupsName = dto.PermissionGroupsName,
                    CompanyStaffsId = dto.CompanyStaffsId,
                    CompanyStaffsName = dto.CompanyStaffsName
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
        public ActionResult Edit(PermissionGroupsAddStaffIndexVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var dto = new PermissionGroupsAddStaffDto()
                {
                    Id = vm.Id,
                    PermissionGroupsId = vm.PermissionGroupsId,
                    PermissionGroupsName = vm.PermissionGroupsName,
                    CompanyStaffsId = vm.CompanyStaffsId,
                    CompanyStaffsName = vm.CompanyStaffsName
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