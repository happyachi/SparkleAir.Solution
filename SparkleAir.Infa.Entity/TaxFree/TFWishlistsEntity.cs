using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Entity.TaxFree
{
    public class TFWishlistsEntity
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int TFItemsId { get; set; }
        //todo:TF
        //public virtual Member Member { get; set; }

        //public virtual TFItem TFItem { get; set; }
    }
}
