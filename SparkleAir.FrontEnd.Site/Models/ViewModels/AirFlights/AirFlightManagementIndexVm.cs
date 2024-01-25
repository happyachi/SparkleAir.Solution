using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SparkleAir.FrontEnd.Site.Models.ViewModels.AirFlights
{
	public class AirFlightManagementIndexVm
	{
		public int Id { get; set; }

		[Display(Name = "班次代碼")]
		public string FlightCode { get; set; }

		[Display(Name = "出發地")]
		public string DepartureAirport { get; set; }

		[Display(Name = "目的地")]
		public string DestinationAirport { get; set; }

		[Display(Name = "出發時間")]
		[DisplayFormat(DataFormatString = "{0:HH:mm}")]
		public DateTime DepartureTime { get; set; }

		[Display(Name = "抵達時間")]
		[DisplayFormat(DataFormatString = "{0:HH:mm}")]
		public DateTime ArrivalTime { get; set; }

		[Display(Name = "執飛日")]
		public string DayofWeek { get; set; }
	}
}