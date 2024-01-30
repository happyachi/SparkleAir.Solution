using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Dto.TaxFree
{
    public class TFReservelistsDto
    {
        public int Id { get; set; }

        public int TFItemsId { get; set; }

        public int Quantity { get; set; }

        public int UnitPrice { get; set; }

        public int Discount { get; set; }

        public int TotalPrice { get; set; }

        public int TFReserveId { get; set; }

        public virtual TFItemDto TFItem { get; set; }

        public virtual TFReservesDto TFReserve { get; set; }
        
    }
}
