namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AirPort
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AirPort()
        {
            AirFlightManagements = new HashSet<AirFlightManagement>();
            AirFlightManagements1 = new HashSet<AirFlightManagement>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Lata { get; set; }

        [Required]
        [StringLength(50)]
        public string Gps { get; set; }

        [Required]
        [StringLength(20)]
        public string Country { get; set; }

        [Required]
        [StringLength(20)]
        public string City { get; set; }

        [Required]
        [StringLength(20)]
        public string AirPortName { get; set; }

        public int TimeArea { get; set; }

        public int Zone { get; set; }

        [Required]
        [StringLength(60)]
        public string CityIntroduction { get; set; }

        [StringLength(60)]
        public string Img { get; set; }

        [Required]
        [StringLength(20)]
        public string Continent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AirFlightManagement> AirFlightManagements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AirFlightManagement> AirFlightManagements1 { get; set; }
    }
}
