using Sphinxly_Testuppgift_Backend.Models;
using Sphinxly_Testuppgift_Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace Sphinxly_Testuppgift_Backend.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(VisitorViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Profile", new { name = model.Name });
            }
            return View();
        }
        
        //Test
    }
}