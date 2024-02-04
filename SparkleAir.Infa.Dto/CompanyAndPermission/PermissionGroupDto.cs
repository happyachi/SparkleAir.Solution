using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Dto.CompanyAndPermission
{
    public class PermissionGroupDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Ddescribe { get; set; }

        public string Criteria { get; set; }

        public List<string> PermissionSettingPageName { get; set; }

        public List<int> PermissionSettingPageId { get; set; }

        public string PermissionSettingPageIdString { get; set; }
    }
}
