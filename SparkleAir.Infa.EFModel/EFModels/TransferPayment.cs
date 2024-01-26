namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TransferPayment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TransferPayment()
        {
            AirBookSeats = new HashSet<AirBookSeat>();
            LuggageOrders = new HashSet<LuggageOrder>();
            TFReserves = new HashSet<TFReserve>();
            Tickets = new HashSet<Ticket>();
            TransferRefunds = new HashSet<TransferRefund>();
        }

        public int Id { get; set; }

        public int TransferMethodsId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime PaymentDate { get; set; }

        public decimal PaymentAmount { get; set; }

        [StringLength(1000)]
        public string Info { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AirBookSeat> AirBookSeats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuggageOrder> LuggageOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TFReserve> TFReserves { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual TransferMethod TransferMethod { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransferRefund> TransferRefunds { get; set; }
    }
}
