using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.Airtype_Owns
{
    public class PlaneVmIndex
    {
        public int Id { get; set; }

        [Display(Name = "機型")]
        [Required]
        [StringLength(30)]
        public string FlightModel { get; set; }


        [Display(Name = "製造公司")]
        [Required]
        [StringLength(30)]
        public string ManufactureCompany { get; set; }
    }
}

