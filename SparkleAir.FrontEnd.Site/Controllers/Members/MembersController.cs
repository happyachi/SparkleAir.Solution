using Microsoft.Ajax.Utilities;
using SparkleAir.BLL.Service.Members;
using SparkleAir.DAL.DapperRepository.Members;
using SparkleAir.DAL.EFRepository.Members;
using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.IDAL.IRepository.Members;
using SparkleAir.Infa.Criteria.Members;
using SparkleAir.Infa.Dto.Members;
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
    [StaffAuthorize(PageName = "Members")]
    public class MembersController : BaseController
    {
		private readonly IMemberRepository _repo;
		private readonly MemberService _service;
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
            return View();
        }


        public ActionResult Index1()
        {
            MemberSearchCriteria criteria = null;

            var dtoList = _service.Search(criteria);
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

			return PartialView("Index1",vmList);
        }

        public ActionResult Details(int id)
		{
            if (!ModelState.IsValid) return RedirectToAction("Index");

            try
            {
                MemberGetCriteria criteria = new MemberGetCriteria()
                {
                    Id = id
                };

                MemberIndexVm memberVm = GetMember(criteria);
                return View(memberVm);
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
                MemberGetCriteria criteria = new MemberGetCriteria()
                {
                    Id = id
                };

                MemberUpdateVm memberVm = GetUpdateMember(criteria);
                return View(memberVm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(MemberUpdateVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                UpdateMember(vm);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vm);
            }
        }

        private void UpdateMember(MemberUpdateVm vm)
        {
            MemberDto dto = new MemberDto()
            {
                Id = vm.Id,
                IsAllow = vm.IsAllow
            };

            _service.Update(dto);
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
                PassportNumber = member.PassportNumber,
            };

            return vm;
        }

        public MemberUpdateVm GetUpdateMember(MemberGetCriteria criteria)
        {
            var member = _service.Get(criteria);
            var vm = new MemberUpdateVm
            {
                Id = member.Id,
                IsAllow = member.IsAllow
            };

            return vm;
        }


    }
}