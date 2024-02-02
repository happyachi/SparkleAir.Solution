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
        [Display(Name = "ID")]

        public int Id { get; set; }

        [Display(Name = "職員ID")]
        [Required(ErrorMessage = "{0}必填")]
        public int CompanyStaffId { get; set; }

        [Display(Name = "職員名稱")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string CompanyStaffName { get; set; }

        [Display(Name = "等級名稱")]
        [Required(ErrorMessage = "{0}必填")]
        [DataType(DataType.DateTime)]
        public DateTime UpdateTime { get; set; }
    }
}
