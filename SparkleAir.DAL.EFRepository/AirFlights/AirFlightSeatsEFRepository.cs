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
    public class AirFlightSeatsEFRepository : IAirFlightSeatsRepository
    {
        private AppDbContext db = new AppDbContext();

        public void Create777300ER(int flightId)
        {
            AirFlightSeat seats;
            //商務
            for (int i = 1; i <= 11; i++)
            {
                for (char c = 'A'; c <= 'k'; c++)
                {
                    if (i == 7)
                    {
                        if (c == 'D' || c == 'G')
                        {
                            seats = new AirFlightSeat
                            {
                                AirFlightId = flightId,
                                AirCabinId = 2,
                                SeatNum = i + c.ToString(),
                                IsSeated = false
                            };
                            db.AirFlightSeats.Add(seats);
                            db.SaveChanges();
                        }
                    }
                    else if (i != 4)
                    {
                        if (c == 'A' || c == 'D' || c == 'G' || c == 'K')
                        {
                            seats = new AirFlightSeat
                            {
                                AirFlightId = flightId,
                                AirCabinId = 2,
                                SeatNum = i + c.ToString(),
                                IsSeated = false
                            };
                            db.AirFlightSeats.Add(seats);
                            db.SaveChanges();
                        }
                    }
                }
            }

            //豪華
            for (int i = 20; i <= 27; i++)
            {
                for (char c = 'A'; c <= 'k'; c++)
                {
                    if (c == 'A' || c == 'C' || c == 'D' || c == 'E' || c == 'F' || c == 'G' || c == 'H' || c == 'K')
                    {
                        seats = new AirFlightSeat
                        {
                            AirFlightId = flightId,
                            AirCabinId = 3,
                            SeatNum = i + c.ToString(),
                            IsSeated = false
                        };

                        db.AirFlightSeats.Add(seats);
                        db.SaveChanges();
                    }

                }
            }

            //經濟
            for (int i = 45; i <= 72; i++)
            {
                for (char c = 'A'; c <= 'k'; c++)
                {
                    if (i == 45 || i == 60)
                    {
                        if (c == 'A' || c == 'B' || c == 'C' || c == 'H' || c == 'J' || c == 'K')
                        {
                            seats = new AirFlightSeat
                            {
                                AirFlightId = flightId,
                                AirCabinId = 4,
                                SeatNum = i + c.ToString(),
                                IsSeated = false
                            };
                            db.AirFlightSeats.Add(seats);
                            db.SaveChanges();
                        }
                    }
                    else if (i == 57)
                    {
                        if (c == 'A' || c == 'D' || c == 'C' || c == 'E' || c == 'G' || c == 'K' || c == 'H')
                        {
                            seats = new AirFlightSeat
                            {
                                AirFlightId = flightId,
                                AirCabinId = 4,
                                SeatNum = i + c.ToString(),
                                IsSeated = false
                            };
                            db.AirFlightSeats.Add(seats);
                            db.SaveChanges();
                        }

                    }
                    else if (i >= 46 && i <= 56)
                    {
                        if (c == 'A' || c == 'D' || c == 'C' || c == 'E' || c == 'G' || c == 'K' || c == 'H' || c == 'B' || c == 'J')
                        {
                            seats = new AirFlightSeat
                            {
                                AirFlightId = flightId,
                                AirCabinId = 4,
                                SeatNum = i + c.ToString(),
                                IsSeated = false
                            };
                            db.AirFlightSeats.Add(seats);
                            db.SaveChanges();
                        }
                    }
                    else if (i >= 61 && i <= 71)
                    {
                        if (c == 'A' || c == 'D' || c == 'C' || c == 'E' || c == 'G' || c == 'K' || c == 'H' || c == 'B' || c == 'J')
                        {
                            seats = new AirFlightSeat
                            {
                                AirFlightId = flightId,
                                AirCabinId = 4,
                                SeatNum = i + c.ToString(),
                                IsSeated = false
                            };
                            db.AirFlightSeats.Add(seats);
                            db.SaveChanges();
                        }
                    }
                    else if (i == 72)
                    {
                        if (c == 'A' || c == 'C' || c == 'H' || c == 'K')
                        {
                            seats = new AirFlightSeat
                            {
                                AirFlightId = flightId,
                                AirCabinId = 4,
                                SeatNum = i + c.ToString(),
                                IsSeated = false
                            };
                            db.AirFlightSeats.Add(seats);
                            db.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
