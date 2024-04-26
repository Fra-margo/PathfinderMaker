using Pathfinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Pathfinder.Controllers
{
    [Authorize]
    public class PersonaggiController : Controller
    {
        ModelDBContext db = new ModelDBContext();
        // GET: Personaggi
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Intro() 
        {
            return View();
        }
        public ActionResult Create() 
        {
            var viewModel = new PersonaggiViewModel
            {
                RazzeList = db.Razze.ToList(),
                ClassiList = db.Classi.ToList()
            };
            return View(viewModel);            
        }        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonaggiViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var classe = db.Classi.FirstOrDefault(c => c.IdClasse == viewModel.IdClasse);
                var modificatoreCostituzione = CalcolaModificatore(viewModel.Costituzione);
                var puntiVita = 10 + modificatoreCostituzione;
                var personaggio = new Personaggi
                {
                    Nome = viewModel.Nome,
                    IdRazza = viewModel.IdRazza,
                    IdClasse = viewModel.IdClasse,
                    Forza = viewModel.Forza,
                    Destrezza = viewModel.Destrezza,
                    Costituzione = viewModel.Costituzione,
                    Intelligenza = viewModel.Intelligenza,
                    Saggezza = viewModel.Saggezza,
                    Carisma = viewModel.Carisma,
                    PuntiVita = puntiVita,
                    Livello = 1,
                    Abilita_Personaggio = new List<Abilita_Personaggio>()
                };

                db.Personaggi.Add(personaggio);
                db.SaveChanges();
                var abilitaClasse = db.Abilita_Classe
                            .Where(ac => ac.IdClasse == viewModel.IdClasse && ac.Abilita != null)
                            .Select(ac => ac.Abilita)
                            .ToList();

                foreach (var abilita in abilitaClasse)
                {
                    var valoreAbilita = CalcolaValoreAbilita(abilita, viewModel.Forza, viewModel.Destrezza, viewModel.Costituzione, viewModel.Intelligenza, viewModel.Saggezza, viewModel.Carisma);
                    var abilitaPersonaggio = new Abilita_Personaggio
                    {
                        IdPg = personaggio.IdPg,
                        IdAbilita = abilita.IdAbilita,
                        Valore = valoreAbilita
                    };
                    db.Abilita_Personaggio.Add(abilitaPersonaggio);
                }
                db.SaveChanges();

                var utenteCorrente = db.Users.FirstOrDefault(u => u.Username == User.Identity.Name);
                if (utenteCorrente != null)
                {
                    utenteCorrente.Users_Personaggi.Add(new Users_Personaggi
                    {
                        Username = utenteCorrente.Username,
                        IdPg = personaggio.IdPg
                    });
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "Personaggi");
            }

            viewModel.Livello = 1;
            viewModel.RazzeList = db.Razze.ToList();
            viewModel.ClassiList = db.Classi.ToList();
            return View("Create", viewModel);
        }
        private int CalcolaModificatore(int valoreCaratteristica)
        {
            return (valoreCaratteristica - 10) / 2;
        }
        public JsonResult GetClassInfo(int idClasse)
        {
            var classe = db.Classi.FirstOrDefault(c => c.IdClasse == idClasse);
            if (classe == null)
            {
                return Json(null);
            }

            var classInfo = new
            {
                bonusAttaccoBase = classe.BonusAttaccoBase,
                tsTempra = classe.TSTempra,
                tsRiflessi = classe.TSRiflessi,
                tsVolonta = classe.TSVolonta
            };
            return Json(classInfo, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAbilitaClasse(int idClasse, int forza, int destrezza, int costituzione, int intelligenza, int saggezza, int carisma)
        {
            var abilita = db.Abilita_Classe
                .Where(ac => ac.IdClasse == idClasse && ac.Abilita != null)
                .Select(ac => new
                {
                    Abilita = ac.Abilita,
                    CaratteristicaAssociata = ac.Abilita.CaratteristicaAssociata,
                    Tipo = ac.Abilita.Tipo
                })
                .ToList()
                .Select(ac => new
                {
                    IdAbilita = ac.Abilita.IdAbilita,
                    Nome = ac.Abilita.Nome,
                    CaratteristicaAssociata = ac.CaratteristicaAssociata,
                    Tipo = ac.Tipo,
                    Valore = CalcolaValoreAbilita(ac.Abilita, forza, destrezza, costituzione, intelligenza, saggezza, carisma)
                })
                .ToList();

            return Json(abilita, JsonRequestBehavior.AllowGet);
        }

        private int CalcolaValoreAbilita(Abilita abilita, int forza, int destrezza, int costituzione, int intelligenza, int saggezza, int carisma)
        {
            int valoreCaratteristica = 0;

            switch (abilita.CaratteristicaAssociata)
            {
                case "Forza":
                    valoreCaratteristica = forza;
                    break;
                case "Destrezza":
                    valoreCaratteristica = destrezza;
                    break;
                case "Costituzione":
                    valoreCaratteristica = costituzione;
                    break;
                case "Intelligenza":
                    valoreCaratteristica = intelligenza;
                    break;
                case "Saggezza":
                    valoreCaratteristica = saggezza;
                    break;
                case "Carisma":
                    valoreCaratteristica = carisma;
                    break;
                default:
                    break;
            }
            int modificatore = (valoreCaratteristica - 10) / 2;
            if (modificatore == -1 && valoreCaratteristica >= 10)
            {
                return 0;
            }
            return modificatore + 1;
        }
        public ActionResult PersonaggiUtente()
        {
            var username = User.Identity.Name;
            var personaggi = db.Users.FirstOrDefault(u => u.Username == username)?.Users_Personaggi.Select(up => up.Personaggi).ToList();
            return View(personaggi);
        }
        public ActionResult EliminaPersonaggio(int idPg)
        {
            var personaggioDaEliminare = db.Personaggi.Find(idPg);
            if (personaggioDaEliminare != null)
            {
                db.Abilita_Personaggio.RemoveRange(personaggioDaEliminare.Abilita_Personaggio);
                db.Users_Personaggi.RemoveRange(personaggioDaEliminare.Users_Personaggi);
                db.Personaggi.Remove(personaggioDaEliminare);
                db.SaveChanges();
                return RedirectToAction("PersonaggiUtente");
            }
            else
            {
                return HttpNotFound();
            }
        }
        public FileResult DownloadPdf()
        {
            string filePath = Server.MapPath("~/Content/Pathfinder_SchedaPersonaggio.pdf");
            string contentType = "application/pdf";
            string fileName = "Pathfinder_SchedaPersonaggio.pdf";

            return File(filePath, contentType, fileName);
        }
    }
}