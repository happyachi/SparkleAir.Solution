using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.TaxFree
{
    public class TFItemVm
    {
        public int Id { get; set; }

        public int TFCategoriesId { get; set; }

        [Display(Name = "商品分類")]
        public string TFCategoriesName { get; set; }
        [Display(Name = "商品名稱")]
        public string Name { get; set; }

        [Display(Name = "商品編號")]
        public string SerialNumber { get; set; }
        [Display(Name = "商品圖片")]
        public string Image { get; set; }
        [Display(Name = "商品數量")]
        public int Quantity { get; set; }
        [Display(Name = "商品單價")]
        public int UnitPrice { get; set; }

        [Display(Name = "商品描述")]
        public string Description { get; set; }
        [Display(Name = "上架狀態")]
        public bool IsPublished { get; set; }

        public string FileName { get; set; }    


    }

    
}
