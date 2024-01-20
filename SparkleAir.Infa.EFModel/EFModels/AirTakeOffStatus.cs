namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AirTakeOffStatuses")]
    public partial class AirTakeOffStatus
    {
        public int Id { get; set; }

        public int AirFlightId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ActualDepartureTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ActualArrivalTime { get; set; }

        public int AirFlightStatusId { get; set; }

        public virtual AirFlight AirFlight { get; set; }

        public virtual AirFlightStatus AirFlightStatus { get; set; }
    }
}
