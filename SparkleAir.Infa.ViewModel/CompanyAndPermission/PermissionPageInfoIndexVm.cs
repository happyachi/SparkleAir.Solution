using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.CompanyAndPermission
{
    public class PermissionPageInfoIndexVm
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "頁面編號")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(50)]
        public string PageNumber { get; set; }

        [Display(Name = "頁面名稱")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string PageName { get; set; }

        [Display(Name = "頁面描述")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(100)]
        public string PageDescription { get; set; }
    }
}
