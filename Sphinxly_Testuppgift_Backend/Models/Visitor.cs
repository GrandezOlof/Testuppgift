using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sphinxly_Testuppgift_Backend.Models
{
    public class Visitor
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        
    }
}