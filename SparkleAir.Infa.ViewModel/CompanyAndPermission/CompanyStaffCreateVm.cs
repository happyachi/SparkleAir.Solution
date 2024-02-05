using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.CompanyAndPermission
{
    public class CompanyStaffCreateVm
    {

        [Display(Name = "名")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string FirstName { get; set; }

        [Display(Name = "姓")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string LastName { get; set; }

        [Display(Name = "職位ID")]
        [Required(ErrorMessage = "{0}必填")]
        public int CompanyJobId { get; set; }

    }
}
