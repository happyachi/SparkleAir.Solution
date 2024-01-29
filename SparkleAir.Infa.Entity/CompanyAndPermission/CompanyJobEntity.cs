using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Entity.CompanyAndPermission
{
    public class CompanyJobEntity
    {
        public int Id { get; set; }

        public int CompanyDepartmentId { get; set; }

        public string CompanyDepartmentName { get; set; }


        public string JobTitle { get; set; }

        public int Rank { get; set; }
    }
}
