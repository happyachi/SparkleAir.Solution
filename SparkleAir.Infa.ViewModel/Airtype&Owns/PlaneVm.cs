using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.Airtype_Owns
{
    public class PlaneVm
    {
        public int Id { get; set; }

        [Display(Name = "機型:")]
        [Required(ErrorMessage = "{0}必填")]
        [StringLength(30)]
        public string FlightModel { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "總座位數:")]
        public int TotalSeat { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "最大里程(公里):")]

        public int MaxMile { get; set; }


        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "最大起飛重量(公噸):")]
        public int MaxWeight { get; set; }
        [Display(Name = "製造公司:")]
        [Required(ErrorMessage = "{0}必填")]
        [StringLength(30)]
        public string ManufactureCompany { get; set; }

        [Display(Name = "簡介:")]
        [StringLength(1000)]
        public string Introduction { get; set; }

        [Display(Name = "圖片:")]
        [StringLength(300)]
        public string Img { get; set; }
    }
}
