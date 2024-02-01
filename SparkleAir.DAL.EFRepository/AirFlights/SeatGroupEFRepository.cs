using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.DAL.EFRepository.AirFlights
{
    public class SeatGroupEFRepository : ISeatGroupRepository
    {
        private AppDbContext db = new AppDbContext();
        //應該要接收Airtype 然後跑座位
        //不然寫好多個Create

        public void Create() //777-300ER
        {
            SeatGroup seatGroup;
            for (int i = 45; i <= 72; i++)
            {
                for (char c = 'A'; c <= 'K'; c++)
                {
                    if (i == 45 || i == 60)
                    {
                        if (c == 'A' || c == 'B' || c == 'C' || c == 'H' || c == 'J' || c == 'K')
                        {
                            seatGroup = new SeatGroup
                            {
                                AirTypeId = 1,
                                SeatAreaId = 4,
                                SeatNum = i + c.ToString(),
                            };
                            db.SeatGroups.Add(seatGroup);
                            db.SaveChanges();
                        }
                    }
                    else if (i == 57 || i == 72)
                    {
                        if (c == 'A' || c == 'D' || c == 'C' || c == 'E' || c == 'G' || c == 'K' || c == 'H')
                        {
                            seatGroup = new SeatGroup
                            {
                                AirTypeId = 1,
                                SeatAreaId = 2,
                                SeatNum = i + c.ToString(),
                            };
                            db.SeatGroups.Add(seatGroup);
                            db.SaveChanges();
                        }

                    }
                    else if (i >= 46 && i <= 56)
                    {
                        if (c == 'A' || c == 'D' || c == 'C' || c == 'E' || c == 'G' || c == 'K' || c == 'H' || c == 'B' || c == 'J')
                        {
                            seatGroup = new SeatGroup
                            {
                                AirTypeId = 1,
                                SeatAreaId = 2,
                                SeatNum = i + c.ToString(),
                            };
                            db.SeatGroups.Add(seatGroup);
                            db.SaveChanges();
                        }
                    }
                    else if (i >= 61 && i <= 71)
                    {
                        if (c == 'A' || c == 'D' || c == 'C' || c == 'E' || c == 'G' || c == 'K' || c == 'H' || c == 'B' || c == 'J')
                        {
                            seatGroup = new SeatGroup
                            {
                                AirTypeId = 1,
                                SeatAreaId = 2,
                                SeatNum = i + c.ToString(),
                            };
                            db.SeatGroups.Add(seatGroup);
                            db.SaveChanges();
                        }
                    }

                }
            }
        }
    }
}
