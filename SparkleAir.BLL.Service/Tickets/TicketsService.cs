using SparkleAir.IDAL.IRepository.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.Tickets
{
    public class TicketsService
    {
        private readonly ITicketsRepository _repo;
        public TicketsService(ITicketsRepository repo)
        {
            _repo = repo;
        }
    }
}
