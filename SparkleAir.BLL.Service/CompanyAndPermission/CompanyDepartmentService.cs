using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using SparkleAir.Infa.Dto.CompanyAndPermission;
using SparkleAir.Infa.Entity.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.CompanyAndPermission
{
    public class CompanyDepartmentService
    {
        private readonly ICompanyDepartmentRepository _repo;
        public CompanyDepartmentService(ICompanyDepartmentRepository repo)
        {
            _repo = repo;
        }

        public List<CompanyDepartmentDto> Search()
        {
            var eneities = _repo.Search();
            var dtos = eneities.Select(e => new CompanyDepartmentDto
            {
                Id = e.Id,
                Name = e.Name
            }).ToList();

            return dtos;
        }

        public void Create(CompanyDepartmentDto dto)
        {
            var entity = new CompanyDepartmentEntity()
            {
                Name = dto.Name
            };

            _repo.Create(entity);
        }

        public CompanyDepartmentDto Get(int id)
        {
            var entity = _repo.Get(id);
            var dto = new CompanyDepartmentDto
            {
                Id = entity.Id,
                Name = entity.Name
            };

            return dto;
        }

        public void Update(CompanyDepartmentDto dto)
        {
            var entity = new CompanyDepartmentEntity 
            { 
                Id = dto.Id, 
                Name = dto.Name 
            };

            _repo.Update(entity);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
