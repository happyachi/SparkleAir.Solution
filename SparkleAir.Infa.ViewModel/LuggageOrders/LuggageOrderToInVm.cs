using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.LuggageOrders
{
    public class LuggageOrderToInVm
    {
        [Display(Name = "航班代碼")]
        public string FlightCode { get; set; }

        [Display(Name = "姓名")]
        public string TicketInvoicingDetailName { get; set; }


        [Display(Name = "託運預定價")]
        public int LuggagePrice { get; set; }

        [Display(Name = "數量")]

        public int Amount { get; set; }

        [Display(Name = "總價")]

        public int Price { get; set; }

        [Display(Name = "預定時間")]

        public DateTime OrderTime { get; set; }

        [Display(Name = "付款編號")]

        public int TransferPaymentsId { get; set; }

        [Display(Name = "訂單狀態")]

        public string OrderStatus { get; set; }

        [Display(Name = "託運編號")]

        public string LuggageNum { get; set; }
    }
}
