using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CarLotMVC.Controllers
{
    public class MyController : Controller
    {
        // GET: My
        public ActionResult Index()
        {
            string wynik = "";
            foreach (string rootkey in RouteData.Values.Keys)
            {
                wynik = "klucz" + " " + rootkey + "wartość" + RouteData.Values[rootkey] as string;
                wynik += "<br/>";
            }
            return View();
        }
        
    }
}