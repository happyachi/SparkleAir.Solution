namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CompanyStaffLoginLog
    {
        public int Id { get; set; }

        public int CompanyStaffId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Logintime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? LogoutTime { get; set; }

        [Required]
        [StringLength(17)]
        public string IPAddress { get; set; }

        public bool LoginStatus { get; set; }

        public virtual CompanyStaff CompanyStaff { get; set; }
    }
}
