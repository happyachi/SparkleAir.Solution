using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SparkleAir.Infa.Utility.Exts.Models;

namespace SparkleAir.DAL.EFRepository.AirFlights
{
    public class AirFlightSeatsEFRepository : IAirFlightSeatsRepository
    {
        private AppDbContext db = new AppDbContext();

        public async Task Create777300ER(int flightId)
        {
            await Task.Run(() =>
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
                            }
                        }
                    }
                }
                db.SaveChanges();
            });

        }

        public List<AirFlightSeatsEntity> GetByFlightId(int flightId)
        {
            Func<AirFlightSeat, AirFlightSeatsEntity> seatFunc = x => x.ToFlightSeatsEntity(flightId);
            var flightSeats = db.AirFlightSeats
                    .AsNoTracking()
                    .Where(x => x.AirFlightId == flightId)
                    .Include(x => x.AirCabin)
                    .Include(x => x.AirFlight)
                    .Include(x => x.AirFlight.AirOwn)
                    .Include(x => x.AirFlight.AirOwn.AirType)
                    .ToList()
                    .Select(seatFunc)
                    .ToList();

            return flightSeats;
        }

        public EachSeatInfoEntity GetEachSeatInfo(int seatId)
        {
            var bookSeat = db.AirBookSeats.AsNoTracking().Where(x => x.AirFlightSeatId == seatId).FirstOrDefault();
            Func<AirBookSeat, EachSeatInfoEntity> func = x => x.ToEachSeatInfoEntity(seatId);

            var entity = bookSeat.ToEachSeatInfoEntity(seatId);
            return entity;
        }
    }
}
