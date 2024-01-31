using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.TaxFree
{
    public class TFWishlistsVm
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public string MemberChineseLastName { get; set; }

        [Display(Name = "中文名")]

        public string MemberChineseFirstName { get; set; }

        [Display(Name = "英文姓")]
        public string MemberEnglishLastName { get; set; }

        [Display(Name = "英文名")]

        public string MemberEnglishFirstName { get; set; }

        [Display(Name = "手機")]

        public string MemberPhone { get; set; }

        [Display(Name = "電子信箱")]

        public string MemberEmail { get; set; }

        [Display(Name = "護照號碼")]

        public string MemberPassportNumber { get; set; }

        public int TFItemsId { get; set; }

        public string TFItemsName { get; set; }

        public string TFItemsSerialNumber { get; set; }

        public string TFItemsImage { get; set; }

        public int TFItemsQuantity { get; set; }

        public int TFItemsUnitPrice { get; set; }



    }
}
