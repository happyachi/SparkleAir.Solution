namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PermissionPageInfos")]
    public partial class PermissionPageInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PermissionPageInfo()
        {
            PermissionSettings = new HashSet<PermissionSetting>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string PageNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string PageName { get; set; }

        [Required]
        [StringLength(100)]
        public string PageDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermissionSetting> PermissionSettings { get; set; }
    }
}
