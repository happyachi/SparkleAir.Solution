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
    public class TFReservelistService
    {
        private readonly ITFReservelist _repo;
        public TFReservelistService(ITFReservelist repo)
        {
            _repo = repo;
        }

        public List<TFReservelistsDto> Get()
        {
            List<TFReservelistsEntity> result = _repo.Get();
            List<TFReservelistsDto> list = result.Select(x => new TFReservelistsDto
            {
                Id = x.Id,
                TFItemsId = x.TFItemsId,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice,
                Discount = x.Discount.HasValue ? x.Discount.Value : 0,
                TotalPrice = x.TotalPrice,
                TFReserveId = x.TFReserveId
            }).ToList();
            return list;
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        public int Create(TFReservelistsDto dto)
        {
            TFReservelistsEntity entity = new TFReservelistsEntity
            {
                Id = dto.Id,
                TFItemsId = dto.TFItemsId,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
                Discount = dto.Discount,
                TotalPrice = dto.TotalPrice,
                TFReserveId = dto.TFReserveId
            };
            _repo.Create(entity);
            return entity.Id;
        }

        public void Update(TFReservelistsDto dto)
        {
            TFReservelistsEntity entity = new TFReservelistsEntity
            {
                Id = dto.Id,
                TFItemsId = dto.TFItemsId,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
                Discount = dto.Discount,
                TotalPrice = dto.TotalPrice,
            };
            _repo.Update(entity);
        }

        public TFReservelistsDto Getid(int Id)
        {
            TFReservelistsEntity entity = _repo.Getid(Id);
            TFReservelistsDto dto = new TFReservelistsDto
            {
                Id = entity.Id,
                TFItemsId = entity.TFItemsId,
                Quantity = entity.Quantity,
                UnitPrice = entity.UnitPrice,
                Discount = entity.Discount.HasValue ? entity.Discount.Value : 0,
                TotalPrice = entity.TotalPrice,
            };
            
            return dto;

        }
    }
}
