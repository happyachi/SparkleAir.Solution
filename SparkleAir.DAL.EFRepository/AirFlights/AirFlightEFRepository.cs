using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.DAL.EFRepository.AirFlights
{
    public class AirFlightEFRepository : IAirFlightRepository
    {
        private AppDbContext db = new AppDbContext();
        public void Create(AirFlightEntity entity)
        {
            throw new NotImplementedException();
        }

        public AirFlightEntity GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
