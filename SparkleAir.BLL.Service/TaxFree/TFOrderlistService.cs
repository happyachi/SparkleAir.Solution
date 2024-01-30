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
    public class TFOrderlistService
    {
        private readonly ITFOrderRepository _repository;

        public TFOrderlistService(ITFOrderRepository repository)
        {
            _repository = repository;
        }

        public List<TFOrderlistsDto> Get()
        {
            List<TFOrderlistsEntity> result = _repository.Get();
            List<TFOrderlistsDto> list = result.Select(x => new TFOrderlistsDto
            {
                Id = x.Id,
                MemberId = x.MemberId,
                TFItemsId = x.TFItemsId,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice
                
            }).ToList();
            return list;
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

        public int Create(TFOrderlistsDto dto)
        {
            TFOrderlistsEntity entity = new TFOrderlistsEntity
            {
                Id = dto.Id,
                MemberId = dto.MemberId,
                TFItemsId = dto.TFItemsId,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice
            };
             _repository.Create(entity);
            return entity.Id;
        }

        public void Update(TFOrderlistsDto dto)
        {
            TFOrderlistsEntity entity = new TFOrderlistsEntity
            {
                Id = dto.Id,
                MemberId = dto.MemberId,
                TFItemsId = dto.TFItemsId,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice
            };


            _repository.Update(entity);
        }

        public TFOrderlistsDto Getid(int Id)
        {
            TFOrderlistsEntity entity = _repository.Getid(Id);
            TFOrderlistsDto dto = new TFOrderlistsDto
            {
                Id = entity.Id,
                MemberId = entity.MemberId,
                TFItemsId = entity.TFItemsId,
                Quantity = entity.Quantity,
                UnitPrice = entity.UnitPrice
            };
            return dto;
        }

    }
}
