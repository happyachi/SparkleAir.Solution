namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AirFlightSeat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AirFlightSeat()
        {
            AirBookSeats = new HashSet<AirBookSeat>();
            TicketInvoicingDetails = new HashSet<TicketInvoicingDetail>();
        }

        public int Id { get; set; }

        public int AirFlightId { get; set; }

        public int AirCabinId { get; set; }

        [Required]
        [StringLength(10)]
        public string SeatNum { get; set; }

        public bool IsSeated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AirBookSeat> AirBookSeats { get; set; }

        public virtual AirCabin AirCabin { get; set; }

        public virtual AirFlight AirFlight { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketInvoicingDetail> TicketInvoicingDetails { get; set; }
    }
}
