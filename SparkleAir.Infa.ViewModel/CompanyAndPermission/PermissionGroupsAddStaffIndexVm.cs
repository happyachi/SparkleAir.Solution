﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.CompanyAndPermission
{
    public class PermissionGroupsAddStaffIndexVm
    {
        public int Id { get; set; }

        public int PermissionGroupsId { get; set; }

        public string PermissionGroupsName { get; set; }

        public int CompanyStaffsId { get; set; }

        public string CompanyStaffsName { get; set; }
    }
}
