﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SparkleAir.FrontEnd.Site.Models.ViewModels.Campaigns
{
    public class CampaignsCouponIndexVm
    {
        public int Id { get; set; }

        [Display(Name = "優惠券名稱")]
        public string Name { get; set; }

        [Display(Name = "活動起始日")]
        public DateTime DateStart { get; set; }

        [Display(Name = "活動終止日")]
        public DateTime DateEnd { get; set; }

        [Display(Name = "創建日期")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "狀態")]
        public string Status { get; set; }

        [Display(Name = "折扣碼")]
        [MaxLength(12)]
        public string Code { get; set; }

        [Display(Name = "折扣類型")]
        public string Type { get; set; }

    }
}