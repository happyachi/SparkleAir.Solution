using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.LuggageOrders
{
    public class LuggageOrderCreateVm
    {
        public int Id { get; set; }

        [Display(Name = "開票Id")]
        public int TicketInvoicingDetailId { get; set; }

       

        [Display(Name = "託運Id")]

        public int LuggageId { get; set; }

        

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
