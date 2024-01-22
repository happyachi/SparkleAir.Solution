using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SparkleAir.BLL.Service.AirFlights;
using SparkleAir.FrontEnd.Site.Controllers.AirFlight;
using SparkleAir.FrontEnd.Site.Models.ViewModels.AirFlights;
using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.Infa.Dto.AriFlights;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Tests.Controllers
{
	[TestClass]
	public class AirFlightsControllerTest
	{
		[TestMethod]
		[DataRow(2, "002", 2, 1, "", "", "0001-01-01 16:30:00", "0001-01-01 18:30:00", "2,4,6", 2000000)]
		[DataRow(3, "003", 3, 4, "", "", "0001-01-01 16:30:00", "0001-01-01 18:30:00", "2,4,6", 2000000)]
		[DataRow(4, "004", 4, 3, "", "", "0001-01-01 16:30:00", "0001-01-01 18:30:00", "2,4,6", 1500000)]
		[DataRow(5, "005", 5, 6, "", "", "0001-01-01 16:30:00", "0001-01-01 18:30:00", "2,4,6", 1700000)]
		[DataRow(6, "001", 6, 5, "", "", "0001-01-01 16:30:00", "0001-01-01 18:30:00", "2,4,6", 1900000)]
		public void CreatePost_CallsServiceCreate(int id, string flightCode, int departureAirportid, int destinationAirportId, string departurTerminal, string destinationTermanal, string departureTime, string arrivalTime, string dayofWeek, int mile)
		{
			// Arrange
			var mockRepo = Substitute.For<IAirFlightRepository>();
			var mockService = Substitute.For<AirFlightService>(mockRepo);
			var controller = new AirFlightsController(mockService);
			var validVm = new AirFlightManagementVm
			{
				// 看是否能成功create
				Id = id,
				FlightCode = flightCode,
				DepartureAirportId = departureAirportid,
				DestinationAirportId = destinationAirportId,
				DepartureTerminal = departurTerminal,
				DestinationTerminal = destinationTermanal,
				DepartureTime = DateTime.Parse(departureTime),
				ArrivalTime = DateTime.Parse(arrivalTime),
				DayofWeek = dayofWeek,
				Mile = mile
			};

			if (flightCode.Substring(2) == "001")
			{
				//會出錯
				Assert.ThrowsException<Exception>(() => controller.Create(validVm));
			}
			else
			{
				controller.Create(validVm);
			}

			mockService.Received(1).Create(Arg.Do<AirFlightManagementDto>(dto =>
			{
				Assert.AreEqual(flightCode, dto.FlightCode);
			}));
		}
	}
}
