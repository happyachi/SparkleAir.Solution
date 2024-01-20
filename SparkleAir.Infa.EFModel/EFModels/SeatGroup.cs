namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SeatGroup
    {
        public int Id { get; set; }

        public int AirTypeId { get; set; }

        public int SeatAreaId { get; set; }

        [Required]
        [StringLength(10)]
        public string SeatNum { get; set; }

        public virtual AirType AirType { get; set; }

        public virtual SeatArea SeatArea { get; set; }
    }
}
