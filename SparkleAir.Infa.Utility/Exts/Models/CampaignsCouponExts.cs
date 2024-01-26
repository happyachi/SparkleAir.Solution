﻿using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Utility.Exts.Models
{
    public static class CampaignsCouponExts
    {
        public static CampaignsCouponEntity ToEntity(this CampaignsCoupon coupon)
        {
            CampaignsCouponEntity campaignsCouponEntity = new CampaignsCouponEntity(
               coupon.Id,
               coupon.Name,
               coupon.CampaignId,
               coupon.DateStart,
               coupon.DateEnd,
               coupon.DateCreated,
               coupon.Status,
               coupon.DiscountQuantity,
               coupon.DiscountValue,
               coupon.AvailableQuantity,
               coupon.MinimumOrderValue,
               coupon.MaximumDiscountAmount,
               coupon.Code,
               coupon.DisplayDescription,
               coupon.MemberCriteria,
               coupon.AirFlightsCriteria,
               coupon.Campaign
            );  
            return campaignsCouponEntity;
        }
    }
}
