namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AirType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AirType()
        {
            AirCabinSeats = new HashSet<AirCabinSeat>();
            AirOwns = new HashSet<AirOwn>();
            SeatGroups = new HashSet<SeatGroup>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string FlightModel { get; set; }

        public int TotalSeat { get; set; }

        public int MaxMile { get; set; }

        public int MaxWeight { get; set; }

        [Required]
        [StringLength(30)]
        public string ManufactureCompany { get; set; }

        [StringLength(1000)]
        public string Introduction { get; set; }

        [StringLength(300)]
        public string Img { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AirCabinSeat> AirCabinSeats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AirOwn> AirOwns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeatGroup> SeatGroups { get; set; }
    }
}
