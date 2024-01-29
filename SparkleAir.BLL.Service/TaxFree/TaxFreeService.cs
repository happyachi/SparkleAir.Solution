using SparkleAir.IDAL.IRepository.Airport;
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
    public class TaxFreeService
    {
        private readonly ITFRepository _repo;
        public TaxFreeService(ITFRepository repo) //接收IAirportRepository,方便可以使用Dapper或是EF
        {
            _repo = repo;
        }

        public List<TFItemDto> Get()
        {
            List<TFItemEntity> result = _repo.Get();
            List<TFItemDto> list = result.Select(x => new TFItemDto
            {
                Id = x.Id,
                Name = x.Name,
                SerialNumber = x.SerialNumber,
                Image = x.Image,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice,
                Description = x.Description,
                IsPublished = x.IsPublished,
                TFCategoriesId = x.TFCategoriesId


            }).ToList();
            return list;
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }
        public int Create(TFItemDto dto)
        {
            TFItemEntity entity = new TFItemEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                SerialNumber = dto.SerialNumber,
                Image = dto.Image,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
                Description = dto.Description,
                IsPublished = dto.IsPublished,
                TFCategoriesId = dto.TFCategoriesId

            };
            _repo.Create(entity);
            return entity.Id;
        }

        public void Update(TFItemDto dto)
        {
            TFItemEntity entity = new TFItemEntity
            {

                Id = dto.Id,
                Name = dto.Name,
                SerialNumber = dto.SerialNumber,
                Image = dto.Image,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
                Description = dto.Description,
                IsPublished = dto.IsPublished,
                TFCategoriesId = dto.TFCategoriesId
            };
            _repo.Update(entity);
        }

    }

}
