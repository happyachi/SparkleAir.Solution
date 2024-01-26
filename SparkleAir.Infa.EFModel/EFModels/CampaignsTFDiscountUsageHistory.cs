namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CampaignsTFDiscountUsageHistory")]
    public partial class CampaignsTFDiscountUsageHistory
    {
        public int Id { get; set; }

        public int CampaignsDiscountsId { get; set; }

        public int TFReservelistId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UsedDate { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateCreated { get; set; }

        public int OriginalPrice { get; set; }

        public int DiscountAmount { get; set; }

        public int DiscountedPrice { get; set; }

        public virtual CampaignsDiscount CampaignsDiscount { get; set; }

        public virtual TFReservelist TFReservelist { get; set; }
    }
}
