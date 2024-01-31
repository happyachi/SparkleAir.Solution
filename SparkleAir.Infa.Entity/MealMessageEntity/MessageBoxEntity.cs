using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Entity.MealMessageEntity
{
    public class MessageBoxEntity
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public bool IsProcessed { get; set; }

        public DateTime? ProcessedTime { get; set; }
    }
}
