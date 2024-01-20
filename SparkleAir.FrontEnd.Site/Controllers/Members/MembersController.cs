using SparkleAir.BLL.Service.Members;
using SparkleAir.DAL.DapperRepository.Members;
using SparkleAir.DAL.EFRepository.Members;
using SparkleAir.FrontEnd.Site.Models.ViewModels.Members;
using SparkleAir.IDAL.IRepository.Members;
using SparkleAir.Infa.EFModel.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.Members
{
    public class MembersController : Controller
    {
		private IMemberRepository _repo;
		private MemberService _service;
		public MembersController()
        {
			// EF
			// _repo = new MemberEFRepository(); 

			// Dapper
			_repo = new MemberDapperRepository(); 

			_service = new MemberService(_repo);
		}
        // GET: Members
        public ActionResult Index()
        {
            var dtoList = _service.GetAll();
            var vmList = dtoList.Select(x => new MemberIndexVm
            {
				Id = x.Id,
				MemberClassId = x.MemberClassId,
				CountryId = x.CountryId,
				ChineseLastName = x.ChineseLastName,
				ChineseFirstName = x.ChineseFirstName,
				EnglishLastName = x.EnglishLastName,
				EnglishFirstName = x.EnglishFirstName,
				DateOfBirth = x.DateOfBirth,
				Gender = x.Gender,
				Phone = x.Phone,
				Email = x.Email,
				TotalMileage = x.TotalMileage,
				PassportNumber = x.PassportNumber
			}).ToList();

			return View(vmList);
        }
    }
}