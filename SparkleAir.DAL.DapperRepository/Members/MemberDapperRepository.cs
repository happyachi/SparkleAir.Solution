using Dapper;
using SparkleAir.IDAL.IRepository.Members;
using SparkleAir.Infa.Criteria.Members;
using SparkleAir.Infa.Entity.Members;
using SparkleAir.Infa.Utility.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.DAL.DapperRepository.Members
{
	public class MemberDapperRepository : IMemberRepository
	{
		private string _connectionString;
        public MemberDapperRepository()
        {
			_connectionString = SqlDbHelper.GetConnectionString("AppDbContext");
		}

        public MemberEntity Get(MemberGetCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public List<MemberEntity> Search(MemberSearchCriteria criteria)
		{
			string sql = @"SELECT * FROM Members";

			using (var conn = new SqlConnection(_connectionString))
			{
				List<MemberEntity> entity = conn.Query<MemberEntity>(sql).ToList();
				return entity;
			}
		}

        public void Update(MemberEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
