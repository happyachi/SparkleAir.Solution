namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CompanyStaff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompanyStaff()
        {
            CompanyStaffLoginLogs = new HashSet<CompanyStaffLoginLog>();
            CompanyStaffsChangePasswordLogs = new HashSet<CompanyStaffsChangePasswordLog>();
            Messages = new HashSet<Message>();
            PermissionGroupsAddStaffs = new HashSet<PermissionGroupsAddStaff>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Account { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(10)]
        public string LastName { get; set; }

        public int CompanyJobId { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime RegistrationTime { get; set; }

        public virtual CompanyJob CompanyJob { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyStaffLoginLog> CompanyStaffLoginLogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyStaffsChangePasswordLog> CompanyStaffsChangePasswordLogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermissionGroupsAddStaff> PermissionGroupsAddStaffs { get; set; }
    }
}
