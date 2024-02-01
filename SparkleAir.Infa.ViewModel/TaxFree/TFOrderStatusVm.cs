using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.TaxFree
{
    public class TFOrderStatusVm
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? PaidTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? FulfilledTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CancelledTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? RefundTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? StockedTime { get; set; }

        public bool? Paid { get; set; }

        public bool? Fulfilled { get; set; }

        public bool? Cancelled { get; set; }

        public bool? Refund { get; set; }

        public bool? Stocked { get; set; }

        public int? TFReserveId { get; set; }

        public int MemberId { get; set; }

        public int? Discount { get; set; }

        public int TotalPrice { get; set; }

        public int TransferPaymentId { get; set; }

    }
}
