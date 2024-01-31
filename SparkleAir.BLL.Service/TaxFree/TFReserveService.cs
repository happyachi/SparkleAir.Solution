using SparkleAir.IDAL.IRepository.TaxFree;
using SparkleAir.Infa.Dto.TaxFree;
using SparkleAir.Infa.Entity.TaxFree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.TaxFree
{
    public class TFReserveService
    {
        private readonly ITFReserve _repo;

        public TFReserveService(ITFReserve repo)
        {
            _repo = repo;
        }

        public List<TFReservesDto> Get()
        {
            List<TFReservesEntity> result = _repo.Get();
            List<TFReservesDto> list = result.Select(x => new TFReservesDto
            {
                Id = x.Id,
                MemberId = x.MemberId,
                Discount= x.Discount.HasValue ? x.Discount.Value : 0,
                TotalPrice = x.TotalPrice,
                TransferPaymentId = x.TransferPaymentId


            }).ToList();
            return list;
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }
        public int Create(TFReservesDto dto)
        {
            TFReservesEntity entity = new TFReservesEntity
            {
                Id = dto.Id,
                MemberId = dto.MemberId,
                Discount = dto.Discount,
                TotalPrice = dto.TotalPrice,
                TransferPaymentId = dto.TransferPaymentId

            };
            _repo.Create(entity);
            return entity.Id;
        }

        public void Update(TFReservesDto dto)
        {
            TFReservesEntity entity = new TFReservesEntity
            {

                Id = dto.Id,
                MemberId = dto.MemberId,
                Discount = dto.Discount,
                TotalPrice = dto.TotalPrice,
                TransferPaymentId = dto.TransferPaymentId
            };
            _repo.Update(entity);
        }

        public TFReservesDto Getid(int Id)
        {
            TFReservesEntity entity = _repo.Getid(Id);

            TFReservesDto dto = new TFReservesDto

            {
                Id = entity.Id,
                MemberId = entity.MemberId,
                Discount = entity.Discount.HasValue ? entity.Discount.Value : 0,
                TotalPrice = entity.TotalPrice,
                TransferPaymentId = entity.TransferPaymentId

            };

            return dto;
        }

    }



}

