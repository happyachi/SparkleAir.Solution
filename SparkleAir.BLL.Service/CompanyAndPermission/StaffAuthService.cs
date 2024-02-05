using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using SparkleAir.Infa.Criteria.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web;
using SparkleAir.Infa.Utility.Helper;

namespace SparkleAir.BLL.Service.CompanyAndPermission
{
    public class StaffAuthService
    {
        private readonly ICompanyStaffRepository _repo;
        private readonly IPermissionGroupsAddStaffRepository _groupAddStaffRepo;
        public StaffAuthService(ICompanyStaffRepository repo, IPermissionGroupsAddStaffRepository groupAddStaffRepo)
        {
            _repo = repo;
            _groupAddStaffRepo = groupAddStaffRepo;
        }

        public (string ReturnUrl, HttpCookie Cookie) Login(CompanyStaffGetCriteria criteria)
        {
            var entity = _repo.Get(criteria);
            if (entity == null) throw new Exception("帳號或密碼錯誤");

            var salt = HashHelper.GetSalt(); // 取得salt
            var hashPassword = HashHelper.ToSHA256(criteria.Password, salt); // 密碼加密
            var encryptPassword = entity.Password.Trim();

            // 等於0，表示密碼相同，  不等於0，表示不同
            if (string.Compare(encryptPassword, hashPassword, true) != 0) //true不拘大小寫
            {
                throw new Exception("帳號或密碼錯誤");
            }

            // 找出員工所在的群組
            var groupAddStaffList = _groupAddStaffRepo.SearchByStaffId(entity.Id);
            var groups = string.Empty;
            if (groupAddStaffList != null)
            {
                groups = string.Join(",", groupAddStaffList.Select(x => x.PermissionGroupsId));
            }

            return ProcessLogin(criteria, groups);
        }

        private (string ReturnUrl, HttpCookie Cookie) ProcessLogin(CompanyStaffGetCriteria criteria, string groups) // value tuple 元組
        {
            var rememberMe = false; // 如果LoginVm有RememberMe屬性, 記得要設定
            var account = criteria.Account;

            // 建立一張認證票
            var ticket =
                new FormsAuthenticationTicket(
                    1,          // 版本別, 沒特別用處
                    account,
                    DateTime.Now,   // 發行日
                    DateTime.Now.AddMinutes(30), // 到期日
                    rememberMe,     // 是否續存
                    groups,          // userdata角色權限
                    "/" // cookie位置
                );
            // 將它加密
            var value = FormsAuthentication.Encrypt(ticket);
            // 存入cookie
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, value);
            // 取得return url
            var url = FormsAuthentication.GetRedirectUrl(account, true); //第二個引數沒有用處
            return (url, cookie);
        }


    }
}
