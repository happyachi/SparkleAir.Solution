using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace SparkleAir.FrontEnd.Site.Models.Authorize
{
    public class StaffPrincipal : IPrincipal
    {
        private readonly string[] _staffHasGroupsId;

        public  IIdentity Identity { get; private set; }

        public StaffPrincipal(IIdentity identity, string[] staffHasGroupsId) 
        {
            _staffHasGroupsId = staffHasGroupsId;
            this.Identity = identity;
        }


        public  bool IsInRole(string pageGroupKey)
        {
            return _staffHasGroupsId.Contains(pageGroupKey);
        }
    }
}