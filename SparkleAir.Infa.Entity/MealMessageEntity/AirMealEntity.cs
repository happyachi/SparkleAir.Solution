using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Entity.MealMessageEntity
{
    public class AirMealEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AirCabinId { get; set; }

        public string MealContent { get; set; }

        public string Image { get; set; }

        public byte[] ImageBit { get; set; }

        public string Category { get; set; }
    }
}
