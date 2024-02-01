using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.Infa.Dto.AriFlights;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.AirFlights
{
    public class AirTicketPriceService
    {
        private readonly IAirTicketPriceRepository _repo;
        public AirTicketPriceService(IAirTicketPriceRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateTicketPirce1500(int flightId, int mile)
        {
            if (mile < 1500)
            {
                await _repo.CreateTicketPirce1500(flightId);
            }
            if (mile < 2500)
            {
                await _repo.CreateTicketPirce2500(flightId);
            }
            if (mile < 5000)
            {
                await _repo.CreateTicketPirce5000(flightId);
            }
            if (mile < 10000)
            {
                await _repo.CreateTicketPirce10000(flightId);
            }
        }
    }
}
