namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TFItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TFItem()
        {
            CampaignsDiscountTFItems = new HashSet<CampaignsDiscountTFItem>();
            TFOrderlists = new HashSet<TFOrderlist>();
            TFReservelists = new HashSet<TFReservelist>();
            TFWishlists = new HashSet<TFWishlist>();
        }

        public int Id { get; set; }

        public int TFCategoriesId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string SerialNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Image { get; set; }

        public int Quantity { get; set; }

        public int UnitPrice { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsPublished { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampaignsDiscountTFItem> CampaignsDiscountTFItems { get; set; }

        public virtual TFCategory TFCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TFOrderlist> TFOrderlists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TFReservelist> TFReservelists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TFWishlist> TFWishlists { get; set; }
    }
}
