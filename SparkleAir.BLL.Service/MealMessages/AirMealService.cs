
using SparkleAir.IDAL.IRepository.MealMessages;
using SparkleAir.Infa.Dto.MealMessages;
using SparkleAir.Infa.Entity.MealMessageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.MealMessages
{
    public class AirMealService
    {
        private readonly IAirMealRepository _repo;
        public AirMealService(IAirMealRepository repo)
        {
            _repo = repo;
        }

        public int Create(AirMealDto dto)
        {
            AirMealEntity entity = new AirMealEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                AirCabinId = dto.AirCabinId,
                MealContent = dto.MealContent,
                Image = dto.Image,
                ImageBit = dto.ImageBit,
                Category = dto.Category
            };
            _repo.Create(entity);
            return entity.Id;
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public List<AirMealDto> Search()
        {
            
            var entities=_repo.Search();
            var dtos=entities.Select(x=>new AirMealDto
            {
                Id = x.Id,
                Name = x.Name,
                AirCabinId=x.AirCabinId,
                MealContent = x.MealContent,
                Image = x.Image,
                ImageBit =x.ImageBit,
                Category = x.Category
            }).ToList();
            return dtos;
    
        }

        public void Update(AirMealDto dto)
        {
            AirMealEntity entity = new AirMealEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                AirCabinId = dto.AirCabinId,
                MealContent = dto.MealContent,
                Image = dto.Image,
                ImageBit = dto.ImageBit,
                Category = dto.Category
            };
            _repo.Update(entity);
            //return $"{entity.Name}修改成功";
        }
    }
}
