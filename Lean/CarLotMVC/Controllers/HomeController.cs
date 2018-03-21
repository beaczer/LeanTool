using CarLotMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarLotMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var kontakty = new List<Contact>()
            { new Contact() { Imie = "Beata", Miasto = "Katoiwce", Nazwisko = "fssaddsf", Ulica = "aaa" },
            new Contact() { Imie = "Juoa", Miasto = "Katoiwce", Nazwisko = "fsf", Ulica = "aaa" },
            new Contact() { Imie = "Zofia", Miasto = "Plock", Nazwisko = "fsf", Ulica = "aaa" },
            new Contact() { Imie = "Anna", Miasto = "Krakow", Nazwisko = "fsf", Ulica = "asdfaa" },
            new Contact() { Imie = "Beata", Miasto = "Katoiwce", Nazwisko = "fsf", Ulica = "fd" }};
            ViewBag.Kontakty = kontakty;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Parametry()
        {
            
            ViewBag.MojaZmienna = 10;
            ViewBag.MojStrinng = "costam";
            ViewData["innaSprawa"] = 200;
            ViewData ["Ksiazka"] = new Ksiazka() { Autor = "Ja", Cena = 100, Tytul = "Hello" };
            Ksiazka abc= new Ksiazka() { Autor = "Ja", Cena = 100, Tytul = "AHOJ" };
            return View(abc);
        }
        public void Parametry2(Ksiazka a)
        {
            Response.Write(string.Format("Cena {0}", a.Cena));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Ksiazka ksiazka)
        {
            if(ModelState.IsValid)
            {
                RedirectToAction("Create");
            }
            return View(ksiazka);
        }
    }
}