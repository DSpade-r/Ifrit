using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ifrit.Controllers
{
    public class InteractionController : Controller
    {
        // GET: Interaction
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "employer")]
        public async Task<ActionResult> Invite()
        {
            return View();
        }
        public async Task<ActionResult> Respond()
        {
            return View();
        }
    }
}