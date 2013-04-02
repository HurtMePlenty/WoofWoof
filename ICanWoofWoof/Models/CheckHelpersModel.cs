using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ICanWoofWoof.MyValidators;

namespace ICanWoofWoof.Models
{
    public class CheckHelpersModel: IValidatableObject
    {
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Product { get; set; }
        public string Quality { get; set; }
        [AtLeastOne("PhoneEmail")]
        public string Phone { get; set; }
        [AtLeastOne("PhoneEmail")]
        public string EMail { get; set; }


        //no need when we are using ValidationAttribute, just to check
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield return ValidationResult.Success;
        }
    }
}