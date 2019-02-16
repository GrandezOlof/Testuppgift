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



        private void Save(List<VisitorViewModel> persons)
        {
            // sparas på bin\Debug\   Filen hamnar i samma mapp där programmet körs.
            var path = Server.MapPath("Customer.txt"); // Sparas inne i min project så att andra användare kan få tillgång till det
            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                foreach (var person in persons)
                {
                    sw.WriteLine(person); //skriver till filen
                    // person som är av typen Person() anropar på sin ToString() och bli en sträng istället.
                }
                sw.Close(); // Stänger filen
            }
        }

        //public void SaveToCSV()
        //{
        //    StringWriter sw = new StringWriter();
        //    sw.WriteLine("\"Name\"");

        //    Response.ClearContent();
        //    Response.AddHeader("content-disposition", "attachment;filename=Exported_Users.csv");
        //    Response.ContentType = "text/csv";

        //    var customers = VisitorViewModel.customersList();

        //    foreach (var customer in customers)
        //    {
        //        sw.WriteLine(string.Format("\"{0}\"", customer.Name));
        //    }
        //    Response.Write(sw.ToString());
        //    Response.End();

        //}


        //[HttpGet]
        //public ActionResult GDPR()
        //{
        //    return View();
        //}

    }
}