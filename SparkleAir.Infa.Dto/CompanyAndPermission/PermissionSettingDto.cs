using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Dto.CompanyAndPermission
{
    public class PermissionSettingDto
    {
        public int Id { get; set; }

        public int PermissionGroupsId { get; set; }

        public string PermissionGroupsName { get; set; }

        public int PermissionPageInfoId { get; set; }

        public string PermissionPageInfoName { get; set; }

        public bool ViewPermission { get; set; }

        public bool EditPermission { get; set; }

        public bool CreatePermission { get; set; }

        public bool DeletePermission { get; set; }
    }
}
