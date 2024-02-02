﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.MealMessage
{
    public class AirMealVm
    {
        [Display(Name="餐點名稱")]
        public string Name { get; set; }

        [Display(Name = "提供艙等")]
        public int AirCabinId { get; set; }

        [Display(Name = "餐點內容簡介")]
        [MaxLength(300)]
        public string MealContent { get; set; }

        [MaxLength(3000)]
        public string Image { get; set; }


        //[MaxLength(100)]
        //public byte[] ImageBit { get; set; }

        [Required]
        [MaxLength(10)]
        public string Category { get; set; }
    }
}