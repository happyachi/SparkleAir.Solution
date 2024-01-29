using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.CompanyAndPermission
{
    public class CompanyStaffsChangePasswordLogIndexVm
    {
        public int Id { get; set; }

        public int CompanyStaffId { get; set; }

        public string CompanyStaffName { get; set; }


        public DateTime UpdateTime { get; set; }
    }
}
