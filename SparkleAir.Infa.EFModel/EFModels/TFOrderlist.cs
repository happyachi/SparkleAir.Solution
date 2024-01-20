namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TFOrderlist
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int TFItemsId { get; set; }

        public int Quantity { get; set; }

        public int UnitPrice { get; set; }

        public virtual Member Member { get; set; }

        public virtual TFItem TFItem { get; set; }
    }
}
