using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.Basics
{
    public class CountryIndexVm
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "中文國籍")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string ChineseName { get; set; }

        [Display(Name = "英文國籍")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10)]
        public string EnglishName { get; set; }
    }
}
