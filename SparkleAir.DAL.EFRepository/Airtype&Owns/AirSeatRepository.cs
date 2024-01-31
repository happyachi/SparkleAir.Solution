using SparkleAir.IDAL.IRepository.Airtype_Owns;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.Airtype_Owns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.DAL.EFRepository.Airtype_Owns
{
   public class AirSeatRepository:IAirSeatRepository
    {
        
        public List<AirSeatEntity> GetAll()
        {
            var db = new AppDbContext();

            var seats = db.AirCabinSeats
                .AsNoTracking()
                .Select(p => new AirSeatEntity
                {
                    Id = p.Id,
                    AirTypeId = p.AirTypeId,
                    AirCabinId = p.AirCabinId,
                    SeatNum = p.SeatNum

                })
                .ToList();

            return seats;
        }
    }
}
