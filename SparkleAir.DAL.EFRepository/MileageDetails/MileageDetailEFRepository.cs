﻿using SparkleAir.IDAL.IRepository.MileageDetails;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.Luggage;
using SparkleAir.Infa.Entity.MileageDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SparkleAir.DAL.EFRepository.MileageDetails
{
    public class MileageDetailEFRepository : IMileageDetailRepository
    {
        private AppDbContext db = new AppDbContext();

        public int Create(MileageDetailEntity model)
        {
            MileageDetail mileagedetail = new MileageDetail
            {
                Id = model.Id,
                MermberIsd = model.MermberIsd,
                TotalMile = model.TotalMile,
                OriginalMile = model.OriginalMile,
                ChangeMile = model.ChangeMile,
                FinalMile = model.FinalMile,
                MileValidity = model.MileValidity,
                MileReason = model.MileReason,
                OrderNumber = model.OrderNumber,
                ChangeTime = model.ChangeTime,
            };
            db.MileageDetails.Add(mileagedetail);
            db.SaveChanges();
            return mileagedetail.Id;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public MileageDetailEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<MileageDetailEntity> GetAll()
        {
            var Mileage = db.MileageDetails.AsNoTracking()
                          .Include(p => p.Member)
                          .OrderByDescending(p => p.MermberIsd) //大到小
                          .Select(p => new MileageDetailEntity
                          {
                              Id = p.Id,
                              MermberIsd = p.MermberIsd,
                              TotalMile = p.TotalMile,
                              OriginalMile = p.OriginalMile,
                              ChangeMile = p.ChangeMile,
                              FinalMile = p.FinalMile,
                              MileValidity = p.MileValidity,
                              MileReason = p.MileReason,
                              OrderNumber = p.OrderNumber,
                              ChangeTime = p.ChangeTime,
                          })
                          .ToList();

            return Mileage;
        }

        public void Update(MileageDetailEntity model)
        {
            throw new NotImplementedException();
        }


        //取某會員的最後一筆最終里程
        public int Getfinalmile(int memberId)
        {
            var memberfinalmaile = db.MileageDetails.Where(p => p.MermberIsd == memberId)
                                      .OrderByDescending(p=>p.ChangeTime)
                                      .FirstOrDefault();

            return memberfinalmaile.FinalMile;

            

        }

    }
}
