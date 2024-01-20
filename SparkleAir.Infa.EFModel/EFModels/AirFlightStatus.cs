namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AirFlightStatuses")]
    public partial class AirFlightStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AirFlightStatus()
        {
            AirTakeOffStatuses = new HashSet<AirTakeOffStatus>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AirTakeOffStatus> AirTakeOffStatuses { get; set; }
    }
}
