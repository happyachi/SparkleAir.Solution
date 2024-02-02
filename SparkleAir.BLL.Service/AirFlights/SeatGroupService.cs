using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.AirFlights
{
    public class SeatGroupService
    {
        private readonly ISeatGroupRepository _repo;
        public SeatGroupService(ISeatGroupRepository repo)
        {
            _repo = repo;
        }

        public void Create()
        {
            _repo.Create777300ER();
            _repo.Create78710();
            _repo.CreateA320neo();
            _repo.CreateA350900();
        }
    }
}
