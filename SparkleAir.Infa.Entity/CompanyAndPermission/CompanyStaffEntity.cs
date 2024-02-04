using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Entity.CompanyAndPermission
{
    public class CompanyStaffEntity
    {
        public int Id { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompanyJobId { get; set; }

        public string CompanyDepartmentName { get; set; }

        public string JobTitle { get; set; }

        public string Status { get; set; }

        public DateTime RegistrationTime { get; set; }

        public List<string> RoleGroupName { get; set; }
        public List<int> RoleGroupId { get; set; }

    }
}
