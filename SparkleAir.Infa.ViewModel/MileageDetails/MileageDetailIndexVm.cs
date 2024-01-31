using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.MileageDetails
{
    public class MileageDetailIndexVm
    {
        public int Id { get; set; }

        [Display(Name = "會員ID")]
        [Required]
        public int MermberIsd { get; set; }

        [Display(Name = "總里程")]
        [Required]
        public int TotalMile { get; set; }

        [Display(Name = "原始里程")]
        [Required]
        public int OriginalMile { get; set; }

        [Display(Name = "更改里程")]
        [Required]
        public int ChangeMile { get; set; }

        [Display(Name = "最終里程")]
        [Required]
        public int FinalMile { get; set; }

        [Display(Name = "里程效期")]
        [Required]
        public DateTime MileValidity { get; set; }

        [Display(Name = "里程更動原因")]
        [Required]
        public string MileReason { get; set; }

        [Display(Name = "訂單編號")]
        [Required]
        public string OrderNumber { get; set; }

        [Display(Name = "更改時間")]
        [Required]
        public DateTime ChangeTime { get; set; }
    }
}
