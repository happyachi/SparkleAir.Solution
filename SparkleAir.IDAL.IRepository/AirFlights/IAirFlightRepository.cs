using SparkleAir.Infa.Entity.AirFlightsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.IDAL.IRepository.AirFlights
{
	public interface IAirFlightRepository
	{
		List<AirFlightManagementEntity> GetAll();
		int Create(AirFlightManagementEntity entity);
		void Update(AirFlightManagementEntity entity);
		void Delete(int id);
		AirFlightManagementEntity GetById(int id);
		List<AirFlightManagementEntity> Search(AirFlightManagementEntity entity);
	}
}
