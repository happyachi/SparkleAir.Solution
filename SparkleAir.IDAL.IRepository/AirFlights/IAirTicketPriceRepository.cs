﻿using SparkleAir.Infa.Entity.AirFlightsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.IDAL.IRepository.AirFlights
{
    public interface IAirTicketPriceRepository
    {
        Task CreateTicketPirce1500(int id);
    }
}
