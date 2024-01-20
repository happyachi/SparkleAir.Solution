namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TicketInvoicingDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TicketInvoicingDetail()
        {
            AirBookSeats = new HashSet<AirBookSeat>();
            LuggageOrders = new HashSet<LuggageOrder>();
        }

        public int Id { get; set; }

        public int TicketDetailId { get; set; }

        public int AirFlightSeatId { get; set; }

        [Required]
        [StringLength(10)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }

        public int CountryId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateofBirth { get; set; }

        public bool Gender { get; set; }

        [Required]
        [StringLength(10)]
        public string PassportNum { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime PassportExpirationDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Remark { get; set; }

        [Required]
        [StringLength(10)]
        public string TicketNum { get; set; }

        public int AirMealId { get; set; }

        public bool CheckInStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AirBookSeat> AirBookSeats { get; set; }

        public virtual AirFlightSeat AirFlightSeat { get; set; }

        public virtual AirMeal AirMeal { get; set; }

        public virtual Country Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuggageOrder> LuggageOrders { get; set; }

        public virtual TicketDetail TicketDetail { get; set; }
    }
}
