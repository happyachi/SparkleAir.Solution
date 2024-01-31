using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Entity.TaxFree
{
    public class TFReservesEntity
    {

        public int Id { get; set; }

        public int MemberId { get; set; }

        public int Discount { get; set; }

        public int TotalPrice { get; set; }

        public int TransferPaymentId { get; set; }

        //public virtual Member Member { get; set; }
        //todo:TF

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<TFOrderStatus> TFOrderStatuses { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<TFReservelist> TFReservelists { get; set; }

        //public virtual TransferPayment TransferPayment { get; set; }
    }
}
