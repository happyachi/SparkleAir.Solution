using SparkleAir.IDAL.IRepository.Members;
using SparkleAir.Infa.Criteria.Members;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.DAL.EFRepository.Members
{
    public class MemberLoginLogEFRepository : IMemberLoginLogRepository
    {
        private AppDbContext _db;
        public MemberLoginLogEFRepository()
        {
            _db = new AppDbContext();
        }
        public List<MemberLoginLogEntity> Search(MemberLoginLogSearchCriteria criteria)
        {
            var query = _db.MemberLoginLogs.AsNoTracking();

            if (criteria != null)
            {
                // todo 篩選
            }
            var entity = query.Select(member => new MemberLoginLogEntity
            {
                Id = member.Id,
                MemberId = member.MemberId,
                MemberName = member.Member.EnglishFirstName + "  "+member.Member.EnglishLastName,
                Logintime = member.Logintime,
                LogoutTime = member.LogoutTime,
                IPAddress = member.IPAddress,
                LoginStatus = member.LoginStatus

            }).ToList();

            return entity;
        }
    }
}
