using SparkleAir.Infa.Entity.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.IDAL.IRepository.CompanyAndPermission
{
    public interface IPermissionGroupRepository
    {
        List<PermissionGroupEntity> Search();

        void Create(PermissionGroupEntity entity);

        void Update(PermissionGroupEntity entity);


        void Delete(int id);

        PermissionGroupEntity Get(int id);
    }
}
