using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.CompanyAndPermission
{
    public class PermissionSettingIndexVm
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

        [Display(Name = "頁面ID")]
        [Required(ErrorMessage = "{0}必填")]
        public int PermissionPageInfoId { get; set; }

        [Display(Name = "頁面名稱")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string PermissionPageInfoName { get; set; }

        [Display(Name = "查看權限")]
        [Required(ErrorMessage = "{0}必填")]
        public bool ViewPermission { get; set; }

        [Display(Name = "修改權限")]
        [Required(ErrorMessage = "{0}必填")]
        public bool EditPermission { get; set; }

        [Display(Name = "新增權限")]
        [Required(ErrorMessage = "{0}必填")]
        public bool CreatePermission { get; set; }

        [Display(Name = "刪除權限")]
        [Required(ErrorMessage = "{0}必填")]
        public bool DeletePermission { get; set; }
    }
}
