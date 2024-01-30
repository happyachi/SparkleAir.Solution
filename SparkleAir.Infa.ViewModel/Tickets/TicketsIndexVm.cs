using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.Tickets
{
    public class TicketsIndexVm
    {
        public int Id { get; set; }
        [Display(Name = "會員ID")]
        public int memberId { get; set; }
        [Display(Name = "訂單編號")]
        public string OrderNum { get; set; }
        [Display(Name = "應付金額")]
        public decimal TotalPayableAmount { get; set; }
        [Display(Name = "實付金額")]
        public decimal ActualPaidAmount { get; set; }
        [Display(Name = "訂購時間")]
        public DateTime OrderTime { get; set; }
        [Display(Name = "是否成立")]
        public bool IsEstablished { get; set; }
        [Display(Name = "是否開票")]
        public bool IsInvoiced { get; set; }
    }
}
