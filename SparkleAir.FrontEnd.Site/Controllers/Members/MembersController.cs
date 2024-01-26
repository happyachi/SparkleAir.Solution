using Microsoft.Ajax.Utilities;
using SparkleAir.BLL.Service.Members;
using SparkleAir.DAL.DapperRepository.Members;
using SparkleAir.DAL.EFRepository.Members;
using SparkleAir.IDAL.IRepository.Members;
using SparkleAir.Infa.Criteria.Members;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.ViewModel.Members;
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
			_repo = new MemberEFRepository(); 

			// Dapper
			// _repo = new MemberDapperRepository(); 

			_service = new MemberService(_repo);
		}
        // GET: Members
        public ActionResult Index()
        {
            var dtoList = _service.GetAll();
            var vmList = dtoList.Select(member => new MemberIndexVm
            {
                Id = member.Id,
                MemberClassId = member.MemberClassId,
                MemberClassName = member.MemberClassName,
                CountryId = member.CountryId,
                CountryName = member.CountryName,
                ChineseLastName = member.ChineseLastName,
                ChineseFirstName = member.ChineseFirstName,
                EnglishLastName = member.EnglishLastName,
                EnglishFirstName = member.EnglishFirstName,
                DateOfBirth = member.DateOfBirth,
                Gender = member.Gender,
                Phone = member.Phone,
                Email = member.Email,
                TotalMileage = member.TotalMileage,
                PassportNumber = member.PassportNumber
            }).ToList();

			return View(vmList);
        }

        public ActionResult Get(int id)
		{
            if (!ModelState.IsValid) return View();

            try
            {
                MemberGetCriteria criteria = new MemberGetCriteria();
                criteria.Id = id;

                MemberIndexVm memberVm = GetMember(criteria);
                return View(memberVm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(MemberIndexVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                EditMember(vm);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vm);
            }
        }

        private void EditMember(MemberIndexVm vm)
        {
            throw new NotImplementedException();
        }

        public MemberIndexVm GetMember(MemberGetCriteria criteria)
        {
            var member = _service.Get(criteria);
            var vm = new MemberIndexVm
            {
                Id = member.Id,
                MemberClassId = member.MemberClassId,
                MemberClassName = member.MemberClassName,
                CountryId = member.CountryId,
                CountryName = member.CountryName,
                ChineseLastName = member.ChineseLastName,
                ChineseFirstName = member.ChineseFirstName,
                EnglishLastName = member.EnglishLastName,
                EnglishFirstName = member.EnglishFirstName,
                DateOfBirth = member.DateOfBirth,
                Gender = member.Gender,
                Phone = member.Phone,
                Email = member.Email,
                TotalMileage = member.TotalMileage,
                PassportNumber = member.PassportNumber
            };

            return vm;
        }


    }
}