using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Dto.TaxFree
{
    public class TFWishlistDto
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int TFItemsId { get; set; }
        //todo:TF
        //public virtual Member Member { get; set; }

        public virtual TFItemDto TFItem { get; set; }
    }
}
