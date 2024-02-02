using SparkleAir.IDAL.IRepository.LuggageOrders;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.Luggage;
using SparkleAir.Infa.Entity.LuggageOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SparkleAir.Infa.Entity.Airports;

namespace SparkleAir.DAL.EFRepository.LuggageOrders
{
    public class LuggageOrderEFRepository : ILuggageOrderRepository
    {
        private AppDbContext db = new AppDbContext();


        public int Create(LuggageOrderEntity model)
        {
            LuggageOrder luggage = new LuggageOrder
            {
                Id = model.Id,
                TicketInvoicingDetailId = model.TicketInvoicingDetailId,
                LuggageId = model.LuggageId,
                Amount = model.Amount,
                Price = model.Price,
                OrderTime = model.OrderTime,
                TransferPaymentsId = model.TransferPaymentsId,
                OrderStatus = model.OrderStatus,
                LuggageNum = model.LuggageNum,
            };
            db.LuggageOrders.Add(luggage);
            db.SaveChanges();
            return luggage.Id;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public LuggageOrderEntity Get(int id)
        {
            var get = db.LuggageOrders.Find(id);
            if (get == null)
            {
                 throw new Exception();
            }
            else
            {
                return new LuggageOrderEntity
                {
                    Id = get.Id,
                    FlightCode = get.TicketInvoicingDetail.TicketDetail.Ticket.AirFlight.AirFlightManagement.FlightCode,
                    TicketInvoicingDetailId = get.TicketInvoicingDetailId,
                    TicketInvoicingDetailName = get.TicketInvoicingDetail.FirstName + get.TicketInvoicingDetail.LastName,
                    LuggageId = get.LuggageId,
                    LuggagePrice = get.Luggage.BookPrice,
                    Amount = get.Amount,
                    Price = get.Price,
                    OrderTime = get.OrderTime,
                    TransferPaymentsId = get.TransferPaymentsId,
                    OrderStatus = get.OrderStatus,
                    LuggageNum = get.LuggageNum,
                };
            }

        }

        public List<LuggageOrderEntity> GetAll()
        {
           

            var luggageorder = db.LuggageOrders.AsNoTracking()
                               .Include(p => p.TicketInvoicingDetail)
                               .Include(p =>p.Luggage)
                               .Include(p=>p.TransferPayment)
                               .OrderBy(p => p.OrderTime)
                               .Select(p => new LuggageOrderEntity
                               {
                                   
                                   Id = p.Id,
                                   FlightCode = p.TicketInvoicingDetail.TicketDetail.Ticket.AirFlight.AirFlightManagement.FlightCode,
                                   TicketInvoicingDetailId = p.TicketInvoicingDetailId,
                                   TicketInvoicingDetailName=p.TicketInvoicingDetail.FirstName+p.TicketInvoicingDetail.LastName,
                                   LuggageId = p.LuggageId,
                                   LuggagePrice=p.Luggage.BookPrice,
                                   Amount = p.Amount,
                                   Price = p.Price,
                                   OrderTime = p.OrderTime,
                                   TransferPaymentsId = p.TransferPaymentsId,
                                   OrderStatus = p.OrderStatus,
                                   LuggageNum = p.LuggageNum,
                               })
                               .ToList();

            return luggageorder;
        }

        public void Update(LuggageOrderEntity model)
        {
            throw new NotImplementedException();
        }



       

    }
}
