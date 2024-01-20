namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AirOwn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AirOwn()
        {
            AirFlights = new HashSet<AirFlight>();
        }

        public int Id { get; set; }

        public int AirTypeId { get; set; }

        [Required]
        [StringLength(30)]
        public string RegistrationNum { get; set; }

        [Required]
        [StringLength(30)]
        public string Status { get; set; }

        public int ManufactureYear { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AirFlight> AirFlights { get; set; }

        public virtual AirType AirType { get; set; }
    }
}
