using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.Members
{
    public class MemberUpdateVm
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "是否授權")]
        [Required(ErrorMessage = "{0}必填")]
        public bool? IsAllow { get; set; }

    }
}
