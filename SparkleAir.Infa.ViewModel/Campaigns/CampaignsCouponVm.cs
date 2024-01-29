using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SparkleAir.FrontEnd.Site.Models.ViewModels.Campaigns
{
    public class CampaignsCouponVm
    {
        public int Id { get; set; }

        public int CampaignId { get; set; }

        [Display(Name = "行銷活動")]
        public virtual string Campaign { get; set; }

        
        [Display(Name = "優惠券名稱")]
        [Required(ErrorMessage = "{0}必填")]
        public string Name { get; set; }

        
        [Display(Name = "活動期間")]
        [Required(ErrorMessage = "{0}必填")]
        public DateTime DateStart { get; set; }

        [Display(Name = "活動結束日期")]
        public DateTime DateEnd { get; set; }

        [Display(Name = "活動創建日")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "狀態")]
        public string Status { get; set; }

        [Display(Name = "折扣金額或百分比")]
        [Required(ErrorMessage = "{0}必填")]
        public decimal DiscountValue { get; set; }

        [Display(Name = "可使用數量")]
        [Required(ErrorMessage = "{0}必填")]
        public int DiscountQuantity { get; set; }

        [Display(Name = "剩餘可使用數量")]
        public int AvailableQuantity { get; set; }

        [Display(Name = "最低消費金額")]
        public int? MinimumOrderValue { get; set; }

        [Display(Name = "最高折扣金額")]
        public int MaximumDiscountAmount { get; set; }

        [Display(Name = "折扣碼")]
        public string Code { get; set; }
        [Display(Name = "優惠券顯示設定")]

        public bool DisplayDescription { get; set; }

        [Display(Name = "會員篩選")]
        public string MemberCriteria { get; set; }

        [Display(Name = "航班篩選")]
        public string AirFlightsCriteria { get; set; }

        //public virtual ICollection<CampaignsCouponAirFlight> CampaignsCouponAirFlights { get; set; }

        //public virtual ICollection<CampaignsCouponMember> CampaignsCouponMembers { get; set; }

        //public virtual ICollection<CampaignsFlightCouponsUsageHistory> CampaignsFlightCouponsUsageHistories { get; set; }
    }
}