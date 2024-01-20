namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AirFlight
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AirFlight()
        {
            AirFlightSeats = new HashSet<AirFlightSeat>();
            AirTakeOffStatuses = new HashSet<AirTakeOffStatus>();
            CampaignsCouponAirFlights = new HashSet<CampaignsCouponAirFlight>();
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        public int AirOwnId { get; set; }

        public int AirFlightManagementId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ScheduledDeparture { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ScheduledArrival { get; set; }

        public int AirFlightSaleStatusId { get; set; }

        public virtual AirFlightManagement AirFlightManagement { get; set; }

        public virtual AirFlightSaleStatus AirFlightSaleStatus { get; set; }

        public virtual AirOwn AirOwn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AirFlightSeat> AirFlightSeats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AirTakeOffStatus> AirTakeOffStatuses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampaignsCouponAirFlight> CampaignsCouponAirFlights { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
