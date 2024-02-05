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
using System.Web.Security;
using System.Web.UI.WebControls;

namespace SparkleAir.FrontEnd.Site.Controllers.CompaniesAndPermissions
{
    [StaffAuthorize(PageName = "CompanyStaffs")]
    public class CompanyStaffsController : BaseController
    {
        private readonly CompanyStaffService _service;
        private readonly CompanyJobService _companyJobService;
        private readonly ICompanyStaffRepository _repo; 
        private readonly ICompanyJobRepository _companyJobRepo;

        public CompanyStaffsController()
        {
            _repo = new CompanyStaffEFRepository();
            _service = new CompanyStaffService(_repo);

            _companyJobRepo = new CompanyJobEFRepository();
            _companyJobService = new CompanyJobService(_companyJobRepo);
        }

        // GET: CompanyStaffs
        public ActionResult Index()
        {
            var dto = _service.Search();
            var vm = dto.Select(c => new CompanyStaffIndexVm
            {
                Id = c.Id,
                Account = c.Account,
                Password = c.Password,
                FirstName = c.FirstName,
                LastName = c.LastName,
                CompanyJobId = c.CompanyJobId,
                CompanyDepartmentName = c.CompanyDepartmentName,
                JobTitle = c.JobTitle,
                Status = c.Status,
                RegistrationTime = c.RegistrationTime
            }).ToList();

            return View(vm);
        }

        public ActionResult Create()
        {

            ViewBag.CompanyJobs = _companyJobService.Search().Select(c=> new CompanyJobIndexVm
            {
                Id = c.Id,
                CompanyDepartmentName = c.CompanyDepartmentName,
                JobTitle = c.JobTitle
            }).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Create(CompanyStaffCreateVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var dto = new CompanyStaffDto()
                {
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    CompanyJobId = vm.CompanyJobId,
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

        public ActionResult Details(int id)
		{
            if (!ModelState.IsValid) return RedirectToAction("Index");

            try
            {
                CompanyStaffGetCriteria criteria = new CompanyStaffGetCriteria
                {
                    Id = id
                };
                var dto = _service.Get(criteria);

                var vm = new CompanyStaffIndexVm
                {
                    Id = dto.Id,
                    Account = dto.Account,
                    Password = dto.Password,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    CompanyJobId = dto.CompanyJobId,
                    CompanyDepartmentName = dto.CompanyDepartmentName,
                    JobTitle = dto.JobTitle,
                    Status = dto.Status,
                    RegistrationTime = dto.RegistrationTime
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");

            try
            {
                CompanyStaffGetCriteria criteria = new CompanyStaffGetCriteria
                {
                    Id = id
                };
                var dto = _service.Get(criteria);

                var vm = new CompanyStaffIndexVm
                {
                    Id = dto.Id,
                    Account = dto.Account,
                    Password = dto.Password,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    CompanyJobId = dto.CompanyJobId,
                    CompanyDepartmentName = dto.CompanyDepartmentName,
                    JobTitle = dto.JobTitle,
                    Status = dto.Status,
                    RegistrationTime = dto.RegistrationTime
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
        public ActionResult Edit(CompanyStaffIndexVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var dto = new CompanyStaffDto()
                {
                    Id = vm.Id,
                    Account = vm.Account,
                    Password = vm.Password,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    CompanyJobId = vm.CompanyJobId,
                    CompanyDepartmentName = vm.CompanyDepartmentName,
                    JobTitle = vm.JobTitle,
                    Status = vm.Status,
                    RegistrationTime = vm.RegistrationTime
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
