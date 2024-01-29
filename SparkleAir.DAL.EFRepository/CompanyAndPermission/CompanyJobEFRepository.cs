using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.DAL.EFRepository.CompanyAndPermission
{
    public class CompanyJobEFRepository : ICompanyJobRepository
    {
        private AppDbContext _db = new AppDbContext();

        public void Create(CompanyJobEntity entity)
        {
            var job = new CompanyJob
            {
                CompanyDepartmentId = entity.CompanyDepartmentId,
                JobTitle = entity.JobTitle,
                Rank = entity.Rank
            };

            _db.CompanyJobs.Add(job);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var job = _db.CompanyJobs.Find(id);
            _db.CompanyJobs.Remove(job);
            _db.SaveChanges();
        }

        public CompanyJobEntity Get(int id)
        {
            var job = _db.CompanyJobs.Find(id);
            var entity = new CompanyJobEntity
            {
                Id = job.Id,
                CompanyDepartmentId = job.CompanyDepartmentId,
                CompanyDepartmentName = job.CompanyDepartment.Name,
                JobTitle = job.JobTitle,
                Rank = job.Rank
            };
            return entity;
        }

        public List<CompanyJobEntity> Search()
        {
            var entities = _db.CompanyJobs
                .Include(e => e.CompanyDepartment)
                .AsNoTracking()
                .Select(e => new CompanyJobEntity
                {
                    Id = e.Id,
                    CompanyDepartmentId = e.CompanyDepartmentId,
                    CompanyDepartmentName = e.CompanyDepartment.Name,
                    JobTitle = e.JobTitle,
                    Rank = e.Rank
                })
                .ToList();
            return entities;
        }

        public void Update(CompanyJobEntity entity)
        {
            var job = _db.CompanyJobs.Find(entity.Id);
            job.CompanyDepartmentId = entity.CompanyDepartmentId;
            job.JobTitle = entity.JobTitle;
            job.Rank = entity.Rank;

            _db.SaveChanges();
        }
    }
}
