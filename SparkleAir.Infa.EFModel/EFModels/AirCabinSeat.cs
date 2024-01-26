namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AirCabinSeat
    {
        public int Id { get; set; }

        public int AirTypeId { get; set; }

        public int AirCabinId { get; set; }

        public int? SeatNum { get; set; }

        public virtual AirCabin AirCabin { get; set; }

        public virtual AirType AirType { get; set; }
    }
}
