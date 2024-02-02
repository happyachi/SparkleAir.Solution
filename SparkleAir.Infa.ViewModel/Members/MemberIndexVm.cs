using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.Members
{
    public class MemberIndexVm
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "等級ID")]
        [Required(ErrorMessage = "{0}必填")]
        public int MemberClassId { get; set; }

        [Display(Name = "等級名稱")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string MemberClassName { get; set; }

        [Display(Name = "國籍ID")]
        [Required(ErrorMessage = "{0}必填")]
        public int CountryId { get; set; }

        [Display(Name = "國籍")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string CountryName { get; set; }

        [Display(Name = "中文姓")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string ChineseLastName { get; set; }

        [Display(Name = "中文名")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string ChineseFirstName { get; set; }

        [Display(Name = "英文姓")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string EnglishLastName { get; set; }

        [Display(Name = "英文名")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string EnglishFirstName { get; set; }

        [Display(Name = "性別")]
        [Required(ErrorMessage = "{0}必填")]
        public bool Gender { get; set; }

        [Display(Name = "生日")]
        [Required(ErrorMessage = "{0}必填")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "手機")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string Phone { get; set; }

        [Display(Name = "電子信箱")]
        [Required(ErrorMessage = "{0}必填")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "總里程數")]
        [Required(ErrorMessage = "{0}必填")]
        public int TotalMileage { get; set; }

        [Display(Name = "護照號碼")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string PassportNumber { get; set; }
    }
}
