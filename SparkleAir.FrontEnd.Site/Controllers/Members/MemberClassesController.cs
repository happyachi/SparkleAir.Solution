using SparkleAir.BLL.Service.Members;
using SparkleAir.DAL.EFRepository.Members;
using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.IDAL.IRepository.Members;
using SparkleAir.Infa.Criteria.Members;
using SparkleAir.Infa.Dto.CompanyAndPermission;
using SparkleAir.Infa.Dto.Members;
using SparkleAir.Infa.ViewModel.CompanyAndPermission;
using SparkleAir.Infa.ViewModel.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.Members
{
    [StaffAuthorize(PageName = "MemberClasses")]
    public class MemberClassesController : BaseController
    {
        private readonly MemberClassService _service;
        private readonly IMemberClassRepository _repo;

        public MemberClassesController()
        {
            _repo = new MemberClassEFRepository();
            _service = new MemberClassService(_repo);
        }

        // GET: MemberClasses
        public ActionResult Index()
        {
            var dtos = _service.Search();
            var vm = dtos.Select(member => new MemberClassIndexVm
            {
                Id = member.Id,
                Name = member.Name,
                ClassOrder = member.ClassOrder,
                MileageStart = member.MileageStart,
                MileageEnd = member.MileageEnd

            }).ToList();

            return View(vm);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MemberClassIndexVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var dto = new MemberClassDto()
                {
                    Name = vm.Name,
                    ClassOrder = vm.ClassOrder,
                    MileageStart = vm.MileageStart,
                    MileageEnd = vm.MileageEnd
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

        public ActionResult Edit(int id)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");

            try
            {
                var dto = _service.Get(id);

                var vm = new MemberClassIndexVm
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    ClassOrder = dto.ClassOrder,
                    MileageStart = dto.MileageStart,
                    MileageEnd = dto.MileageEnd
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
        public ActionResult Edit(MemberClassIndexVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                var dto = new MemberClassDto
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    ClassOrder = vm.ClassOrder,
                    MileageStart = vm.MileageStart,
                    MileageEnd = vm.MileageEnd
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