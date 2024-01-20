namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CompanyStaffsChangePasswordLog
    {
        public int Id { get; set; }

        public int CompanyStaffId { get; set; }

        [Required]
        [StringLength(16)]
        public string Password { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdateTime { get; set; }

        public virtual CompanyStaff CompanyStaff { get; set; }
    }
}
