using SparkleAir.BLL.Service.Members;
using SparkleAir.DAL.EFRepository.Members;
using SparkleAir.IDAL.IRepository.Members;
using SparkleAir.Infa.Criteria.Members;
using SparkleAir.Infa.ViewModel.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SparkleAir.FrontEnd.Site.Controllers.Members
{
    public class MemberLoginLogsController : Controller
    {
        private readonly IMemberLoginLogRepository _repo;

        private MemberLoginLogService _service;
        public MemberLoginLogsController()
        {
            _repo = new MemberLoginLogEFRepository();
            _service = new MemberLoginLogService(_repo);
        }


        // GET: MemberLoginLogs

        public ActionResult Index()
        {
            MemberLoginLogSearchCriteria criteria = null;
            var dto = _service.Search(criteria);

            var vm = dto.Select(member => new MemberLoginLogIndexVm
            {
                Id = member.Id,
                MemberId = member.MemberId,
                Logintime = member.Logintime,
                LogoutTime = member.LogoutTime,
                IPAddress = member.IPAddress,
                LoginStatus = member.LoginStatus

            }).ToList();

            return View(vm);
        }
    }
}