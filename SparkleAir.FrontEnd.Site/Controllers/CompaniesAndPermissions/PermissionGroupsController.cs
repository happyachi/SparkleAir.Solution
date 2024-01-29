﻿using SparkleAir.BLL.Service.CompanyAndPermission;
using SparkleAir.DAL.EFRepository.CompanyAndPermission;
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
    public class PermissionGroupsController : Controller
    {
        private readonly PermissionGroupService _service;
        private readonly IPermissionGroupRepository _repo;

        public PermissionGroupsController()
        {
            _repo = new PermissionGroupEFRepository();
            _service = new PermissionGroupService(_repo);
        }

        // GET: PermissionGroups
        public ActionResult Index()
        {
            var dto = _service.Search();
            var vm = dto.Select(p => new PermissionGroupIndexVm
            {
                Id = p.Id,
                Name = p.Name,
                Ddescribe = p.Ddescribe,
                Criteria = p.Criteria

            }).ToList();

            return View(vm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PermissionGroupIndexVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var dto = new PermissionGroupDto()
                {
                    Name = vm.Name,
                    Ddescribe = vm.Ddescribe,
                    Criteria = vm.Criteria
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

                var vm = new PermissionGroupIndexVm
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Ddescribe = dto.Ddescribe,
                    Criteria = dto.Criteria
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
        public ActionResult Edit(PermissionGroupIndexVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var dto = new PermissionGroupDto()
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    Ddescribe = vm.Ddescribe,
                    Criteria = vm.Criteria
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