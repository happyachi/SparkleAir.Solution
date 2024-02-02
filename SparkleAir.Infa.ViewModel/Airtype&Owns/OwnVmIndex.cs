using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.Airtype_Owns
{
    public class OwnVmIndex
    {
        public int Id { get; set; }

        [Display(Name = "機型名稱:")]
        public string FlightModel { get; set; }


        [Display(Name = "機型代號:")]
        public int AirTypeId { get; set; }


        [Display(Name = "註冊編號:")]
        [Required]
        [StringLength(30)]
        public string RegistrationNum { get; set; }

        [Display(Name = "目前狀態:")]
        [Required]
        [StringLength(30)]
        public string Status { get; set; }

        [Display(Name = "製造年份:")]
        public int ManufactureYear { get; set; }

    }
}
