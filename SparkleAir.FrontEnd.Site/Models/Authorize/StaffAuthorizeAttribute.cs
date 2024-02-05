using SparkleAir.BLL.Service.CompanyAndPermission;
using SparkleAir.DAL.EFRepository.CompanyAndPermission;
using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace SparkleAir.FrontEnd.Site.Models.Authorize
{
    public class StaffAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        public string PageName { get; set; }

        private readonly IPermissionSettingRepository _settingRepo;
        private readonly PermissionSettingService _settingService;
        public StaffAuthorizeAttribute()
        {

            _settingRepo = new PermissionSettingEFRepository();
            _settingService = new PermissionSettingService(_settingRepo);
        }

        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                FormsIdentity identity = (FormsIdentity)filterContext.HttpContext.User.Identity;
                var userData = identity.Ticket.UserData.Split(',');

                StaffPrincipal currentUser = new StaffPrincipal(identity, userData);

                // 如果沒有指定權限，就不用檢查，直接通過
                if (string.IsNullOrEmpty(PageName)) return;

                // 這邊要透過groups(頁面名稱)去資料庫 找到頁面的權限
                // 把跟頁面關聯的group放到 allowedGroups
                var allowedGroups = _settingService.GetAllowGroupIdsByPageName(PageName);


                // 如果有指定權限，則檢查是否有權限
                if (allowedGroups.Any(x => currentUser.IsInRole(x)))
                {
                    return;
                }
                else
                {
                    // filterContext.Result = new System.Web.Mvc.HttpStatusCodeResult(403);

                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(
                            new
                            {
                                controller = "StaffAuth",
                                action = "Unauthorized"
                            })
                    );
                }

            }

            base.OnAuthorization(filterContext);
        }

    }
}