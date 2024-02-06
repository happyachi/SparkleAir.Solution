using SparkleAir.Infa.Utility.Helper;
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
        [Required(ErrorMessage = DAHelper.Required)]
        public string Name { get; set; }

        
        [Display(Name = "活動期間")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = DAHelper.Required)]
        public DateTime DateStart { get; set; }

        [Display(Name = "活動結束日期")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateEnd { get; set; }

        [Display(Name = "最新更新日期")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        [Display(Name = "狀態")]
        public string Status { get; set; }

        [Display(Name = "折扣金額或百分比")]
        [Required(ErrorMessage = DAHelper.Required)]
        public decimal DiscountValue { get; set; }

        [Display(Name = "可使用數量")]
        [Required(ErrorMessage = DAHelper.Required)]
        public int DiscountQuantity { get; set; }

        [Display(Name = "剩餘可使用數量")]
        public int AvailableQuantity { get; set; }

        [Display(Name = "最低消費金額")]
        public int? MinimumOrderValue { get; set; }

        [Display(Name = "單筆最高折扣金額")]
        public int MaximumDiscountAmount { get; set; }

        [Display(Name = "折扣碼")]
        [StringLength(16, ErrorMessage = DAHelper.StringLength)]
        public string Code { get; set; }


        [Display(Name = "優惠券顯示設定")]
        public bool DisplayDescription { get; set; }

        [Display(Name = "會員篩選")]
        public string MemberCriteria { get; set; }

        [Display(Name = "航班篩選")]
        public string AirFlightsCriteria { get; set; }

        [Display(Name = "折扣類型")]
        public string Type { get; set; }

        //public virtual ICollection<CampaignsCouponAirFlight> CampaignsCouponAirFlights { get; set; }

        //public virtual ICollection<CampaignsCouponMember> CampaignsCouponMembers { get; set; }

        //public virtual ICollection<CampaignsFlightCouponsUsageHistory> CampaignsFlightCouponsUsageHistories { get; set; }
    }
}