using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Entity.CompanyAndPermission
{
    public class CompanyStaffLoginLogEntity
    {
        public int Id { get; set; }

        public int CompanyStaffId { get; set; }

        public string CompanyStaffName { get; set; }

        public DateTime LoginTime { get; set; }

        public DateTime? LogoutTime { get; set; }

        public string IPAddress { get; set; }

        public bool LoginStatus { get; set; }
    }
}
