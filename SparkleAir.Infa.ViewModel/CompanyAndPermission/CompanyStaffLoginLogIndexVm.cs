using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.CompanyAndPermission
{
    public class CompanyStaffLoginLogIndexVm
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "職員ID")]
        [Required(ErrorMessage = "{0}必填")]
        public int CompanyStaffId { get; set; }

        [Display(Name = "職員姓名")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string CompanyStaffName { get; set; }

        [Display(Name = "登入時間")]
        [Required(ErrorMessage = "{0}必填")]
        [DataType(DataType.DateTime)]
        public DateTime LoginTime { get; set; }

        [Display(Name = "登出時間")]
        [Required(ErrorMessage = "{0}必填")]
        [DataType(DataType.DateTime)]
        public DateTime? LogoutTime { get; set; }

        [Display(Name = "IP位置")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string IPAddress { get; set; }

        [Display(Name = "登入狀態")]
        [Required(ErrorMessage = "{0}必填")]
        public bool LoginStatus { get; set; }
    }
}
