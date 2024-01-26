namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AirMeal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AirMeal()
        {
            TicketInvoicingDetails = new HashSet<TicketInvoicingDetail>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int AirCabinId { get; set; }

        [StringLength(300)]
        public string MealContent { get; set; }

        [StringLength(3000)]
        public string Image { get; set; }

        [MaxLength(100)]
        public byte[] ImageBit { get; set; }

        [Required]
        [StringLength(10)]
        public string Category { get; set; }

        public virtual AirCabin AirCabin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketInvoicingDetail> TicketInvoicingDetails { get; set; }
    }
}
