namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AirBookSeat
    {
        public int Id { get; set; }

        public int AirFlightSeatId { get; set; }

        public int TicketInvoicingDetailId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ReservationTime { get; set; }

        public int? TransferPaymentId { get; set; }

        public decimal? HandlingFee { get; set; }

        [Required]
        [StringLength(15)]
        public string SeatAssignmentNum { get; set; }

        public virtual AirFlightSeat AirFlightSeat { get; set; }

        public virtual TicketInvoicingDetail TicketInvoicingDetail { get; set; }

        public virtual TransferPayment TransferPayment { get; set; }
    }
}
