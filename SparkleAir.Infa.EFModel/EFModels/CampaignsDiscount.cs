namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CampaignsDiscount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CampaignsDiscount()
        {
            CampaignsDiscountMembers = new HashSet<CampaignsDiscountMember>();
            CampaignsDiscountTFItems = new HashSet<CampaignsDiscountTFItem>();
            CampaignsTFDiscountUsageHistories = new HashSet<CampaignsTFDiscountUsageHistory>();
        }

        public int Id { get; set; }

        public int CampaignId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateStart { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateEnd { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public decimal DiscountValue { get; set; }

        public decimal Value { get; set; }

        public decimal? BundleSKUs { get; set; }

        [StringLength(4000)]
        public string MemberCriteria { get; set; }

        [StringLength(4000)]
        public string TFItemsCriteria { get; set; }

        public virtual Campaign Campaign { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampaignsDiscountMember> CampaignsDiscountMembers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampaignsDiscountTFItem> CampaignsDiscountTFItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampaignsTFDiscountUsageHistory> CampaignsTFDiscountUsageHistories { get; set; }
    }
}
