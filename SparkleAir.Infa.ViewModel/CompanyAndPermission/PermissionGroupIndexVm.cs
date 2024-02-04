using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.CompanyAndPermission
{
    public class PermissionGroupIndexVm
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "群組名稱")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string Name { get; set; }

        [Display(Name = "群組描述")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(100)]
        public string Ddescribe { get; set; }

        [Display(Name = "篩選條件")]
        public string Criteria { get; set; }

        public List<string> PermissionSettingPageName { get; set; }

        public List<int> PermissionSettingPageId { get; set; }

        public string PermissionSettingPageIdString { get; set; }

    }
}
