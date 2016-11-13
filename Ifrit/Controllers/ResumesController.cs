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
using AutoMapper;

namespace Ifrit.Controllers
{
    public class ResumesController : Controller
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
        // GET: Resumes
        [Authorize(Roles = "applicant")]
        public async Task<ActionResult> Index()
        {
            ApplicationUser user = await GetCurrentUser();
            return View(user.Resumes.ToList());            
        }

        // GET: Resumes/Details/5
        [Authorize(Roles = "applicant, employer")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resume resume = await db.Resumes.FindAsync(id);
            if (resume == null)
            {
                return HttpNotFound();
            }
            return View(resume);
        }

        // GET: Resumes/Create
        [Authorize(Roles = "applicant")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resumes/Create  
        [Authorize(Roles = "applicant")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UIResume resume)
        {          
            ApplicationUser user = await GetCurrentUser();
            if (ModelState.IsValid)
            {
                //конфигурация маппера
                Mapper.Initialize(cfg => cfg.CreateMap<UIResume, Resume>());
                //сопоставление
                Resume DBResume = Mapper.Map<UIResume, Resume>(resume);             
                DBResume.User = user;
                user.Resumes.Add(DBResume);
                db.Users.Attach(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Resumes/Edit/5
        [Authorize(Roles = "applicant")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resume DBresume = await db.Resumes.FindAsync(id);
            if (DBresume == null)
            {
                return HttpNotFound();
            }
            //конфигурация маппера
            Mapper.Initialize(cfg => cfg.CreateMap<Resume, UIResume>());
            //сопоставление
            UIResume UIresume = Mapper.Map<Resume, UIResume>(DBresume);            
            return View(UIresume);
        }

        // POST: Resumes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "applicant")]
        public async Task<ActionResult> Edit(UIResume UIresume)
        {
            //ApplicationUser user = await GetCurrentUser();
            if (ModelState.IsValid)
            {
                ApplicationUser user = await GetCurrentUser();
                //конфигурация маппера
                Mapper.Initialize(cfg => cfg.CreateMap<UIResume, Resume>());
                //сопоставление
                Resume DBresume = Mapper.Map<UIResume, Resume>(UIresume);                
                DBresume.User = user;
                db.Entry(DBresume).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();                      
        }

        // GET: Resumes/Delete/5
        [Authorize(Roles = "applicant")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resume resume = await db.Resumes.FindAsync(id);
            if (resume == null)
            {
                return HttpNotFound();
            }
            return View(resume);
        }

        // POST: Resumes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "applicant")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Resume resume = await db.Resumes.FindAsync(id);
            db.Resumes.Remove(resume);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
        #region поиск
        // GET:
        [Authorize(Roles = "employer")]
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "employer")]
        public async Task<ActionResult> Find(UIFindResume find)
        {
            var allResume = db.Resumes.Where(r => r.Title.ToLower().Contains(find.Title.ToLower())); //регистронезависимый поиск 
            return View("FindResult",await allResume.ToListAsync());
        }
        #endregion        
    }
}
