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

namespace Ifrit.Controllers
{
    [Authorize(Roles = "employer")]
    public class VacanciesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //Метод определения текущего пользователя
        private async Task<ApplicationUser> GetCurrentUser()
        {
            ApplicationUser user = new ApplicationUser();
            string userId = User.Identity.GetUserId();            
            return await db.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }
        // GET: Vacancies
        public async Task<ActionResult>Index()
        {
            var user = await GetCurrentUser();
            return View(user.Vacancies.ToList());
        }

        // GET: Vacancies/Details/5
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
        public async Task<ActionResult> Create(Vacancy vacancy)
        {
            var user = await GetCurrentUser();
            user.Vacancies.Add(vacancy);
            db.Users.Attach(user);
            await db.SaveChangesAsync();            
            return RedirectToAction("Index");   
        }

        // GET: Vacancies/Edit/5
        public async Task<ActionResult> Edit(int? id)
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

        // POST: Vacancies/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Vacancy vacancy)
        {                
                vacancy.User = await GetCurrentUser();
                db.Entry(vacancy).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");            
        }

        // GET: Vacancies/Delete/5
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
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Vacancy vacancy = await db.Vacancies.FindAsync(id);
            db.Vacancies.Remove(vacancy);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
