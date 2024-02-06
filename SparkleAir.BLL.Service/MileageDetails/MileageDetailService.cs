using SparkleAir.BLL.Service.Members;
using SparkleAir.IDAL.IRepository.Luggage;
using SparkleAir.IDAL.IRepository.Members;
using SparkleAir.IDAL.IRepository.MileageDetails;
using SparkleAir.Infa.Criteria.Members;
using SparkleAir.Infa.Dto.Airport;
using SparkleAir.Infa.Dto.Luggage;
using SparkleAir.Infa.Dto.MileageDetails;
using SparkleAir.Infa.Entity.Airports;
using SparkleAir.Infa.Entity.Luggage;
using SparkleAir.Infa.Entity.Members;
using SparkleAir.Infa.Entity.MileageDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.MileageDetails
{
    public class MileageDetailService
    {
        private readonly IMileageDetailRepository _repo;
        private readonly IMemberRepository _mm;
        public MileageDetailService(IMileageDetailRepository repo,IMemberRepository mm) //接收IAirportRepository,方便可以使用Dapper或是EF
        {
            _repo = repo;
            _mm = mm;
        }




        //取全部
        public List<MileageDetailDto> GetAll()
        {
            List<MileageDetailEntity> entity = _repo.GetAll();

            List<MileageDetailDto> dto = entity.Select(p => new MileageDetailDto
            {

                Id = p.Id,
                MermberIsd = p.MermberIsd,
                TotalMile = p.TotalMile,
                OriginalMile = p.OriginalMile,
                ChangeMile = p.ChangeMile,
                FinalMile = p.FinalMile,
                MileValidity = p.MileValidity,
                MileReason = p.MileReason,
                OrderNumber = p.OrderNumber,
                ChangeTime = p.ChangeTime,

            }).ToList();
            return dto;
        }


        public int Create(MileageDetailDto dto)
        {
            //先取得會員
            var criteria = new MemberGetCriteria
            {
                Id = dto.MermberIsd //這裡是會員編號
            };
            var memb = _mm.Get(criteria); 

            var changemile = dto.ChangeMile >= 0 ? memb.TotalMileage+ dto.ChangeMile : memb.TotalMileage;//總里程

            var sb=_repo.Getfinalmile(dto.MermberIsd); //取得某會員的最後一筆里程紀錄

            //todo orderNumber 要寫自動帶入參數

            MileageDetailEntity entity = new MileageDetailEntity
            {
                //Id = dto.Id,
                MermberIsd = dto.MermberIsd,
                TotalMile = changemile,
                OriginalMile = sb,
                ChangeMile = dto.ChangeMile,
                FinalMile = sb+ dto.ChangeMile,
                MileValidity = DateTime.Now.AddYears(1),
                MileReason = dto.MileReason,
                OrderNumber = dto.OrderNumber,
                ChangeTime = DateTime.Now,

            };
            _repo.Create(entity);  //沒呼叫AirportEFRepository是因為AirportEFRepository有實作interface,所以呼叫_repo也就好
            
            MemberEntity member = new MemberEntity
            {
                Id = dto.MermberIsd,
                TotalMileage = changemile,
            }; 
            _mm.Update(member);
            return entity.Id;


        }


        public void Update(MileageDetailDto dto)
        {
            MileageDetailEntity entity = new MileageDetailEntity
            {
                Id = dto.Id,
                MermberIsd = dto.MermberIsd,
                TotalMile = dto.TotalMile,
                OriginalMile = dto.OriginalMile,
                ChangeMile = dto.ChangeMile,
                FinalMile = dto.FinalMile,
                MileValidity = dto.MileValidity,
                MileReason = dto.MileReason,
                OrderNumber = dto.OrderNumber,
                ChangeTime = dto.ChangeTime,
            };


            _repo.Update(entity);
        }



    }
}
