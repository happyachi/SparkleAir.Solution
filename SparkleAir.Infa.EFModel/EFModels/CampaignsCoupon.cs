

namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
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
     
        public string Name { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public DateTime DateCreated { get; set; }

        public string Status { get; set; }

        public decimal DiscountValue { get; set; }

        public int DiscountQuantity { get; set; }

        public int AvailableQuantity { get; set; }

        public int? MinimumOrderValue { get; set; }

        public int MaximumDiscountAmount { get; set; }

        public string Code { get; set; }

        public bool DisplayDescription { get; set; }

        public string MemberCriteria { get; set; }

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