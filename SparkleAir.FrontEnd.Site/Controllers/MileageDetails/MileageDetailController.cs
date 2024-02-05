using SparkleAir.BLL.Service.Airports;
using SparkleAir.BLL.Service.Luggage;
using SparkleAir.BLL.Service.Members;
using SparkleAir.BLL.Service.MileageDetails;
using SparkleAir.DAL.EFRepository.Members;
using SparkleAir.DAL.EFRepository.MileageDetails;
using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.IDAL.IRepository.Members;
using SparkleAir.IDAL.IRepository.MileageDetails;
using SparkleAir.IDAL.IRepository.TaxFree;
using SparkleAir.Infa.Criteria.Members;
using SparkleAir.Infa.Dto.Airport;
using SparkleAir.Infa.Dto.Luggage;
using SparkleAir.Infa.Dto.MileageDetails;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.ViewModel.Airports;
using SparkleAir.Infa.ViewModel.Luggage;
using SparkleAir.Infa.ViewModel.MileageDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.MileageDetails
{
    [StaffAuthorize(PageName = "MileageDetail")]
    public class MileageDetailController : BaseController
    {

        IMileageDetailRepository efRMileage = new MileageDetailEFRepository();
        IMemberRepository memberRepo = new MemberEFRepository();
        public MileageDetailController()
        {
            
        }
        // GET: MileageDetail
        public ActionResult Index()
        {
            List<MileageDetailIndexVm> data = GetAll();
            return View(data); 
        }

        //初始自動加入會員的初始資料
        public ActionResult Example()
        {
            var ser = new MileageDetailService(efRMileage, memberRepo);
            var cc = new MemberSearchCriteria();

            var  service = new MemberService(memberRepo);
            var get =service.Search(cc);

            var db =new AppDbContext();

            foreach (var item in get)
            {
                var dd = db.MileageDetails.Where(x => x.MermberIsd == item.Id).FirstOrDefault();
                if (dd == null)
                {
                    var dto = new MileageDetailDto
                    {
                        MermberIsd = item.Id,
                        TotalMile = item.TotalMileage,
                        OriginalMile = 0,
                        ChangeMile = item.TotalMileage,
                        FinalMile = item.TotalMileage,
                        MileValidity = DateTime.Now.AddYears(1),
                        MileReason = "初始",
                        OrderNumber = "VX000",
                        ChangeTime = DateTime.Now,

                    };
                    ser.Create(dto);
                }
                else { 

                }
            }
            return View();

        }



        private void Update(MileageDetailIndexVm mileage)
        {
            var service = new MileageDetailService(efRMileage, memberRepo);
            MileageDetailDto dto = new MileageDetailDto
            {
                Id = mileage.Id,
                MermberIsd = mileage.MermberIsd,
                TotalMile = mileage.TotalMile,
                OriginalMile = mileage.OriginalMile,
                ChangeMile = mileage.ChangeMile,
                FinalMile = mileage.FinalMile,
                MileValidity = mileage.MileValidity,
                MileReason = mileage.MileReason,
                OrderNumber = mileage.OrderNumber,
                ChangeTime = mileage.ChangeTime,
            };
            service.Update(dto);
        }




        private List<MileageDetailIndexVm> GetAll()
        {
            var service = new MileageDetailService(efRMileage, memberRepo); //告訴service要用接收哪個資料庫

            List<MileageDetailDto> dto = service.GetAll();

            List<MileageDetailIndexVm> vm = dto.Select(p => new MileageDetailIndexVm
            {
                Id = p.Id,
                MermberIsd =p.MermberIsd,
                TotalMile=p.TotalMile,
                OriginalMile= p.OriginalMile,
                ChangeMile = p.ChangeMile,
                FinalMile= p.FinalMile,
                MileValidity = p.MileValidity,
                MileReason = p.MileReason,
                OrderNumber = p.OrderNumber,
                ChangeTime = p.ChangeTime,


            }).ToList();

            return vm;
        }


        #region Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MileageDetailCreateVm mileage)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                CreateMileageDetail(mileage);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(mileage);
            }
        }
        private void CreateMileageDetail(MileageDetailCreateVm mileage)
        {
            var service = new MileageDetailService(efRMileage, memberRepo); //告訴service要用接收哪個資料庫
            
            MileageDetailDto dto = new MileageDetailDto
            {
                Id = mileage.Id,
                MermberIsd = mileage.MermberIsd,
                TotalMile = 0,
                OriginalMile = mileage.OriginalMile,
                ChangeMile = mileage.ChangeMile,
                FinalMile = mileage.FinalMile,
                MileValidity = mileage.MileValidity,
                MileReason = mileage.MileReason,
                OrderNumber = mileage.OrderNumber,
                ChangeTime = mileage.ChangeTime,
            };
            service.Create(dto);
        }

        #endregion



    }
}