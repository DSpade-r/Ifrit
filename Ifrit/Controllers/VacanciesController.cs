using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ifrit.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using AutoMapper;

namespace Ifrit.Controllers
{
    public class VacanciesController : Controller
    {
        #region вспомогательные методы и свойства        
        private ApplicationDbContext db = new ApplicationDbContext();
        //Метод определения текущего пользователя
        private async Task<ApplicationUser> GetCurrentUser()
        {
            ApplicationUser user = new ApplicationUser();
            string userId = User.Identity.GetUserId();            
            return await db.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
        #region CRUD методы
        // GET: Vacancies
        [Authorize(Roles = "employer")]
        public async Task<ActionResult>Index()
        {
            var user = await GetCurrentUser();
            return View(user.Vacancies.ToList());
        }

        // GET: Vacancies/Details/5
        [Authorize(Roles = "applicant, employer")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancy vacancy = await db.Vacancies.FindAsync(id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
        }

        // GET: Vacancies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vacancies/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "employer")]
        public async Task<ActionResult> Create(UIVacancy vacancy)
        {
            ApplicationUser user = await GetCurrentUser();           
            if (ModelState.IsValid)
            {
                //конфигурация маппера
                Mapper.Initialize(cfg => cfg.CreateMap<UIVacancy, Vacancy>());
                //сопоставление
                Vacancy DBvacancy = Mapper.Map<UIVacancy, Vacancy>(vacancy);
                DBvacancy.User = user;
                user.Vacancies.Add(DBvacancy);
                db.Users.Attach(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }          
            return View();   
        }

        // GET: Vacancies/Edit/5
        [Authorize(Roles = "employer")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancy DBvacancy = await db.Vacancies.FindAsync(id);
            if (DBvacancy == null)
            {
                return HttpNotFound();
            }
            //конфигурация маппера
            Mapper.Initialize(cfg => cfg.CreateMap<Vacancy, UIVacancy>());
            //сопоставление
            UIVacancy UIvacancy = Mapper.Map<Vacancy, UIVacancy>(DBvacancy);
            return View(UIvacancy);
        }

        // POST: Vacancies/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "employer")]
        public async Task<ActionResult> Edit(UIVacancy UIvacancy)
        {
            if (ModelState.IsValid)
            {
                //конфигурация маппера
                Mapper.Initialize(cfg => cfg.CreateMap<UIVacancy, Vacancy>());
                //сопоставление
                Vacancy DBvacancy = Mapper.Map<UIVacancy, Vacancy>(UIvacancy);
                DBvacancy.User = await GetCurrentUser();
                db.Entry(DBvacancy).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Vacancies/Delete/5
        [Authorize(Roles = "employer")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancy vacancy = await db.Vacancies.FindAsync(id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
        }

        // POST: Vacancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "employer")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Vacancy vacancy = await db.Vacancies.FindAsync(id);
            db.Vacancies.Remove(vacancy);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
        #region поиск
        // GET:
        [Authorize(Roles = "applicant")]
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "applicant")]
        public async Task<ActionResult> Find(UIFindVacancy find)
        {
            var allVacancy = db.Vacancies.Where(r => r.Title.ToLower().Contains(find.Title.ToLower())); //делаю поиск регистронезависимым
            return View("FindResult", await allVacancy.ToListAsync());
        }
        #endregion  
    }
}
