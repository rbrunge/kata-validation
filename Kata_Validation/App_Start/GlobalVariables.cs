using System;
using System.Collections.Generic;
using System.Web;
using Kata_Validation.Models;

namespace Kata_Validation
{
    public static class GlobalVariables
    {
        // read-write variable
        public static Dictionary<Guid, ITestModel> InMemoryModels
        {
            get
            {
                var value = HttpContext.Current.Application["models"] as Dictionary<Guid, ITestModel>;
                if (value == null)
                {
                    HttpContext.Current.Application["models"] = value = new Dictionary<Guid, ITestModel>();
                }
                return value;
            }
            set
            {
                HttpContext.Current.Application["models"] = value;
            }
        }
    }
}