using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pathfinder.Controllers
{
    [AllowAnonymous]
    public class GuidaController : Controller
    {
        // GET: Guida
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Indice() 
        {
            return View();
        }
        public ActionResult Caratteristiche()
        {
            return View();
        }
        public ActionResult Razze()
        {
            return View();
        }
        public ActionResult Classi()
        {
            return View();
        }
        public ActionResult Abilita()
        {
            return View();
        }

        public ActionResult Talenti() 
        {
            return View();
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