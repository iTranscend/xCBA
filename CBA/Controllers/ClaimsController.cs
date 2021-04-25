using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Security.Claims;
using CBA.Models.ViewModels;

namespace CBA.Controllers
{
    public class ClaimsController : Controller
    {
        // GET: Claims
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult GetClaims()
        {
            var identity = User.Identity as ClaimsIdentity;

            var claims = from c in identity.Claims
                         select new ClaimsViewModel
                         {
                             subject = c.Subject.Name,
                             type = c.Type,
                             value = c.Value
                         };
            return View(claims);
        }
    }
}
