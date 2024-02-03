using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.CompanyAndPermission
{
    public class PermissionGroupsAddStaffIndexVm
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "群組ID")]
        [Required(ErrorMessage = "{0}必填")]
        public int PermissionGroupsId { get; set; }

        [Display(Name = "群組名稱")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string PermissionGroupsName { get; set; }

        [Display(Name = "職員ID")]
        [Required(ErrorMessage = "{0}必填")]
        public int CompanyStaffsId { get; set; }

        [Display(Name = "職員名稱")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string CompanyStaffsName { get; set; }
    }
}
