using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CBA.Models.Models;
using AppContext = CBA.Models.Models.AppContext;

namespace CBA.Controllers
{
    public class HomeController : Controller
    {
        private AppContext db;
        private ApplicationDbContext appdb;

        public HomeController()
        {
            db = new AppContext();
            appdb = new ApplicationDbContext();
        }
        public HomeController(AppContext dbParam, ApplicationDbContext appdbParam)
        {
            db = new AppContext();
            appdb = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            ViewBag.RoleCount = db.Roles.Count();
            ViewBag.UserCount = appdb.Users.Count();

            if (Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Generic Core Banking Application for Nigerian Banks.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}