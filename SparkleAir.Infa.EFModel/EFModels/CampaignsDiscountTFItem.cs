namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CampaignsDiscountTFItem
    {
        public int Id { get; set; }

        public int CampaignsDiscountId { get; set; }

        public int TFItemId { get; set; }

        public virtual CampaignsDiscount CampaignsDiscount { get; set; }

        public virtual TFItem TFItem { get; set; }
    }
}
