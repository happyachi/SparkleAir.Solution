using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SparkleAir.FrontEnd.Site.Models.ViewModels.AirFlights
{
	public class AirFlightManagementVm
	{
		public int Id { get; set; }

		[Display(Name = "班次代碼")]
		[Required(ErrorMessage = "{0} 必填")]
		[StringLength(15)]
		public string FlightCode { get; set; }

		[Display(Name = "出發地")]
		[Required(ErrorMessage = "{0} 必填")]
		public int DepartureAirportId { get; set; }

		[Display(Name = "目的地")]
		[Required(ErrorMessage = "{0} 必填")]
		public int DestinationAirportId { get; set; }

		[Display(Name = "出發地航廈")]
		[StringLength(15)]
		public string DepartureTerminal { get; set; }

		[Display(Name = "目的地航廈")]
		[StringLength(15)]
		public string DestinationTerminal { get; set; }

		[Display(Name = "出發時間")]
		[Required(ErrorMessage = "{0} 必填")]
		[Column(TypeName = "datetime2")]
		public DateTime DepartureTime { get; set; }

		[Required(ErrorMessage = "{0} 必填")]
		[Display(Name = "抵達時間")]
		[Column(TypeName = "datetime2")]
		public DateTime ArrivalTime { get; set; }

		[Display(Name = "執飛日")]
		[Required(ErrorMessage = "{0} 必填")]
		[StringLength(15)]
		public string DayofWeek { get; set; }

		[Display(Name = "班次里程")]
		[Required(ErrorMessage = "{0} 必填")]
		public int Mile { get; set; }
	}
}