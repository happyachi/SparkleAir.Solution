namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            CampaignsCouponMembers = new HashSet<CampaignsCouponMember>();
            CampaignsDiscountMembers = new HashSet<CampaignsDiscountMember>();
            MemberLoginLogs = new HashSet<MemberLoginLog>();
            MessageBoxes = new HashSet<MessageBox>();
            Messages = new HashSet<Message>();
            MileageDetails = new HashSet<MileageDetail>();
            TFOrderlists = new HashSet<TFOrderlist>();
            TFReserves = new HashSet<TFReserve>();
            TFWishlists = new HashSet<TFWishlist>();
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        public int MemberClassId { get; set; }

        public int CountryId { get; set; }

        [Required]
        [StringLength(16)]
        public string Account { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }

        [StringLength(10)]
        public string ChineseLastName { get; set; }

        [StringLength(10)]
        public string ChineseFirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string EnglishLastName { get; set; }

        [Required]
        [StringLength(30)]
        public string EnglishFirstName { get; set; }

        public bool Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public int TotalMileage { get; set; }

        [Required]
        [StringLength(9)]
        public string PassportNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime PassportExpiryDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime RegistrationTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastPasswordChangeTime { get; set; }

        public bool IsAllow { get; set; }

        [StringLength(100)]
        public string ConfirmCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampaignsCouponMember> CampaignsCouponMembers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampaignsDiscountMember> CampaignsDiscountMembers { get; set; }

        public virtual Country Country { get; set; }

        public virtual MemberClass MemberClass { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberLoginLog> MemberLoginLogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MessageBox> MessageBoxes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MileageDetail> MileageDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TFOrderlist> TFOrderlists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TFReserve> TFReserves { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TFWishlist> TFWishlists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
