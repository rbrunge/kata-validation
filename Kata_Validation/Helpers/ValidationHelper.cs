using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Kata_Validation.Helpers
{
    public static class ValidationHelper
    {
        public static IEnumerable<ValidationResult> GetValidationResults(this ModelStateDictionary dictionary)
        {
            foreach (var key in dictionary.Keys)
            {
                foreach (var error in dictionary[key].Errors)
                {
                    if (error != null)
                    {
                        yield return new ValidationResult(error.ErrorMessage, new string[] { key });
                    }
                }
            }
        }

    }
}