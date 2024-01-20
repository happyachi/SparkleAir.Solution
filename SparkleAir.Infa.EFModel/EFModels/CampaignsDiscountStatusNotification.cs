namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CampaignsDiscountStatusNotification
    {
        public int Id { get; set; }

        public int CampaignsDiscountId { get; set; }

        public int MemberId { get; set; }

        public bool IsNotifiedByEmail { get; set; }

        public bool IsNotifiedByBell { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? NotificationTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ReadTime { get; set; }

        public virtual CampaignsDiscountStatusNotification CampaignsDiscountStatusNotifications1 { get; set; }

        public virtual CampaignsDiscountStatusNotification CampaignsDiscountStatusNotification1 { get; set; }
    }
}
