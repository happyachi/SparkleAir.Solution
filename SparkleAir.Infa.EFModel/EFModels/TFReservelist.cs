namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TFReservelist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TFReservelist()
        {
            CampaignsTFDiscountUsageHistories = new HashSet<CampaignsTFDiscountUsageHistory>();
        }

        public int Id { get; set; }

        public int TFItemsId { get; set; }

        public int Quantity { get; set; }

        public int UnitPrice { get; set; }

        public int Discount { get; set; }

        public int TotalPrice { get; set; }

        public int TFReserveId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampaignsTFDiscountUsageHistory> CampaignsTFDiscountUsageHistories { get; set; }

        public virtual TFItem TFItem { get; set; }

        public virtual TFReserve TFReserve { get; set; }
    }
}
