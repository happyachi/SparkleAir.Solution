﻿using SparkleAir.Infa.Entity.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.IDAL.IRepository.CompanyAndPermission
{
    public interface IPermissionGroupsAddStaffRepository
    {
        List<PermissionGroupsAddStaffEntity> Search();

        PermissionGroupsAddStaffEntity Get(int id);

        void Create(PermissionGroupsAddStaffEntity entity);

        void Update(PermissionGroupsAddStaffEntity entity);

        void Delete(int id);
    }
}
