using SparkleAir.DAL.EFRepository.Airtype_Owns;
using SparkleAir.IDAL.IRepository.Airtype_Owns;
using SparkleAir.Infa.Dto.Airtype_Owns;
using SparkleAir.Infa.Entity.Airtype_Owns;
using SparkleAir.Infa.ViewModel.Airtype_Owns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.Airtype_Owns
{
    public class PlaneService
    {
        private readonly IPlaneRepository _repo;
        public PlaneService(IPlaneRepository repo)
        {
            _repo = repo;
        }
        public List<PlaneDto> GetAll()
        {
            var list = _repo.GetAll()//entity格式
                .Select(p => new PlaneDto//轉成dto格式
                {
                    ID = p.ID,
                    FlightModel = p.FlightModel,
                    TotalSeat = p.TotalSeat,
                    MaxMile = p.MaxMile,
                    MaxWeight = p.MaxWeight,
                    ManufactureCompany = p.ManufactureCompany,
                    Introduction = p.Introduction,
                    Img = p.Img,
                })
                .ToList();
            return list;

        }

        public PlaneDto Get(int? id)
        {
            var result = GetAll().SingleOrDefault(x => x.ID == id);
            return result;
        }

        public void Create(PlaneDto dto)
        {
            if (_repo.Exists(dto.FlightModel))
            {
                // 如果存在，可以選擇拋出異常或回傳錯誤訊息
                throw new InvalidOperationException("相同的飛機款式已存在");

            }

            PlaneEntity entity = new PlaneEntity
            {
                ID = dto.ID,
                FlightModel = dto.FlightModel,
                TotalSeat = dto.TotalSeat,
                MaxMile = dto.MaxMile,
                MaxWeight = dto.MaxWeight,
                ManufactureCompany = dto.ManufactureCompany,
                Introduction = dto.Introduction,
                Img = dto.Img,
            };

            _repo.Create(entity);
        }

        public void CreateTypes(PlaneVm model)
        {
            IPlaneRepository _repo = new PlaneRepository();
            var planeService = new PlaneService(_repo);
            PlaneDto dto = new PlaneDto
            {
                ID = model.Id,
                FlightModel = model.FlightModel,
                TotalSeat = model.TotalSeat,
                MaxMile = model.MaxMile,
                MaxWeight = model.MaxWeight,
                ManufactureCompany = model.ManufactureCompany,
                Introduction = model.Introduction,
                Img = model.Img,
            };

            planeService.Create(dto);
        }

        public void Update(PlaneDto dto)
        {
            PlaneEntity entity = new PlaneEntity
            {
                ID = dto.ID,
                FlightModel = dto.FlightModel,
                TotalSeat = dto.TotalSeat,
                MaxMile = dto.MaxMile,
                MaxWeight = dto.MaxWeight,
                ManufactureCompany = dto.ManufactureCompany,
                Introduction = dto.Introduction,
                Img = dto.Img,
            };

            _repo.Update(entity);
        }

        public void Delete(int id)
        {

            this._repo.Delete(id);
        }

        public void UpdateTypes(PlaneVm model)
        {
            IPlaneRepository _repo = new PlaneRepository();
            var planeService = new PlaneService(_repo);
            PlaneDto dto = new PlaneDto
            {
                ID = model.Id,
                FlightModel = model.FlightModel,
                TotalSeat = model.TotalSeat,
                MaxMile = model.MaxMile,
                MaxWeight = model.MaxWeight,
                ManufactureCompany = model.ManufactureCompany,
                Introduction = model.Introduction,
                Img = model.Img,
            };


            planeService.Update(dto);
        }
    }
}
