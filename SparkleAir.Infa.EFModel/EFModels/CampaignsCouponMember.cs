namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CampaignsCouponMember
    {
        public int Id { get; set; }

        public int CampaignsCouponId { get; set; }

        public int MemberId { get; set; }

        public virtual CampaignsCoupon CampaignsCoupon { get; set; }

        public virtual Member Member { get; set; }
    }
}
