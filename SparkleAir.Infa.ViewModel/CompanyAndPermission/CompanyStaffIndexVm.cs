using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.CompanyAndPermission
{
    public class CompanyStaffIndexVm
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "帳號")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string Account { get; set; }

        [Display(Name = "密碼")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string Password { get; set; }

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

        [Display(Name = "部門名稱")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string CompanyDepartmentName { get; set; }

        [Display(Name = "職位名稱")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string JobTitle { get; set; }

        [Display(Name = "狀態")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string Status { get; set; }

        [Display(Name = "註冊時間")]
        [Required(ErrorMessage = "{0}必填")]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationTime { get; set; }
    }
}
