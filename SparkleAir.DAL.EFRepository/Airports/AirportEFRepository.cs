using SparkleAir.IDAL.IRepository.Airport;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.Airports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.DAL.EFRepository.Airports
{
    public class AirportEFRepository:IAirportRepository
    {
        private AppDbContext db = new AppDbContext();

        public List<AirportEntity> GetAll()
        {
            var products = db.AirPorts.AsNoTracking()
                            .OrderBy(p => p.Continent)
                            .Select(p => new AirportEntity
                            {
                                Id = p.Id,
                                Lata = p.Lata,
                                Gps = p.Gps,
                                Country = p.Country,
                                City = p.City,
                                AirPortName = p.AirPortName,
                                TimeArea = p.TimeArea,
                                Zone = p.Zone,
                                CityIntroduction = p.CityIntroduction,
                                Img = p.Img,
                                Continent = p.Continent,
                            })
                            .ToList();

            return products;
        }


        public int Create(AirportEntity model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var Airport = db.AirPorts.Find(id);
            db.AirPorts.Remove(Airport);
            db.SaveChanges();
        }

        public AirportEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        

        public void Update(AirportEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
