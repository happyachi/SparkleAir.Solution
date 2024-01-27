using SparkleAir.IDAL.IRepository.Members;
using SparkleAir.Infa.Criteria.Members;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.Members;
using SparkleAir.Infa.Utility.Exts.Models;
using static SparkleAir.Infa.Utility.Helper.Members.MemberFunc;
using System;
using System.Data.Entity;
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
                return query.MemberToEntity();
            }
            else
            {
                query = member.FirstOrDefault(m => MemberGetFunc(m, criteria));
            }

            return query.MemberToEntity();
        }

        public List<MemberEntity> Search(MemberSearchCriteria criteria)
        {
            var query = _db.Members
                .Include(m => m.MemberClass)
                .Include(m => m.Country)
                .AsNoTracking()
                .MemberSearchExt(criteria);
          

            var entity = query.Select(member => new MemberEntity
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
            });


            return entity.ToList();
        }

        public void Update(MemberEntity entity)
        {
            if (entity == null ) throw new Exception("沒有實例");

            var member = _db.Members.Find(entity.Id);

            if (entity.MemberClassId != 0 ) member.MemberClassId = entity.MemberClassId;
            if (entity.CountryId != 0) member.CountryId = entity.CountryId;
            if (entity.TotalMileage != 0) member.TotalMileage = entity.TotalMileage;
            if (entity.Password != null) member.Password = entity.Password;
            if (entity.ChineseLastName != null) member.ChineseLastName = entity.ChineseLastName;
            if (entity.ChineseFirstName != null) member.ChineseFirstName = entity.ChineseFirstName;
            if (entity.EnglishLastName != null) member.EnglishLastName = entity.EnglishLastName;
            if (entity.EnglishFirstName != null) member.EnglishFirstName = entity.EnglishFirstName;
            if (entity.Phone != null) member.Phone = entity.Phone;
            if (entity.Email != null) member.Email = entity.Email;
            if (entity.PassportNumber != null) member.PassportNumber = entity.PassportNumber;
            if (entity.ConfirmCode != null) member.ConfirmCode = entity.ConfirmCode;
            if (entity.DateOfBirth != new DateTime(1, 1, 1)) member.DateOfBirth = entity.DateOfBirth;
            if (entity.PassportExpiryDate != new DateTime(1, 1, 1)) member.PassportExpiryDate = entity.PassportExpiryDate;
            if (entity.LastPasswordChangeTime != new DateTime(1, 1, 1)) member.LastPasswordChangeTime = entity.LastPasswordChangeTime;
            if (entity.IsAllow != null) member.IsAllow = (bool)entity.IsAllow;

            _db.SaveChanges();
        }
    }

}
