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

namespace Ifrit.Controllers
{
    [Authorize(Roles = "applicant")]
    public class ResumesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //Метод определения текущего пользователя
        private async Task<ApplicationUser> GetCurrentUser()
        {
            ApplicationUser user = new ApplicationUser();
            string userId = User.Identity.GetUserId();
            return await db.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        // GET: Resumes
        public async Task<ActionResult> Index()
        {
            ApplicationUser user = await GetCurrentUser();
            return View(user.Resumes.ToList());            
        }

        // GET: Resumes/Details/5
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resumes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Resume resume)
        {
            ApplicationUser user = await GetCurrentUser();
            user.Resumes.Add(resume);
            db.Users.Attach(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Resumes/Edit/5
        public async Task<ActionResult> Edit(int? id)
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

        // POST: Resumes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ResumeId,Title,Body,Salary")] Resume resume)
        {            
            resume.User = await GetCurrentUser();
            db.Entry(resume).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");            
        }

        // GET: Resumes/Delete/5
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
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Resume resume = await db.Resumes.FindAsync(id);
            db.Resumes.Remove(resume);
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
