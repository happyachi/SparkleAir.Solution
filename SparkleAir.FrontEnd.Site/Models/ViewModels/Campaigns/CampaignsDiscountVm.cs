using SparkleAir.Infa.EFModel.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SparkleAir.FrontEnd.Site.Models.ViewModels.Campaigns
{
    public class CampaignsDiscountVm
    {
        [Display(Name = "行銷活動")]
        public virtual Campaign Campaign { get; set; }

        [Display(Name = "促銷名稱")]
        public string Name { get; set; }

        [Display(Name = "活動期間")]
        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        //public DateTime DateCreated { get; set; }

        [Display(Name = "狀態")]
        public string Status { get; set; }

        [Display(Name = "折扣金額或百分比")]
        public decimal DiscountValue { get; set; }

        [Display(Name = "折扣門檻")]
        public decimal Value { get; set; }

        [Display(Name = "商品件數")]
        public decimal BundleSKUs { get; set; }

        [Display(Name = "會員篩選")]
        public string MemberCriteria { get; set; }

        [Display(Name = "商品篩選")]
        public string TFItemsCriteria { get; set; }

        public virtual ICollection<CampaignsDiscountMember> CampaignsDiscountMembers { get; set; }

        public virtual ICollection<CampaignsDiscountTFItem> CampaignsDiscountTFItems { get; set; }

        public virtual ICollection<CampaignsTFDiscountUsageHistory> CampaignsTFDiscountUsageHistories { get; set; }
    }
}