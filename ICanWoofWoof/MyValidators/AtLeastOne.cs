using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ICanWoofWoof.MyValidators
{
    public class AtLeastOne : ValidationAttribute, IClientValidatable
    {
        private const string ClientErrorMessage = "{0} or {1} is required.";
        private const string ValidationType = "atleastonerequired";
        private const string ServerErrorMessage = "At least one property with attribute AtLeastOne and Key {0} should be filled.";
        public string GroupKey
        {
            get { return _groupKey; }
        }

        private readonly string _groupKey;

        public AtLeastOne(string groupKey)
        {
            _groupKey = groupKey;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
                                                                               ControllerContext context)
        {
            var mcvRule = new ModelClientValidationRule
                              {
                                  ErrorMessage = string.Format(ClientErrorMessage, "test", string.Empty),
                                  ValidationType = ValidationType
                              };
            mcvRule.ValidationParameters["param"] = "value";
            yield return mcvRule;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(GetStringPropFromObj(value)))
                return ValidationResult.Success;

            PropertyInfo[] props = validationContext.ObjectInstance.GetType().GetProperties();
            foreach (var prop in props)
            {
                var atLeastOne = prop.GetCustomAttribute<AtLeastOne>();
                if(atLeastOne == null || atLeastOne.GroupKey != GroupKey)
                    continue;
                if (!string.IsNullOrEmpty(GetStringPropFromObj(prop.GetValue(validationContext.ObjectInstance))))
                    return ValidationResult.Success;
            }
            return new ValidationResult(string.Format(ServerErrorMessage, GroupKey));
        }

        private string GetStringPropFromObj(object obj)
        {
            if(obj != null && !(obj is string))
                throw new InvalidCastException("Only string proprties can be marked with AtLeastOne attribute");
            return obj as string;
        }
    }
}