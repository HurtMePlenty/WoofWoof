using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICanWoofWoof.MyValidators
{
    public class AtLeastOne: ValidationAttribute, IClientValidatable
    {
        private const string defaultErrorMessage = "{0} or {1} is required.";
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule()
                {
                    ErrorMessage = string.Format(defaultErrorMessage, metadata.DisplayName, string.Empty),
                    ValidationType = "atleastonerequired"

                };
        
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}