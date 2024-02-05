using SparkleAir.BLL.Service.CompanyAndPermission;
using SparkleAir.DAL.EFRepository.CompanyAndPermission;
using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using SparkleAir.Infa.Dto.CompanyAndPermission;
using SparkleAir.Infa.ViewModel.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.CompaniesAndPermissions
{
    [StaffAuthorize(PageName = "CompanyJobs")]
    public class CompanyJobsController : BaseController
    {
        private readonly CompanyJobService _service;
        private readonly ICompanyJobRepository _repo;

        public CompanyJobsController()
        {
            _repo = new CompanyJobEFRepository();
            _service = new CompanyJobService(_repo);
        }

        // GET: CompanyJobs
        public ActionResult Index()
        {
            var dto = _service.Search();
            var vm = dto.Select(c => new CompanyJobIndexVm
            {
                Id = c.Id,
                CompanyDepartmentId = c.CompanyDepartmentId,
                CompanyDepartmentName = c.CompanyDepartmentName,
                JobTitle = c.JobTitle,
                Rank = c.Rank
            }).ToList();

            return View(vm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CompanyJobIndexVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var dto = new CompanyJobDto()
                {
                    CompanyDepartmentId = vm.CompanyDepartmentId,
                    CompanyDepartmentName = vm.CompanyDepartmentName,
                    JobTitle = vm.JobTitle,
                    Rank = vm.Rank
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

                var vm = new CompanyJobIndexVm
                {
                    Id = dto.Id,
                    CompanyDepartmentId = dto.CompanyDepartmentId,
                    CompanyDepartmentName = dto.CompanyDepartmentName,
                    JobTitle = dto.JobTitle,
                    Rank = dto.Rank
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
        public ActionResult Edit(CompanyJobIndexVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var dto = new CompanyJobDto
                {
                    Id = vm.Id,
                    CompanyDepartmentId = vm.CompanyDepartmentId,
                    CompanyDepartmentName = vm.CompanyDepartmentName,
                    JobTitle = vm.JobTitle,
                    Rank = vm.Rank
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