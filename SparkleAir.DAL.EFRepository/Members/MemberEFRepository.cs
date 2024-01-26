using SparkleAir.IDAL.IRepository.Members;
using SparkleAir.Infa.Criteria.Members;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.Members;
using SparkleAir.Infa.Utility.Exts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.DAL.EFRepository.Members
{
	public class MemberEFRepository : IMemberRepository
	{
		private AppDbContext _db;

        public MemberEFRepository()
        {
            _db = new AppDbContext();
        }

        public MemberEntity Get(MemberGetCriteria criteria)
        {
			var member = _db.Members;
			var query = new Member();

            if (criteria.Id != null)
			{
                query = member.Find(criteria.Id);

            }
			if (criteria.Account != null)
			{
                query = member.FirstOrDefault(x => x.Account == criteria.Account);
            }

			return query.MemberToEntity();
        }

        public List<MemberEntity> GetAll()
		{
			var entities = _db.Members.AsNoTracking()
				.Select(member => new MemberEntity
				{
					Id = member.Id,
					MemberClassId = member.MemberClassId,
					MemberClassName = member.MemberClass.Name,
                    CountryId = member.CountryId,
					CountryName = member.Country.ChineseName,
                    Account = member.Account,
					Password = member.Password,
					ChineseLastName = member.ChineseLastName,
					ChineseFirstName = member.ChineseFirstName,
					EnglishLastName = member.EnglishLastName,
					EnglishFirstName = member.EnglishFirstName,
					Gender = member.Gender,
					DateOfBirth = member.DateOfBirth,
					Phone = member.Phone,
					Email = member.Email,
					TotalMileage = member.TotalMileage,
					PassportNumber = member.PassportNumber,
					PassportExpiryDate = member.PassportExpiryDate,
					RegistrationTime = member.RegistrationTime,
					LastPasswordChangeTime = member.LastPasswordChangeTime,
					IsAllow = member.IsAllow,
					ConfirmCode = member.ConfirmCode
				})
				.ToList();

			return entities;
		}
	}
}
