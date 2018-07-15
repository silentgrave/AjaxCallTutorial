using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TutorialAjax.Mapping;
using TutorialAjax.Models;

namespace TutorialAjax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RicercaAsincrona()
        {
            return View();
        }

        public JsonResult RicercaLibro(string titolo)
        {
            SearchModel model = new SearchModel();
            try
            {
                model.Books = getListaLibri(titolo);
                return Json(model.Books, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { error = "Errore!!!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult RicercaSincrona()
        {
            SearchModel model = new SearchModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RicercaSincrona(SearchModel model)
        {
            try
            {
                model.Books = getListaLibri(model.Titolo);
                model.ShowGrid = true;
            }
            catch (Exception e)
            {
                model.ShowGrid = false;
            }
            return View(model);
        }

        private List<BookModel> getListaLibri(string titolo)
        {
            using (var context = new Mapping.TutorialAjaxEntities())
            {
                return context.Books.Where(x => String.IsNullOrEmpty(titolo) || x.Name.Contains(titolo)).Select(x => new BookModel
                {
                    Titolo = x.Name,
                    Autore = x.Author,
                    ColorHex = x.ColorHEX,
                    DataInserimento = x.DTInsert.ToString()
                }).ToList();
            }
        }
    }
}