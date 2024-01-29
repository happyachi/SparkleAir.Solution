using SparkleAir.IDAL.IRepository.AirFlights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.AirFlights
{
    public class AirFlightSeatsService
    {
        private readonly IAirFlightSeatsRepository _repo;
        public AirFlightSeatsService(IAirFlightSeatsRepository repo)
        {
            _repo = repo;
        }
        public void Create(int managementId)
        {
            _repo.Create(managementId);
        }
    }
}
