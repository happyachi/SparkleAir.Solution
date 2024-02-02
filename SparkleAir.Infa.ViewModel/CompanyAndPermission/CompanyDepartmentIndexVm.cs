using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.CompanyAndPermission
{
    public class CompanyDepartmentIndexVm
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "部門名稱")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string Name { get; set; }
    }
}
