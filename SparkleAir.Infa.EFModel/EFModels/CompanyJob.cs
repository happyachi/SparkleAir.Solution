namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CompanyJob
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompanyJob()
        {
            CompanyStaffs = new HashSet<CompanyStaff>();
        }

        public int Id { get; set; }

        public int CompanyDepartmentId { get; set; }

        [Required]
        [StringLength(10)]
        public string JobTitle { get; set; }

        public int Rank { get; set; }

        public virtual CompanyDepartment CompanyDepartment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyStaff> CompanyStaffs { get; set; }
    }
}
