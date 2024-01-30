using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.TaxFree
{
    public class TFReservesVm
    {
        

        public int Id { get; set; }

        public int MemberId { get; set; }

        public int? Discount { get; set; }

        public int TotalPrice { get; set; }

        public int TransferPaymentId { get; set; }

        
    }
}
