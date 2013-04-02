using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICanWoofWoof.MyValidators
{
    public class AtLeastOne : ValidationAttribute, IClientValidatable
    {
        private const string DefaultErrorMessage = "{0} or {1} is required.";
        private const string ValidationType = "atleastonerequired";

        public AtLeastOne()
        {
            var test = GetClientValidationRules(null,null);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
                                                                               ControllerContext context)
        {
            var mcvRule = new ModelClientValidationRule
                              {
                                  ErrorMessage = string.Format(DefaultErrorMessage, "test", string.Empty),
                                  ValidationType = ValidationType
                              };
            mcvRule.ValidationParameters["param"] = "value";
            yield return mcvRule;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}