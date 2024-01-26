namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AirCabinRule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AirCabinRule()
        {
            AriTicketPrices = new HashSet<AriTicketPrice>();
            TicketDetails = new HashSet<TicketDetail>();
        }

        public int Id { get; set; }

        public int AirCabinId { get; set; }

        [Required]
        [StringLength(10)]
        public string CabinCode { get; set; }

        public int Priority { get; set; }

        public int ShipmentWeight { get; set; }

        public int ShipmentCount { get; set; }

        public int CarryBagCount { get; set; }

        public int CarryBagWeight { get; set; }

        public bool PreSelectedSeat { get; set; }

        public double AccumulatedMile { get; set; }

        public bool MileUpgrade { get; set; }

        public int TicketVaildity { get; set; }

        public int RefundFee { get; set; }

        public int NoShowFee { get; set; }

        public bool FreeWifi { get; set; }

        public virtual AirCabin AirCabin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AriTicketPrice> AriTicketPrices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketDetail> TicketDetails { get; set; }
    }
}
