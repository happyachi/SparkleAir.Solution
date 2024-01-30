namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TFReserve
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TFReserve()
        {
            TFOrderStatuses = new HashSet<TFOrderStatus>();
            TFReservelists = new HashSet<TFReservelist>();
        }

        public int Id { get; set; }

        public int MemberId { get; set; }

        public int? Discount { get; set; }

        public int TotalPrice { get; set; }

        public int TransferPaymentId { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TFOrderStatus> TFOrderStatuses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TFReservelist> TFReservelists { get; set; }

        public virtual TransferPayment TransferPayment { get; set; }
    }
}
