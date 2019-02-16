using Sphinxly_Testuppgift_Backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sphinxly_Testuppgift_Backend.ViewModels
{
    public class VisitorViewModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        public string Greeting { get; set; }

    }
}