namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TicketDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TicketDetail()
        {
            TicketInvoicingDetails = new HashSet<TicketInvoicingDetail>();
        }

        public int Id { get; set; }

        public int TicketId { get; set; }

        public int AirCabinRuleId { get; set; }

        public int TypeofPassengerId { get; set; }

        public decimal TicketAmount { get; set; }

        public int AccruedMile { get; set; }

        public virtual AirCabinRule AirCabinRule { get; set; }

        public virtual Ticket Ticket { get; set; }

        public virtual TypeofPassenger TypeofPassenger { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketInvoicingDetail> TicketInvoicingDetails { get; set; }
    }
}
