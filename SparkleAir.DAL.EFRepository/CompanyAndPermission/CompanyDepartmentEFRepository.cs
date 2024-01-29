using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.DAL.EFRepository.CompanyAndPermission
{
    public class CompanyDepartmentEFRepository : ICompanyDepartmentRepository
    {
        private readonly AppDbContext _db;
        public CompanyDepartmentEFRepository()
        {
            _db = new AppDbContext();
        }

        public void Create(CompanyDepartmentEntity entity)
        {
            var department = new CompanyDepartment()
            {
                Name = entity.Name
            };

            _db.CompanyDepartments.Add(department);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var department = _db.CompanyDepartments.Find(id);
            _db.CompanyDepartments.Remove(department);
            _db.SaveChanges();
        }

        public CompanyDepartmentEntity Get(int id)
        {
            var department = _db.CompanyDepartments.Find(id);
            var entity = new CompanyDepartmentEntity()
            {
                Id = department.Id,
                Name = department.Name
            };

            return entity; 
        }

        public List<CompanyDepartmentEntity> Search()
        {
            var entity = _db.CompanyDepartments.AsNoTracking()
                        .Select(x => new CompanyDepartmentEntity
                        {
                            Id = x.Id,
                            Name = x.Name
                        })
                        .ToList();

            return entity;
        }

        public void Update(CompanyDepartmentEntity entity)
        {
            var department = _db.CompanyDepartments.Find(entity.Id);
            department.Name = entity.Name;

            _db.SaveChanges();
        }
    }
}
