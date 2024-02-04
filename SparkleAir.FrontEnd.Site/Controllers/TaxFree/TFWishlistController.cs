﻿using SparkleAir.BLL.Service.TaxFree;
using SparkleAir.DAL.EFRepository.TaxFree;
using SparkleAir.IDAL.IRepository.TaxFree;
using SparkleAir.Infa.Dto.TaxFree;
using SparkleAir.Infa.ViewModel.TaxFree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.TaxFree
{
    public class TFWishlistController : Controller
    {
        ITFWishlist repo = new TFWishlistEFRepository();
        // GET: TFWishlist
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
        { 

           
            List<TFWishlistsVm> wishlists = Get();

            //// 使用LINQ進行分組和整理
            //var groupedWishlists = wishlists
            //    .GroupBy(x => x.MemberId)
            //    .Select(group => new
            //    {
            //        MemberId = group.Key,
            //        MemberChineseLastName = group.First().MemberChineseLastName,
            //        MemberChineseFirstName = group.First().MemberChineseFirstName,
            //        MemberEnglishLastName = group.First().MemberEnglishLastName,
            //        MemberEnglishFirstName = group.First().MemberEnglishFirstName,
            //        TFItems = string.Join(", ", group.Select(item => $"{item.TFItemsName} ({item.TFItemsSerialNumber})"))
            //    });

           return PartialView("Index1", wishlists);
        }

        public ActionResult Details(int id)
        {
            TFWishlistsVm vm = Getid(id);
            return View(vm);
        }

        public ActionResult Delete(int id)
        {
            DeleteItem(id);
            return View("Index");
        }

        private void DeleteItem(int id)
        {
            var service = new TFWishlistService(repo);
            service.Delete(id);
        }

        public ActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Create(TFWishlistsVm vm)
        {
            if (!ModelState.IsValid) { return View(); }
            try
            {
                CreateItem(vm);
                return RedirectToAction("Index");
            }catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(vm);
            }
        }

        private void CreateItem(TFWishlistsVm vm)
        {
            var service = new TFWishlistService(repo);
            TFWishlistDto dto = new TFWishlistDto
            {
                Id = vm.Id,
                MemberId = vm.MemberId,
                TFItemsId = vm.TFItemsId
            };
            service.Create(dto);
        }

        public ActionResult Edit(int id) 
        {   
            var TFWishlist = Getid(id);
            return View(); 
        }

        [HttpPost]
        public ActionResult Edit(TFWishlistsVm vm)
        {
            if (!ModelState.IsValid) { return View(); }
            try
            {
                UpdateItem(vm);
                return RedirectToAction("Index");
            }catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                
            }
            return View(vm);
        }

        [HttpPost]
        public void UpdateItem(TFWishlistsVm vm)
        {
            var service = new TFWishlistService(repo);
            TFWishlistDto dto = new TFWishlistDto
            {
                Id = vm.Id,
                MemberId = vm.MemberId,
                TFItemsId = vm.TFItemsId
            };
            service.Update(dto);
        }

        [HttpPost]
        private List<TFWishlistsVm> Get()
        {
            var service = new TFWishlistService(repo);

            List<TFWishlistDto> dto = service.Get();
            List<TFWishlistsVm> vm = dto.Select(p => new TFWishlistsVm
            {
                Id = p.Id,
                MemberId = p.MemberId,
                MemberChineseFirstName = p.MemberChineseFirstName,
                MemberChineseLastName = p.MemberChineseLastName,
                MemberEnglishFirstName = p.MemberEnglishFirstName,
                MemberEnglishLastName = p.MemberEnglishLastName,
                MemberPassportNumber = p.MemberPassportNumber,
                TFItemsName = p.TFItemsName,
                TFItemsSerialNumber = p.TFItemsSerialNumber,
                TFItemsId = p.TFItemsId
            }).ToList();
            return vm;
        }

        private TFWishlistsVm Getid(int id)
        {
            var service = new TFWishlistService(repo);
            var dto = service.Getid(id);
            return new TFWishlistsVm 
            {
                Id = dto.Id, 
                MemberId = dto.MemberId,
                MemberChineseFirstName = dto.MemberChineseFirstName,
                MemberChineseLastName = dto.MemberChineseLastName,
                MemberEnglishFirstName = dto.MemberEnglishFirstName,
                MemberEnglishLastName = dto.MemberEnglishLastName,
                TFItemsName = dto.TFItemsName,
                TFItemsSerialNumber = dto.TFItemsSerialNumber,
                TFItemsId = dto.TFItemsId 
            };
        }
    }
}