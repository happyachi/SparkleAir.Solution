using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.Campaigns;
using SparkleAir.Infa.Entity.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Utility.Exts.Models
{
    public static class CampaignsDiscountExts
    {
        public static CampaignsDiscountEntity ToEntity(this CampaignsDiscount discount) 
        {
            CampaignsDiscountEntity campaignsDiscountEntity = new CampaignsDiscountEntity
            (
             
             discount.CampaignId,
             discount.Name,
             discount.DateCreated,
             discount.DateStart,
             discount.DateEnd,
             discount.Status,
             discount.DiscountValue,
             discount.Value,
             discount.BundleSKUs,
             discount.MemberCriteria,
             discount.TFItemsCriteria,
             discount.Campaign.Type,
             discount.Id
            );

            return campaignsDiscountEntity;
        }
    }
}
