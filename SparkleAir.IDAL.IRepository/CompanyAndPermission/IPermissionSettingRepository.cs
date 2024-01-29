using SparkleAir.Infa.Entity.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.IDAL.IRepository.CompanyAndPermission
{
    public interface IPermissionSettingRepository
    {
        List<PermissionSettingEntity> Search();

        void Create(PermissionSettingEntity entity);

        void Update(PermissionSettingEntity entity);

        void Delete(int id);

        PermissionSettingEntity Get(int id);
    }
}
