namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AriTicketPrice
    {
        public int Id { get; set; }

        public int AirCabinRuleId { get; set; }

        public int AirFlightManagementId { get; set; }

        public decimal Price { get; set; }

        public virtual AirCabinRule AirCabinRule { get; set; }

        public virtual AirFlightManagement AirFlightManagement { get; set; }
    }
}
