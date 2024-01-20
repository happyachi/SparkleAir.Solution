namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CampaignsCoupon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CampaignsCoupon()
        {
            CampaignsCouponAirFlights = new HashSet<CampaignsCouponAirFlight>();
            CampaignsCouponMembers = new HashSet<CampaignsCouponMember>();
            CampaignsFlightCouponsUsageHistories = new HashSet<CampaignsFlightCouponsUsageHistory>();
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

        public int DiscountQuantity { get; set; }

        public int AvailableQuantity { get; set; }

        public int? MinimumOrderValue { get; set; }

        public int MaximumDiscountAmount { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        public bool DisplayDescription { get; set; }

        [StringLength(4000)]
        public string MemberCriteria { get; set; }

        [StringLength(4000)]
        public string AirFlightsCriteria { get; set; }

        public virtual Campaign Campaign { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampaignsCouponAirFlight> CampaignsCouponAirFlights { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampaignsCouponMember> CampaignsCouponMembers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampaignsFlightCouponsUsageHistory> CampaignsFlightCouponsUsageHistories { get; set; }
    }
}
