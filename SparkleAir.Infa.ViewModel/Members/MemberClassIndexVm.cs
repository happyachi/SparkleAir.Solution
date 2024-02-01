using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.Members
{
    public class MemberClassIndexVm
    {
        public int Id { get; set; }

        [Display(Name = "等級名稱")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string Name { get; set; }

        [Display(Name = "等級排序")]
        [Required(ErrorMessage = "{0}必填")]
        public int ClassOrder { get; set; }

        [Display(Name = "里程區間開始")]
        [Required(ErrorMessage = "{0}必填")]
        public int MileageStart { get; set; }

        [Display(Name = "里程區間結束")]
        [Required(ErrorMessage = "{0}必填")]
        public int MileageEnd { get; set; }
    }
}
