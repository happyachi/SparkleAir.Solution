namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PermissionGroupsAddStaff
    {
        public int Id { get; set; }

        public int PermissionGroupsId { get; set; }

        public int CompanyStaffsId { get; set; }

        public virtual CompanyStaff CompanyStaff { get; set; }

        public virtual PermissionGroup PermissionGroup { get; set; }
    }
}
