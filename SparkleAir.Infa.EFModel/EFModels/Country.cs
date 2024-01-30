namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Country
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Country()
        {
            Members = new HashSet<Member>();
            TicketInvoicingDetails = new HashSet<TicketInvoicingDetail>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string ChineseName { get; set; }

        [Required]
        [StringLength(20)]
        public string EnglishName { get; set; }

        public int? OrderBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Member> Members { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketInvoicingDetail> TicketInvoicingDetails { get; set; }
    }
}
