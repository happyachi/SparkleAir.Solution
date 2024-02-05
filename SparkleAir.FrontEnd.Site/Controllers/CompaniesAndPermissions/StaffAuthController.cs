using SparkleAir.BLL.Service.CompanyAndPermission;
using SparkleAir.DAL.EFRepository.CompanyAndPermission;
using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using SparkleAir.Infa.Criteria.CompanyAndPermission;
using SparkleAir.Infa.ViewModel.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;

namespace SparkleAir.FrontEnd.Site.Controllers.CompaniesAndPermissions
{
    public class StaffAuthController : BaseController
    {
        private readonly StaffAuthService _service;
        private readonly ICompanyStaffRepository _repo;
        private readonly IPermissionGroupsAddStaffRepository _groupAddStaffRepo;

        public StaffAuthController()
        {
            _repo = new CompanyStaffEFRepository();
            _groupAddStaffRepo = new PermissionGroupsAddStaffEFRepository();
            _service = new StaffAuthService(_repo, _groupAddStaffRepo);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(CompanyStaffLoginVm vm)
        {
            if (!ModelState.IsValid) { return View(); }

            try
            {
                var criteria = new CompanyStaffGetCriteria
                {
                    Account = vm.Account,
                    Password = vm.Password
                };

                var processResult = _service.Login(criteria); // 將相關資訊(如帳號)準備好並回傳

                Response.Cookies.Add(processResult.Cookie);  // 將回傳的 cookie 加到 Browser

                return Redirect(processResult.ReturnUrl); // 轉向到他原本應該去的網址

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vm);
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return Redirect("/StaffAuth/Login");
        }
        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}