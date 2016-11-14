using AutoMapper;
using Ifrit.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ifrit.Controllers
{
    public class EmployerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //Метод определения текущего пользователя
        private async Task<ApplicationUser> GetCurrentUser()
        {
            ApplicationUser user = new ApplicationUser();
            string userId = User.Identity.GetUserId();
            return await db.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }
        // GET
        public async Task<ActionResult> EditBusinessCard()
        {
            ApplicationUser user = await GetCurrentUser();
            UIBusinessCard UserBusinessCard = new UIBusinessCard();            
            var DBUserBusinessCard = user.BusinessCard;
            if (DBUserBusinessCard.Title != null)
            {
                //конфигурация маппера
                Mapper.Initialize(cfg => cfg.CreateMap<BusinessCard, UIBusinessCard>());
                //сопоставление
                UserBusinessCard = Mapper.Map<BusinessCard, UIBusinessCard>(DBUserBusinessCard);
                return View("ShowBusinessCard",UserBusinessCard);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<ActionResult> EditBusinessCard(UIBusinessCard UserBusinessCard, HttpPostedFileBase uploadImage)
        {
            ApplicationUser user = await GetCurrentUser();
            if (ModelState.IsValid)
            {
                //конфигурация маппера
                Mapper.Initialize(cfg => cfg.CreateMap<UIBusinessCard, BusinessCard>());
                //сопоставление
                BusinessCard DBUserBusinessCard = Mapper.Map<UIBusinessCard, BusinessCard>(UserBusinessCard);
                DBUserBusinessCard.User = user;
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                // установка массива байтов
                DBUserBusinessCard.Logo = imageData;
                user.BusinessCard = DBUserBusinessCard;
                db.Users.Attach(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index","Vacancies");
            }
            return View();
        }
    }
}