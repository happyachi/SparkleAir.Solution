using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.Members
{
    public class MemberLoginLogIndexVm
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "會員ID")]
        [Required(ErrorMessage = "{0}必填")]
        public int MemberId { get; set; }

        public string MemberName { get; set; }

        [Display(Name = "登入時間")]
        [Required(ErrorMessage = "{0}必填")]
        [DataType(DataType.DateTime)]
        public DateTime Logintime { get; set; }

        [Display(Name = "登出時間")]
        [Required(ErrorMessage = "{0}必填")]
        [DataType(DataType.DateTime)]
        public DateTime? LogoutTime { get; set; }

        [Display(Name = "IP位置")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(20)]
        public string IPAddress { get; set; }

        [Display(Name = "登入狀態")]
        [Required(ErrorMessage = "{0}必填")]
        public bool LoginStatus { get; set; }
    }
}
