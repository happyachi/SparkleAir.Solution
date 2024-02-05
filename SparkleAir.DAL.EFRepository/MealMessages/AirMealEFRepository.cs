using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SparkleAir.IDAL.IRepository.MealMessages;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.MealMessageEntity;

namespace SparkleAir.DAL.EFRepository.MealMessages
{
    public class AirMealEFRepository : IAirMealRepository
    {
        private AppDbContext db= new AppDbContext();
        public int Create(AirMealEntity entity)
        {
            AirMeal airMeal = new AirMeal
            {
                Id = entity.Id,
                Name = entity.Name,
                AirCabinId = entity.AirCabinId,
                MealContent = entity.MealContent,
                Image = entity.Image,
                ImageBit = entity.ImageBit,
                Category = entity.Category

            };
            db.AirMeals.Add(airMeal);
            db.SaveChanges();
            return airMeal.Id;
        }

        public void Delete(int id)
        {
            var airMeal = db.AirMeals.Find(id);
            db.AirMeals.Remove(airMeal);
            db.SaveChanges();
        }

        public AirMealEntity Get(int id)
        {
            //var a = db.AirMeals.Find(id);
            //var b = new AirMealEntity
            //{
            //    Id = a.Id,
            //    Name = a.Name,
            //    AirCabinId = a.AirCabinId,
            //    MealContent = a.MealContent,
            //    Image = a.Image,
            //    ImageBit = a.ImageBit,
            //    Category = a.Category
            //};


            AirMealEntity data=db.AirMeals.Where(x=>x.Id == id)
                .Select(x=>new AirMealEntity {
                    Id=x.Id, 
                    Name=x.Name,AirCabinId=x.AirCabinId, MealContent=x.MealContent,Image=x.Image, ImageBit=x.ImageBit, Category=x.Category}).First();
            return data;
        }

        public List<AirMealEntity> Search()
        {
            List<AirMealEntity> data=db.AirMeals.AsNoTracking().Select(x=>new AirMealEntity
            {
                Id = x.Id,
                Name = x.Name,
                AirCabinId = x.AirCabinId,
                MealContent = x.MealContent,
                Image = x.Image,
                ImageBit = x.ImageBit,
                Category = x.Category
            }).ToList();
            return data;
        }

        public void Update(AirMealEntity entity)
        {
            var airMeal = db.AirMeals.Find(entity.Id);
            if (airMeal == null)
            {
                throw new Exception("查無此筆資料");
            }
            else
            {
                airMeal.Name = entity.Name;
                airMeal.AirCabinId=entity.AirCabinId;
                airMeal.MealContent = entity.MealContent;
                airMeal.Image=entity.Image;
                airMeal.ImageBit = entity.ImageBit;
                airMeal.Category = entity.Category;

                db.SaveChanges();
            }
        }
    }
}
