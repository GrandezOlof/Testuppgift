using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sphinxly_Testuppgift_Backend.ViewModels;
using Sphinxly_Testuppgift_Backend.Models;

namespace Sphinxly_Testuppgift_Backend.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new VisitorViewModel
            {
                Name = name
            };

            if (VisitorExist(name))
            {
                model.Greeting = "Welcome back " + model.Name;
            }
            else
            {
                if (TrySaveNewVisitor(model.Name))
                {

                    model.Greeting = "Hello " + model.Name;
                }
                else
                {
                    return View();
                }
            }

            
            return View(model);
        }

        public ActionResult GDPR()
        {
            return Redirect("http://www.swedishepa.se/About-the-website/How-the-Swedish-Environmental-Protection-Agency-processes-personal-data-/Rights-under-GDPR/");
        }

        private bool VisitorExist(string name)
        {
            string csvData = GetVisitorFile();
            if(string.IsNullOrEmpty(csvData))
            {
                return false;
            }

            List<Visitor> visitors = ConvertVisitor(csvData);
            
            return visitors.Any(v => v.Name == name);

        }

        private List<Visitor> ConvertVisitor(string csvData)
        {
            List<Visitor> visitors = new List<Visitor>();
            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {

                    visitors.Add(new Visitor
                    {
                        Name = row,

                    });
                }
            }
            return visitors;
        }

        private string GetVisitorFile()
        {
            string csvData;
            string path = Server.MapPath("~\\Visitors.csv");
            try
            {
                csvData = System.IO.File.ReadAllText(path);

            }
            catch (Exception e)
            {
                throw e;
            }

            if (string.IsNullOrEmpty(csvData))
            {
                return string.Empty;
            }
            return csvData.Replace("\r", "");
        }

        private bool TrySaveNewVisitor(string name)
        {
            string path = Server.MapPath("~\\Visitors.csv");
            try
            {
                name = name + Environment.NewLine;
                System.IO.File.AppendAllText(path, name);
            }
            catch(Exception e)
            {
                throw e;
            }
            
            return true;
        }

        public ActionResult DeleteVisitor(string name)
        {
            
            string csvData = GetVisitorFile();
            List<Visitor> visitors = ConvertVisitor(csvData);
            int countRemove = visitors.RemoveAll(v => v.Name == name);
            
            if(countRemove > 0)
            {
                csvData = CreateCsv(visitors);
                try
                {
                    string path = Server.MapPath("~\\Visitors.csv");
                    System.IO.File.WriteAllText(path, csvData);
                }
                catch (Exception e)
                {

                    return View();
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        private string CreateCsv(List<Visitor> visitors)
        {
            string csvData = string.Empty;
            foreach (var visitor in visitors)
            {
                csvData += visitor.Name + Environment.NewLine;
            }

            return csvData;
        }

    }

}