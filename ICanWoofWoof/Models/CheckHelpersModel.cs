using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ICanWoofWoof.MyValidators;

namespace ICanWoofWoof.Models
{
    public class CheckHelpersModel
    {
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Product { get; set; }
        public string Quality { get; set; }
        [AtLeastOne]
        public string Phone { get; set; }
        public string EMail { get; set; }
    }
}