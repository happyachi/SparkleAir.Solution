namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TransferRefund
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TransferRefund()
        {
            TicketCancels = new HashSet<TicketCancel>();
        }

        public int Id { get; set; }

        public int TransferIMethodsId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime RefundDate { get; set; }

        public decimal RefundtAmount { get; set; }

        public int TransferPaymentsId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketCancel> TicketCancels { get; set; }

        public virtual TransferMethod TransferMethod { get; set; }

        public virtual TransferPayment TransferPayment { get; set; }
    }
}
