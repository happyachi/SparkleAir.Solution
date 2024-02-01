﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Entity.MealMessageEntity
{
    public class MessageEntity
    {
        public int Id { get; set; }

        public int MessageBoxId { get; set; }

        public DateTime SendTime { get; set; }

        public string MessageContent { get; set; }

        public int? MemberId { get; set; }

        public int? CompanyStaffId { get; set; }

        public bool IsReaded { get; set; }

        public DateTime? ReadedTime { get; set; }
    }
}
