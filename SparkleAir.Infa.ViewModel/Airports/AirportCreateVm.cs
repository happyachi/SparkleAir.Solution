using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.Airports
{
    public class AirportCreateVm
    {
        public int Id { get; set; }

        [Display(Name = "代號")]
        [Required]
        public string Lata { get; set; }

        [Display(Name = "座標")]
        [Required]
        public string Gps { get; set; }

        [Display(Name = "國家")]
        [Required]
        public string Country { get; set; }

        [Display(Name = "城市")]
        [Required]
        public string City { get; set; }

        [Display(Name = "機場名稱")]
        [Required]
        public string AirPortName { get; set; }


        [Display(Name = "時區")]
        [Required]
        public int TimeArea { get; set; }

        [Display(Name = "區域")]
        [Required]
        public int Zone { get; set; }

        [Display(Name = "城市簡介")]
        [Required]
        public string CityIntroduction { get; set; }

        [Display(Name = "圖片")]
        public string Img { get; set; }

        [Display(Name = "洲別")]
        [Required]
        public string Continent { get; set; }
    }
}
