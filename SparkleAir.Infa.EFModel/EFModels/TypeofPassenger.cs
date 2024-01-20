namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TypeofPassenger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeofPassenger()
        {
            TicketDetails = new HashSet<TicketDetail>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(5)]
        public string PassengerType { get; set; }

        public int MinAge { get; set; }

        public int MaxAge { get; set; }

        public decimal PricePercent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketDetail> TicketDetails { get; set; }
    }
}
