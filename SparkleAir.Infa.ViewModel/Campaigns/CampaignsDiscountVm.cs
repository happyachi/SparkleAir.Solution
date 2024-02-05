using SparkleAir.Infa.EFModel.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SparkleAir.FrontEnd.Site.Models.ViewModels.Campaigns
{
    public class CampaignsDiscountVm

    {
        public int Id { get; set; }

        [Display(Name = "行銷活動編號")]
        public int CampaignId { get; set; }

        [Display(Name = "行銷活動")]
        public string  Campaign { get; set; }

        [Display(Name = "促銷名稱")]
        [Required(ErrorMessage = "{0}必填")]
        public string Name { get; set; }

        [Display(Name = "活動期間")]
        [Required(ErrorMessage = "{0}必填")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateStart { get; set; }

        [Display(Name = "活動結束日期")]
        [Required(ErrorMessage = "{0}必填")]
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
        [Required(ErrorMessage = "{0}必填")]
        public decimal DiscountValue { get; set; }

        [Display(Name = "最低消費金額")]
        [Required(ErrorMessage = "{0}必填")]
        public decimal Value { get; set; }

        [Display(Name = "最低購買數量")]
        public decimal? BundleSKUs { get; set; }

        [Display(Name = "會員篩選")]
        public string MemberCriteria { get; set; }

        [Display(Name = "商品篩選")]
        public string TFItemsCriteria { get; set; }

        [Display(Name = "折扣類型")]
        public string Type { get; set; }

        //public virtual ICollection<CampaignsDiscountMember> CampaignsDiscountMembers { get; set; }

        //public virtual ICollection<CampaignsDiscountTFItem> CampaignsDiscountTFItems { get; set; }

        //public virtual ICollection<CampaignsTFDiscountUsageHistory> CampaignsTFDiscountUsageHistories { get; set; }
    }
}