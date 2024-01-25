using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.Infa.Dto.AriFlights;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using SparkleAir.Infa.Utility.Exts.Entities;
using SparkleAir.Infa.Utility.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.AirFlights
{
	public class AirFlightService
	{
		private readonly IAirFlightRepository _repo;

		// 公司代碼
		private const string AirlineCode = "SK";

		// 判斷航班代碼是否重複
		private Func<string, List<AirFlightManagementDto>, bool> isFlightCodeExist = (s, l) =>
		{
			bool isFlight = false;
			foreach (var item in l)
			{
				isFlight = item.FlightCode == s;
				if (isFlight) return true;
			}
			return false;
		};

		public AirFlightService(IAirFlightRepository repo)
		{
			_repo = repo;
		}

		public virtual int Create(AirFlightManagementDto dto)
		{
			string fullAirlineCode = AirlineCode + dto.FlightCode;

			if (isFlightCodeExist(fullAirlineCode, GetAll()))
			{
				throw new Exception("航班代碼已存在");
			}
			else if (dto.DepartureAirport == dto.DestinationAirport)
			{
				throw new Exception("出發地以及目的地有誤");
			}
			else if (!(dto.Mile > 0))
			{
				throw new Exception("里程輸入錯誤");
			}

			DateTime departTime = TimeZoneHelper.ConvertToGMT(dto.DepartureTime, dto.DepartureTimeZone);
			DateTime arrivaTime = TimeZoneHelper.ConvertToGMT(dto.ArrivalTime, dto.DestinationTimeZone);

			AirFlightManagementEntity entity = new AirFlightManagementEntity
			{
				Id = dto.Id,
				FlightCode = fullAirlineCode,
				DepartureAirportId = dto.DepartureAirportId,
				DestinationAirportId = dto.DestinationAirportId,
				DepartureTerminal = dto.DepartureTerminal,
				DestinationTerminal = dto.DestinationTerminal,
				DepartureTime = departTime,
				ArrivalTime = arrivaTime,
				DayofWeek = dto.DayofWeek,
				Mile = dto.Mile,
				DepartureAirport = dto.DepartureAirport,
				DestinationAirport = dto.DestinationAirport,
				DepartureTimeZone = dto.DepartureTimeZone,
				DestinationTimeZone = dto.DestinationTimeZone,
			};

			_repo.Create(entity);

			return dto.Id;
		}

		public void Delete(int id)
		{
			_repo.Delete(id);
		}

		public List<AirFlightManagementDto> GetAll()
		{
			List<AirFlightManagementEntity> entity = _repo.GetAll();
			List<AirFlightManagementDto> dto = entity.Select(x => new AirFlightManagementDto
			{
				Id = x.Id,
				FlightCode = x.FlightCode,
				DepartureAirportId = x.DepartureAirportId,
				DestinationAirportId = x.DestinationAirportId,
				DepartureTerminal = x.DepartureTerminal,
				DestinationTerminal = x.DestinationTerminal,
				DepartureTime = TimeZoneHelper.ConvertToLocal(x.DepartureTime, x.DepartureTimeZone),
				ArrivalTime = TimeZoneHelper.ConvertToLocal(x.ArrivalTime, x.DestinationTimeZone),
				DayofWeek = x.DayofWeek,
				Mile = x.Mile,
				DepartureAirport = x.DepartureAirport,
				DestinationAirport = x.DestinationAirport,
				DepartureTimeZone = x.DepartureTimeZone,
				DestinationTimeZone = x.DestinationTimeZone
			}).ToList();

			return dto;
		}

		public AirFlightManagementDto GetById(int id)
		{
			AirFlightManagementEntity entity = _repo.GetById(id) ?? throw new Exception("沒有這個航班");
			AirFlightManagementDto dto = new AirFlightManagementDto
			{
				Id = entity.Id,
				FlightCode = entity.FlightCode,
				DepartureAirportId = entity.DepartureAirportId,
				DestinationAirportId = entity.DestinationAirportId,
				DepartureTerminal = entity.DepartureTerminal,
				DestinationTerminal = entity.DestinationTerminal,
				DepartureTime = TimeZoneHelper.ConvertToLocal(entity.DepartureTime, entity.DepartureTimeZone),
				ArrivalTime = TimeZoneHelper.ConvertToLocal(entity.ArrivalTime, entity.DestinationTimeZone),
				DayofWeek = entity.DayofWeek,
				Mile = entity.Mile,
				DepartureAirport = entity.DepartureAirport,
				DestinationAirport = entity.DestinationAirport,
				DepartureTimeZone = entity.DepartureTimeZone,
				DestinationTimeZone = entity.DestinationTimeZone,
			};
			return dto;
		}

		public void Update(AirFlightManagementDto dto)
		{
			DateTime departTime = TimeZoneHelper.ConvertToGMT(dto.DepartureTime, dto.DepartureTimeZone);
			DateTime arrivaTime = TimeZoneHelper.ConvertToGMT(dto.ArrivalTime, dto.DestinationTimeZone);
			AirFlightManagementEntity entity = new AirFlightManagementEntity
			{
				Id = dto.Id,
				FlightCode = dto.FlightCode,
				DepartureAirportId = dto.DepartureAirportId,
				DestinationAirportId = dto.DestinationAirportId,
				DepartureTerminal = dto.DepartureTerminal,
				DestinationTerminal = dto.DestinationTerminal,
				DepartureTime = departTime,
				ArrivalTime = arrivaTime,
				DayofWeek = dto.DayofWeek,
				Mile = dto.Mile,
				DepartureAirport = dto.DepartureAirport,
				DestinationAirport = dto.DestinationAirport,
				DepartureTimeZone = dto.DepartureTimeZone,
				DestinationTimeZone = dto.DestinationTimeZone,
			};

			_repo.Update(entity);
		}

		public List<AirFlightManagementDto> Search(AirFlightManagementDto dto)
		{
			// todo 根據 出發地(DropDown) 目的地(DropDown) 時間段(Range) 執飛時段(checkbox)去做篩選
			// 是要傳整個 dto 還是 根據要的資料去寫參數(?

			throw new Exception();
		}
	}
}
