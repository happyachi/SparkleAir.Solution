using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Dto.CompanyAndPermission
{
    public class CompanyStaffsChangePasswordLogDto
    {
        public int Id { get; set; }

        public int CompanyStaffId { get; set; }

        public string CompanyStaffName { get; set; }


        public DateTime UpdateTime { get; set; }
    }
}
