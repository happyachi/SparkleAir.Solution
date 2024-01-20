namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AirFlightManagement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AirFlightManagement()
        {
            AirFlights = new HashSet<AirFlight>();
            AriTicketPrices = new HashSet<AriTicketPrice>();
            Luggages = new HashSet<Luggage>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string FlightCode { get; set; }

        public int DepartureAirportId { get; set; }

        public int DestinationAirportId { get; set; }

        [StringLength(15)]
        public string DepartureTerminal { get; set; }

        [StringLength(15)]
        public string DestinationTerminal { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DepartureTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ArrivalTime { get; set; }

        [Required]
        [StringLength(15)]
        public string DayofWeek { get; set; }

        public int Mile { get; set; }

        public virtual AirPort AirPort { get; set; }

        public virtual AirPort AirPort1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AirFlight> AirFlights { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AriTicketPrice> AriTicketPrices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Luggage> Luggages { get; set; }
    }
}
