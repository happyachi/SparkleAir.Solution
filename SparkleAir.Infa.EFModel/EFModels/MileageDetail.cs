namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MileageDetail
    {
        public int Id { get; set; }

        public int MermberIsd { get; set; }

        public int TotalMile { get; set; }

        public int OriginalMile { get; set; }

        public int ChangeMile { get; set; }

        public int FinalMile { get; set; }

        public DateTime MileValidity { get; set; }

        [Required]
        [StringLength(20)]
        public string MileReason { get; set; }

        [Required]
        [StringLength(20)]
        public string OrderNumber { get; set; }

        public DateTime ChangeTime { get; set; }

        public virtual Member Member { get; set; }
    }
}
