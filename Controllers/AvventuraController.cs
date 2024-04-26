using Pathfinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pathfinder.Controllers
{
    [Authorize]
    public class AvventuraController : Controller
    {
        ModelDBContext db = new ModelDBContext();
        // GET: Avventura
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var personaggi = db.Users.FirstOrDefault(u => u.Username == username)?.Users_Personaggi.Select(up => up.Personaggi).ToList();
            return View(personaggi);
        }

        public ActionResult Seleziona(int IdPg)
        {
            TempData["IdPg"] = IdPg;
            return RedirectToAction("PrimaParte");
        }

        public ActionResult PrimaParte()
        {
            if (TempData["IdPg"] == null)
            {
                return View();
            }
            var idPg = (int)TempData["IdPg"];
            var personaggio = db.Personaggi.FirstOrDefault(p => p.IdPg == idPg);
            if (personaggio == null)
            {
                return HttpNotFound();
            }
            return View(personaggio);
        }

        public ActionResult SecondaParte(int idPg)
        {
            var personaggio = db.Personaggi.FirstOrDefault(p => p.IdPg == idPg);
            if (personaggio == null)
            {
                return HttpNotFound();
            }
            return View(personaggio);
        }

        public ActionResult TerzaParte(int idPg)
        {
            var personaggio = db.Personaggi.FirstOrDefault(p => p.IdPg == idPg);
            if (personaggio == null)
            {
                return HttpNotFound();
            }
            return View(personaggio);
        }
    }
}