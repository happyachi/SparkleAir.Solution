﻿using System;
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
		public string DepartureAirport { get; set; }
		public int DepartureAirportId { get; set; }

		[Display(Name = "目的地")]
		[Required(ErrorMessage = "{0} 必填")]
		public string ArrivalAirport { get; set; }
		public int ArrivalAirportId { get; set; }

		[Display(Name = "出發地航廈")]
		[StringLength(15)]
		public string DepartureTerminal { get; set; }

		[Display(Name = "目的地航廈")]
		[StringLength(15)]
		public string ArrivalTerminal { get; set; }

		[Display(Name = "出發時間")]
		[Required(ErrorMessage = "{0} 必填")]
		[DisplayFormat(DataFormatString = "{0:HH:mm}")]
		public TimeSpan DepartureTime { get; set; }

		[Required(ErrorMessage = "{0} 必填")]
		[Display(Name = "抵達時間")]
		[DisplayFormat(DataFormatString = "{0:HH:mm}")]
		public TimeSpan ArrivalTime { get; set; }

		[Display(Name = "執飛日")]
		[Required(ErrorMessage = "{0} 必填")]
		[StringLength(15)]
		public string DayofWeek { get; set; }

		[Display(Name = "班次里程")]
		[Required(ErrorMessage = "{0} 必填")]
		public int Mile { get; set; }

		[Display(Name = "出發地時區")]
		public int DepartureTimeZone { get; set; }
		[Display(Name = "目的地時區")]
		public int ArrivalTimeZone { get; set; }
	}
}