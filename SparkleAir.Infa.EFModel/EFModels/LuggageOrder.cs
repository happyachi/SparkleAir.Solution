namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LuggageOrder
    {
        public int Id { get; set; }

        public int TicketInvoicingDetailId { get; set; }

        public int LuggageId { get; set; }

        public int Amount { get; set; }

        public int Price { get; set; }

        public DateTime OrderTime { get; set; }

        public int TransferPaymentsId { get; set; }

        [Required]
        [StringLength(10)]
        public string OrderStatus { get; set; }

        [Required]
        [StringLength(10)]
        public string LuggageNum { get; set; }

        public virtual Luggage Luggage { get; set; }

        public virtual TicketInvoicingDetail TicketInvoicingDetail { get; set; }

        public virtual TransferPayment TransferPayment { get; set; }
    }
}
