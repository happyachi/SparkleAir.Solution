using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.CompanyAndPermission
{
    public class CompanyStaffLoginVm
    {
        [Display(Name = "帳號")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string Account { get; set; }

        [Display(Name = "密碼")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
