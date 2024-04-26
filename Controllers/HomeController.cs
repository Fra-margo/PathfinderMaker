using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Pathfinder.Models;

namespace Pathfinder.Controllers
{
    public class HomeController : Controller
    {
        ModelDBContext db = new ModelDBContext();
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Personaggi");
            }
            return View();
        }

        public ActionResult LoginOrRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginOrRegister(Users user, string action)
        {
            if (action == "Login")
            {
                return Login(user);
            }
            else if (action == "Register")
            {
                return Register(user);
            }
            else
            {
                return View();
            }
        }

        private ActionResult Login(Users user)
        {
            var loggedUser = db.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (loggedUser == null)
            {
                TempData["ErrorLogin"] = "Credenziali non valide.";
                return RedirectToAction("LoginOrRegister");
            }
            FormsAuthentication.SetAuthCookie(loggedUser.Username.ToString(), true);
            return RedirectToAction("Index", "Personaggi");
        }

        private ActionResult Register(Users user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Username == user.Username);
                if (existingUser != null)
                {
                    TempData["ErrorRegister"] = "Il nome utente è stato già selezionato.";
                    return RedirectToAction("LoginOrRegister");
                }

                db.Users.Add(user);
                db.SaveChanges();

                FormsAuthentication.SetAuthCookie(user.Username.ToString(), true);
                return RedirectToAction("Index", "Personaggi");
            }
            return View(user);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult NonDisponibile()
        {
            return View();
        }         
    }
}
