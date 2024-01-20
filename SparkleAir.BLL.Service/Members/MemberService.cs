using SparkleAir.IDAL.IRepository.Members;
using SparkleAir.Infa.Dto.Members;
using SparkleAir.Infa.Entity.Members;
using SparkleAir.Infa.Utility.Exts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.Members
{
	public class MemberService
	{
		private readonly IMemberRepository _repo;

        public MemberService(IMemberRepository repo)
        {
			_repo = repo;
		}

		public List<MemberDto> GetAll()
		{
			var list = _repo.GetAll()
				.Select(m => m.ToDto())
				.ToList();

			return list;
		}
	}
}
