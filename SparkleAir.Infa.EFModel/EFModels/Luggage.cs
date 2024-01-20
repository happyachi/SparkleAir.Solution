namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Luggage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Luggage()
        {
            LuggageOrders = new HashSet<LuggageOrder>();
        }

        public int Id { get; set; }

        public int AirFlightManagementsId { get; set; }

        public int OriginalPrice { get; set; }

        public int BookPrice { get; set; }

        public virtual AirFlightManagement AirFlightManagement { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuggageOrder> LuggageOrders { get; set; }
    }
}
