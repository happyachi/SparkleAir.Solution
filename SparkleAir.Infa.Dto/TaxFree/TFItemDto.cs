using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Dto.TaxFree
{
    public class TFItemDto
    {

        public int Id { get; set; }

        public int TFCategoriesId { get; set; }

       public string Name { get; set; }

    
        public string SerialNumber { get; set; }

        public string Image { get; set; }

        public int Quantity { get; set; }

        public int UnitPrice { get; set; }


        public string Description { get; set; }

        public bool IsPublished { get; set; }

        public virtual TFCategoryDto TFCategory { get; set; }

    }

    public class TFCategoryDto
    {
        public int Id { get; set; }

        public string Category { get; set; }
    }
}
