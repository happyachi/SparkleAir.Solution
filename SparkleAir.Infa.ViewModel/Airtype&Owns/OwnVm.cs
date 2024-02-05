using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.Airtype_Owns
{
    public class OwnVm
    {
        public int Id { get; set; }

        [Display(Name = "機型代號:")]
        [Required(ErrorMessage = "{0}必填!請參考[飛機設置]頁面查詢代號")]

        public int AirTypeId { get; set; }

        [Display(Name = "註冊編號:")]
        [Required(ErrorMessage = "{0}必填")]
        [StringLength(30)]

        public string RegistrationNum { get; set; }

        [Display(Name = "目前狀態:")]
        [Required(ErrorMessage = "{0}必填")]
        [StringLength(30)]
        public string Status { get; set; }


        [Display(Name = "製造年份:")]
        [Required(ErrorMessage = "{0}必填")]
        public int ManufactureYear { get; set; }
    }
}