using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Dto.CompanyAndPermission
{
    public class CompanyJobDto
    {
        public int Id { get; set; }

        public int CompanyDepartmentId { get; set; }

        public string CompanyDepartmentName { get; set; }


        public string JobTitle { get; set; }

        public int Rank { get; set; }
    }
}
