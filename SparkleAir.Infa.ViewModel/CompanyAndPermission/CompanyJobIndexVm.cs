using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.CompanyAndPermission
{
    public class CompanyJobIndexVm
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "部門ID")]
        [Required(ErrorMessage = "{0}必填")]
        public int CompanyDepartmentId { get; set; }

        [Display(Name = "部門名稱")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string CompanyDepartmentName { get; set; }

        [Display(Name = "職位名稱")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string JobTitle { get; set; }

        [Display(Name = "職級")]
        [Required(ErrorMessage = "{0}必填")]
        public int Rank { get; set; }
    }
}
