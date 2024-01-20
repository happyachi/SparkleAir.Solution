namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket()
        {
            CampaignsFlightCouponsUsageHistories = new HashSet<CampaignsFlightCouponsUsageHistory>();
            TicketCancels = new HashSet<TicketCancel>();
            TicketDetails = new HashSet<TicketDetail>();
        }

        public int Id { get; set; }

        public int MemberId { get; set; }

        public int AirFlightId { get; set; }

        [Required]
        [StringLength(15)]
        public string OrderNum { get; set; }

        public decimal TotalPayableAmount { get; set; }

        public decimal ActualPaidAmount { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime OrderTime { get; set; }

        public int TransferPaymentId { get; set; }

        public bool IsEstablished { get; set; }

        public int? MileRedemption { get; set; }

        public int TotalGeneratedMile { get; set; }

        public bool IsInvoiced { get; set; }

        public virtual AirFlight AirFlight { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampaignsFlightCouponsUsageHistory> CampaignsFlightCouponsUsageHistories { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketCancel> TicketCancels { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketDetail> TicketDetails { get; set; }

        public virtual TransferPayment TransferPayment { get; set; }
    }
}
