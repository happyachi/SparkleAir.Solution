using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.MealMessage
{
    public class AirMealVm
    {
        [Display(Name = "流水號")]
        public int Id { get; set; }

        [Display(Name="餐點名稱")]
        public string Name { get; set; }

        [Display(Name = "提供艙等")]
        public int AirCabinId { get; set; }

        [Display(Name = "餐點內容簡介")]
        [MaxLength(300)]
        public string MealContent { get; set; }

        [Display(Name = "圖片上傳")]
        [MaxLength(3000)]
        public string Image { get; set; }

        [Display(Name = "參考圖片")]
        [MaxLength(3000)]
        public string UploadedImage { get; set; }

        //[MaxLength(100)]
        //public byte[] ImageBit { get; set; }

        [Required]
        [Display(Name = "分類")]
        [MaxLength(10)]
        public string Category { get; set; }
    }
}
