using SparkleAir.Infa.EFModel.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkleAir.FrontEnd.Site.Models.ViewModels.Campaigns
{
    public class CampaignsDiscountIndexVm
    {
        public int Id { get; set; }

        public int CampaignId { get; set; }

        public string Name { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public DateTime DateCreated { get; set; }

        public string Status { get; set; }

    }
}