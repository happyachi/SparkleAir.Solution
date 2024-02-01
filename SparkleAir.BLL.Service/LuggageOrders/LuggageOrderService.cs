using SparkleAir.IDAL.IRepository.Luggage;
using SparkleAir.IDAL.IRepository.LuggageOrders;
using SparkleAir.Infa.Dto.Airport;
using SparkleAir.Infa.Dto.Luggage;
using SparkleAir.Infa.Dto.LuggageOrders;
using SparkleAir.Infa.Entity.Airports;
using SparkleAir.Infa.Entity.Luggage;
using SparkleAir.Infa.Entity.LuggageOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.LuggageOrderService
{
    public class LuggageOrderService
    {
        private readonly ILuggageOrderRepository _repo;

        public LuggageOrderService(ILuggageOrderRepository repo) //接收IAirportRepository,方便可以使用Dapper或是EF
        {
            _repo = repo;
        }


        //取全部
        public List<LuggageOrderDto> GetAll()
        {
            List<LuggageOrderEntity> entity = _repo.GetAll();

            List<LuggageOrderDto> dto = entity.Select(p => new LuggageOrderDto
            {
                Id = p.Id,
                FlightCode = p.FlightCode,
                TicketInvoicingDetailId = p.TicketInvoicingDetailId,
                TicketInvoicingDetailName = p.TicketInvoicingDetailName,
                LuggageId = p.LuggageId,
                LuggagePrice = p.LuggagePrice,
                Amount = p.Amount,
                Price = p.Price,
                OrderTime = p.OrderTime,
                TransferPaymentsId = p.TransferPaymentsId,
                OrderStatus = p.OrderStatus,
                LuggageNum = p.LuggageNum,


            }).ToList();
            return dto;
        }



        public int Create(LuggageOrderDto dto)
        {
           
            LuggageOrderEntity entity = new LuggageOrderEntity
            {
                Id = dto.Id,
                TicketInvoicingDetailId = dto.TicketInvoicingDetailId,
                LuggageId = dto.LuggageId,
                Amount = dto.Amount,
                Price = dto.Price,
                OrderTime = dto.OrderTime,
                TransferPaymentsId = dto.TransferPaymentsId,
                OrderStatus = dto.OrderStatus,
                LuggageNum = dto.LuggageNum,

            };
            _repo.Create(entity);  //沒呼叫AirportEFRepository是因為AirportEFRepository有實作interface,所以呼叫_repo也就好
            return entity.Id;
        }


        //取得一筆
        public LuggageOrderDto Get(int id)
        {
            LuggageOrderEntity entity = _repo.Get(id);

            LuggageOrderDto dto = new LuggageOrderDto
            {
                Id = entity.Id,
                FlightCode = entity.FlightCode,
                TicketInvoicingDetailId = entity.TicketInvoicingDetailId,
                TicketInvoicingDetailName = entity.TicketInvoicingDetailName,
                LuggageId = entity.LuggageId,
                LuggagePrice = entity.LuggagePrice,
                Amount = entity.Amount,
                Price = entity.Price,
                OrderTime = entity.OrderTime,
                TransferPaymentsId = entity.TransferPaymentsId,
                OrderStatus = entity.OrderStatus,
                LuggageNum = entity.LuggageNum,
            };

            return dto;
        }


    }
}
