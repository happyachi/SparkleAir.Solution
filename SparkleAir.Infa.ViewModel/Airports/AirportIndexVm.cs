using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.Airports
{
    public class AirportIndexVm
    {
        public int Id { get; set; }

        [Display(Name = "代號")] 
        public string Lata { get; set; }

        [Display(Name = "座標")] 
        public string Gps { get; set; }

        [Display(Name = "國家")]
        public string Country { get; set; }

        [Display(Name = "城市")]
        public string City { get; set; }

        [Display(Name = "機場名稱")]
        public string AirPortName { get; set; }


        [Display(Name = "時區")]
        public int TimeArea { get; set; }

        [Display(Name = "區域")]
        public int Zone { get; set; }

        [Display(Name = "城市簡介")]
        public string CityIntroduction { get; set; }

        [Display(Name = "洲別")]
        public string Continent { get; set; }

        [Display(Name = "圖片")]
        public string Img { get; set; }
    }
}
