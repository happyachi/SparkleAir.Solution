using SparkleAir.BLL.Service.CompanyAndPermission;
using SparkleAir.DAL.EFRepository.CompanyAndPermission;
using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using SparkleAir.Infa.ViewModel.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.CompaniesAndPermissions
{
    [StaffAuthorize(PageName = "CompanyStaffLoginLogs")]
    public class CompanyStaffLoginLogsController : BaseController
    {
        private readonly CompanyStaffLoginLogService _service;
        private readonly ICompanyStaffLoginLogRepository _repo;

        public CompanyStaffLoginLogsController()
        {
            _repo = new CompanyStaffLoginLogEFRepository();
            _service = new CompanyStaffLoginLogService(_repo);
        }
        // GET: CompanyStaffLoginLogs
        public ActionResult Index()
        {
            var dto = _service.Search();
            var vm = dto.Select(c => new CompanyStaffLoginLogIndexVm
            {
                Id = c.Id,
                CompanyStaffId = c.CompanyStaffId,
                CompanyStaffName = c.CompanyStaffName,
                LoginTime = c.LoginTime,
                LogoutTime = c.LogoutTime,
                IPAddress = c.IPAddress,
                LoginStatus = c.LoginStatus
            }).ToList();

            return View(vm);
        }
    }
}