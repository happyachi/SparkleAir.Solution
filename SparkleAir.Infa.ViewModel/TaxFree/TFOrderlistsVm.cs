﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.TaxFree
{
    public class TFOrderlistsVm
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int TFItemsId { get; set; }

        public int Quantity { get; set; }

        public int UnitPrice { get; set; }
        //todo:TF
        //public virtual Member Member { get; set; }

        //public virtual TFItem TFItem { get; set; }
    }
}