using SparkleAir.IDAL.IRepository.Airport;
using SparkleAir.Infa.Dto.Airport;
using SparkleAir.Infa.Entity.Airports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.Airports
{
    public class AirportService
    {
        private readonly IAirportRepository _repo;

        public AirportService(IAirportRepository repo)
        {
            _repo = repo;
        }


        //取全部
        public List<AirportDto> GetAll()
        {
            List<AirportEntity> entity = _repo.GetAll();

            List<AirportDto> dto = entity.Select(p => new AirportDto
            {
                Id = p.Id,
                Lata= p.Lata,
                Gps=p.Gps,
                Country=p.Country,
                City= p.City,
                AirPortName = p.AirPortName,
                TimeArea = p.TimeArea,
                Zone= p.Zone,
                CityIntroduction = p.CityIntroduction,
                Img = p.Img,
                Continent = p.Continent,

            }).ToList();

            return dto;
        }


    }
}
