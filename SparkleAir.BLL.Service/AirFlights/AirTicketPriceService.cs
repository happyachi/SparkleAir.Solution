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

        public void CreateTicketPirce1500(int flightId, int mile)
        {
            if (mile < 1500)
            {
                _repo.CreateTicketPirce1500(flightId);
            }
            if (mile < 2500)
            {
                //todo 不同里程的價格REPO
            }
            if (mile < 5000)
            {
                //todo 不同里程的價格REPO
            }
            if (mile < 10000)
            {
                //todo 不同里程的價格REPO
            }
        }
    }
}
