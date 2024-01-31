using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.Luggage
{
    public class LuggageIndexVm
    {
        public int Id { get; set; }

        [Display(Name = "航班管理ID")]
        public int AirFlightManagementsId { get; set; }

        [Display(Name = "原價")]
        public int OriginalPrice { get; set; }

        [Display(Name = "預定價")]
        public int BookPrice { get; set; }
    }
}
