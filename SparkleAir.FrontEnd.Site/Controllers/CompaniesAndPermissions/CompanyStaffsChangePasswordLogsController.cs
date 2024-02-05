using SparkleAir.BLL.Service.CompanyAndPermission;
using SparkleAir.DAL.EFRepository.CompanyAndPermission;
using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using SparkleAir.Infa.ViewModel.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.CompaniesAndPermissions
{
    [StaffAuthorize(PageName = "CompanyStaffsChangePasswordLogs")]
    public class CompanyStaffsChangePasswordLogsController : BaseController
    {
        private readonly ICompanyStaffsChangePasswordLogRepository _repo;
        private readonly CompanyStaffsChangePasswordLogService _service;

        public CompanyStaffsChangePasswordLogsController()
        {
            _repo = new CompanyStaffsChangePasswordLogEFRepository();
            _service = new CompanyStaffsChangePasswordLogService(_repo);
        }


        // GET: CompanyStaffsChangePasswordLogs
        public ActionResult Index()
        {
            var dto = _service.Search();
            var vm = dto.Select(c => new CompanyStaffsChangePasswordLogIndexVm
            {
                Id = c.Id,
                CompanyStaffId = c.CompanyStaffId,
                CompanyStaffName = c.CompanyStaffName,
                UpdateTime = c.UpdateTime

            }).ToList();

            return View(vm);
        }
    }
}