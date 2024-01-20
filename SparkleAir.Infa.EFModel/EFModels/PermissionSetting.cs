namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PermissionSetting
    {
        public int Id { get; set; }

        public int PermissionGroupsId { get; set; }

        public int PermissionPageInfoId { get; set; }

        public bool ViewPermission { get; set; }

        public bool EditPermission { get; set; }

        public bool CreatePermission { get; set; }

        public bool DeletePermission { get; set; }

        public virtual PermissionGroup PermissionGroup { get; set; }

        public virtual PermissionPageInfo PermissionPageInfo { get; set; }
    }
}
