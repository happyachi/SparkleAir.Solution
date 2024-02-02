using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.DAL.EFRepository.AirFlights
{
    public class AirTicketPriceEFRepository : IAirTicketPriceRepository
    {
        private AppDbContext db = new AppDbContext();

        public async Task CreateTicketPirce10000(int id)
        {
            var cabinRules = await db.AirCabinRules.ToListAsync();
            decimal firstClassPrice = 65000;
            decimal secondClass = 52000;
            decimal primaryClass = 43000;
            decimal economyClass = 32000;
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in cabinRules)
                    {
                        if (item.CabinCode == "C")
                        {
                            SetPrice(item.Id, id, firstClassPrice, 1.45m);
                        }
                        else if (item.CabinCode == "J")
                        {
                            SetPrice(item.Id, id, firstClassPrice, 1.3m);
                        }
                        else if (item.CabinCode == "D")
                        {
                            SetPrice(item.Id, id, firstClassPrice, 1);
                        }

                        if (item.CabinCode == "K")
                        {
                            SetPrice(item.Id, id, secondClass, 1.35m);
                        }
                        else if (item.CabinCode == "T")
                        {
                            SetPrice(item.Id, id, secondClass, 1.2m);
                        }
                        else if (item.CabinCode == "L")
                        {
                            SetPrice(item.Id, id, secondClass, 1);
                        }

                        if (item.CabinCode == "B")
                        {
                            SetPrice(item.Id, id, primaryClass, 1.3m);
                        }
                        else if (item.CabinCode == "Y")
                        {
                            SetPrice(item.Id, id, primaryClass, 1.25m);
                        }
                        else if (item.CabinCode == "V")
                        {
                            SetPrice(item.Id, id, primaryClass, 1);
                        }

                        if (item.CabinCode == "W")
                        {
                            SetPrice(item.Id, id, economyClass, 1.2m);
                        }
                        else if (item.CabinCode == "S")
                        {
                            SetPrice(item.Id, id, economyClass, 1);
                        }
                        else if (item.CabinCode == "A")
                        {
                            SetPrice(item.Id, id, economyClass, 0.9m);
                        }
                    }
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public async Task CreateTicketPirce1500(int id)
        {
            var cabinRules = await db.AirCabinRules.ToListAsync();
            decimal firstClassPrice = 35000;
            decimal secondClass = 30000;
            decimal primaryClass = 25000;
            decimal economyClass = 20000;
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in cabinRules)
                    {
                        if (item.CabinCode == "C")
                        {
                            SetPrice(item.Id, id, firstClassPrice, 1.45m);
                        }
                        else if (item.CabinCode == "J")
                        {
                            SetPrice(item.Id, id, firstClassPrice, 1.3m);
                        }
                        else if (item.CabinCode == "D")
                        {
                            SetPrice(item.Id, id, firstClassPrice, 1);
                        }

                        if (item.CabinCode == "K")
                        {
                            SetPrice(item.Id, id, secondClass, 1.35m);
                        }
                        else if (item.CabinCode == "T")
                        {
                            SetPrice(item.Id, id, secondClass, 1.2m);
                        }
                        else if (item.CabinCode == "L")
                        {
                            SetPrice(item.Id, id, secondClass, 1);
                        }

                        if (item.CabinCode == "B")
                        {
                            SetPrice(item.Id, id, primaryClass, 1.3m);
                        }
                        else if (item.CabinCode == "Y")
                        {
                            SetPrice(item.Id, id, primaryClass, 1.25m);
                        }
                        else if (item.CabinCode == "V")
                        {
                            SetPrice(item.Id, id, primaryClass, 1);
                        }

                        if (item.CabinCode == "W")
                        {
                            SetPrice(item.Id, id, economyClass, 1.2m);
                        }
                        else if (item.CabinCode == "S")
                        {
                            SetPrice(item.Id, id, economyClass, 1);
                        }
                        else if (item.CabinCode == "A")
                        {
                            SetPrice(item.Id, id, economyClass, 0.9m);
                        }
                    }
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public async Task CreateTicketPirce2500(int id)
        {
            var cabinRules = await db.AirCabinRules.ToListAsync();
            decimal firstClassPrice = 40000;
            decimal secondClass = 36000;
            decimal primaryClass = 23500;
            decimal economyClass = 21000;
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in cabinRules)
                    {
                        if (item.CabinCode == "C")
                        {
                            SetPrice(item.Id, id, firstClassPrice, 1.45m);
                        }
                        else if (item.CabinCode == "J")
                        {
                            SetPrice(item.Id, id, firstClassPrice, 1.3m);
                        }
                        else if (item.CabinCode == "D")
                        {
                            SetPrice(item.Id, id, firstClassPrice, 1);
                        }

                        if (item.CabinCode == "K")
                        {
                            SetPrice(item.Id, id, secondClass, 1.35m);
                        }
                        else if (item.CabinCode == "T")
                        {
                            SetPrice(item.Id, id, secondClass, 1.2m);
                        }
                        else if (item.CabinCode == "L")
                        {
                            SetPrice(item.Id, id, secondClass, 1);
                        }

                        if (item.CabinCode == "B")
                        {
                            SetPrice(item.Id, id, primaryClass, 1.3m);
                        }
                        else if (item.CabinCode == "Y")
                        {
                            SetPrice(item.Id, id, primaryClass, 1.25m);
                        }
                        else if (item.CabinCode == "V")
                        {
                            SetPrice(item.Id, id, primaryClass, 1);
                        }

                        if (item.CabinCode == "W")
                        {
                            SetPrice(item.Id, id, economyClass, 1.2m);
                        }
                        else if (item.CabinCode == "S")
                        {
                            SetPrice(item.Id, id, economyClass, 1);
                        }
                        else if (item.CabinCode == "A")
                        {
                            SetPrice(item.Id, id, economyClass, 0.9m);
                        }
                    }
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public async Task CreateTicketPirce5000(int id)
        {
            var cabinRules = await db.AirCabinRules.ToListAsync();
            decimal firstClassPrice = 50000;
            decimal secondClass = 44000;
            decimal primaryClass = 37000;
            decimal economyClass = 30000;
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in cabinRules)
                    {
                        if (item.CabinCode == "C")
                        {
                            SetPrice(item.Id, id, firstClassPrice, 1.45m);
                        }
                        else if (item.CabinCode == "J")
                        {
                            SetPrice(item.Id, id, firstClassPrice, 1.3m);
                        }
                        else if (item.CabinCode == "D")
                        {
                            SetPrice(item.Id, id, firstClassPrice, 1);
                        }

                        if (item.CabinCode == "K")
                        {
                            SetPrice(item.Id, id, secondClass, 1.35m);
                        }
                        else if (item.CabinCode == "T")
                        {
                            SetPrice(item.Id, id, secondClass, 1.2m);
                        }
                        else if (item.CabinCode == "L")
                        {
                            SetPrice(item.Id, id, secondClass, 1);
                        }

                        if (item.CabinCode == "B")
                        {
                            SetPrice(item.Id, id, primaryClass, 1.3m);
                        }
                        else if (item.CabinCode == "Y")
                        {
                            SetPrice(item.Id, id, primaryClass, 1.25m);
                        }
                        else if (item.CabinCode == "V")
                        {
                            SetPrice(item.Id, id, primaryClass, 1);
                        }

                        if (item.CabinCode == "W")
                        {
                            SetPrice(item.Id, id, economyClass, 1.2m);
                        }
                        else if (item.CabinCode == "S")
                        {
                            SetPrice(item.Id, id, economyClass, 1);
                        }
                        else if (item.CabinCode == "A")
                        {
                            SetPrice(item.Id, id, economyClass, 0.9m);
                        }
                    }
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        private void SetPrice(int cabinId, int flightId, decimal price, decimal percentage)
        {
            AriTicketPrice ticketprice = new AriTicketPrice
            {
                AirCabinRuleId = cabinId,
                AirFlightManagementId = flightId,
                Price = price * percentage,
            };
            db.AriTicketPrices.Add(ticketprice);

        }
    }
}
