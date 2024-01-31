﻿using SparkleAir.IDAL.IRepository.Luggage;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.Airports;
using SparkleAir.Infa.Entity.Luggage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;   

namespace SparkleAir.DAL.EFRepository.Luggages
{
    public class LuggageEFRepository:ILuggageRepository
    {
        private AppDbContext db = new AppDbContext();

        public int Create(LuggageEntity model)
        {
            Luggage luggage = new Luggage
            {
                Id = model.Id,
                AirFlightManagementsId = model.AirFlightManagementsId,
                OriginalPrice = model.OriginalPrice,
                BookPrice = model.BookPrice,
            };
            db.Luggages.Add(luggage);
            db.SaveChanges();
            return luggage.Id;
        }

        public void Delete(int id)
        {
            var Luggage = db.Luggages.Find(id);
            db.Luggages.Remove(Luggage);
            db.SaveChanges();
        }
        //
        public LuggageEntity Get(int id)
        {
            var get = db.Luggages.Find(id);

            LuggageEntity en = new LuggageEntity()
            {
                Id = get.Id,
                AirFlightManagementsId = get.AirFlightManagementsId,
                OriginalPrice = get.OriginalPrice,
                BookPrice = get.BookPrice,
            };

            return en;
        }

        public List<LuggageEntity> GetAll()
        {
            var Luggage = db.Luggages.AsNoTracking()
                           .Include(p => p.AirFlightManagement)
                           .OrderBy(p => p.OriginalPrice)
                           .Select(p => new LuggageEntity
                           {
                               Id = p.Id,
                               AirFlightManagementsId = p.AirFlightManagementsId,
                               OriginalPrice = p.OriginalPrice,
                               BookPrice = p.BookPrice,
                           })
                           .ToList();

            return Luggage;
        }

        public void Update(LuggageEntity model)
        {
            var get = db.Luggages.Find(model.Id);
            if (get != null)
            {
                get.Id = model.Id;
                get.AirFlightManagementsId = model.AirFlightManagementsId;
                get.OriginalPrice = model.OriginalPrice;
                get.BookPrice = model.BookPrice;

            }

            db.SaveChanges();
        }


     




    }
}
