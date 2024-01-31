using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.Luggage
{
    public class LuggageCreateVm
    {
        public int Id { get; set; }

        [Display(Name = "航班管理ID")]
        [Required]
        public int AirFlightManagementsId { get; set; }

        [Display(Name = "原價")]
        [Required]
        public int OriginalPrice { get; set; }

        [Display(Name = "預定價")]
        [Required]
        public int BookPrice { get; set; }
    }
}
