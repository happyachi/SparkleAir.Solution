﻿using SparkleAir.IDAL.IRepository.Members;
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
    public class MemberClassEFRepository : IMemberClassRepository
    {
        private AppDbContext _db = new AppDbContext();

        public void Create(MemberClassEntity entity)
        {
            var memberClass = new MemberClass
            {
                Name = entity.Name,
                ClassOrder = entity.ClassOrder,
                MileageStart = entity.MileageStart,
                MileageEnd = entity.MileageEnd
            };

            _db.MemberClasses.Add(memberClass);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var memberClass = _db.MemberClasses.Find(id);
            _db.MemberClasses.Remove(memberClass);
            _db.SaveChanges();
        }

        public MemberClassEntity Get(int id)
        {
            var memberClass = _db.CampaignsDiscounts.Find(id).ToEntity();

            var member = _db.MemberClasses.Where(x => x.Name == memberClass.MemberCriteria).ToList();
            var entity = new MemberClassEntity
            {
                Id = member.First().Id,
                Name = member.First().Name,
                ClassOrder = member.First().ClassOrder,
                MileageEnd = member.First().MileageEnd,
                MileageStart = member.First().MileageStart,
            };
            return entity;
        }

        public List<MemberClassEntity> Search()
        {
            var eneities = _db.MemberClasses
                .AsNoTracking()
                .Select(m => new MemberClassEntity
                {
                    Id = m.Id,
                    Name = m.Name,
                    ClassOrder = m.ClassOrder,
                    MileageStart = m.MileageStart,
                    MileageEnd = m.MileageEnd
                })
                .ToList();
            return eneities;
        }

        public void Update(MemberClassEntity entity)
        {
            var memberClass = _db.MemberClasses.Find(entity.Id);

            if (entity.Name != null) memberClass.Name = entity.Name;
            if (entity.ClassOrder != 0) memberClass.ClassOrder = entity.ClassOrder;
            if (entity.MileageStart != 0) memberClass.MileageStart = entity.MileageStart;
            if (entity.MileageEnd != 0) memberClass.MileageEnd = entity.MileageEnd;

            _db.SaveChanges();
        }
    }
}
