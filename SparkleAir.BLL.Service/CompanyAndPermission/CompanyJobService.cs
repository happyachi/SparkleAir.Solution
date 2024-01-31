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
    public class CompanyJobService
    {
        private readonly ICompanyJobRepository _repo;
        public CompanyJobService(ICompanyJobRepository repo)
        {
            _repo = repo;
        }

        public List<CompanyJobDto> Search()
        {
            var eneities = _repo.Search();
            var dtos = eneities.Select(e => new CompanyJobDto
            {
                Id = e.Id,
                CompanyDepartmentId = e.CompanyDepartmentId,
                CompanyDepartmentName = e.CompanyDepartmentName,
                JobTitle = e.JobTitle,
                Rank = e.Rank
            }).ToList();

            return dtos;
        }

        public void Create(CompanyJobDto dto)
        {
            var entity = new CompanyJobEntity
            {
                CompanyDepartmentId = dto.CompanyDepartmentId,
                CompanyDepartmentName = dto.CompanyDepartmentName,
                JobTitle = dto.JobTitle,
                Rank = dto.Rank
            };

            _repo.Create(entity);
        }

        public CompanyJobDto Get(int id)
        {
            var entity = _repo.Get(id);
            var dto = new CompanyJobDto
            {
                Id = entity.Id,
                CompanyDepartmentId = entity.CompanyDepartmentId,
                CompanyDepartmentName = entity.CompanyDepartmentName,
                JobTitle = entity.JobTitle,
                Rank = entity.Rank
            };

            return dto;
        }

        public void Update(CompanyJobDto dto)
        {
            var entity = new CompanyJobEntity
            {
                Id = dto.Id,
                CompanyDepartmentId = dto.CompanyDepartmentId,
                CompanyDepartmentName = dto.CompanyDepartmentName,
                JobTitle = dto.JobTitle,
                Rank = dto.Rank
            };
            _repo.Update(entity);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
