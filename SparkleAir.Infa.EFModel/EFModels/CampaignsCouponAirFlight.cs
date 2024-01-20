namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CampaignsCouponAirFlight
    {
        public int Id { get; set; }

        public int CampaignsCouponId { get; set; }

        public int AirFlightId { get; set; }

        public virtual AirFlight AirFlight { get; set; }

        public virtual CampaignsCoupon CampaignsCoupon { get; set; }
    }
}
