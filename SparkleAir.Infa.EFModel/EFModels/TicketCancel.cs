namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TicketCancel
    {
        public int Id { get; set; }

        public int TicketId { get; set; }

        public int TicketCancelStatusId { get; set; }

        public int TransferRefundId { get; set; }

        public decimal OriginalOrderAmount { get; set; }

        public decimal TotalHandlingFee { get; set; }

        public decimal ActualRefundAmount { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ApplicationTime { get; set; }

        [Required]
        [StringLength(100)]
        public string Remark { get; set; }

        [Required]
        [StringLength(100)]
        public string RefundFeeDetail { get; set; }

        public virtual TicketCancelStatus TicketCancelStatus { get; set; }

        public virtual Ticket Ticket { get; set; }

        public virtual TransferRefund TransferRefund { get; set; }
    }
}
