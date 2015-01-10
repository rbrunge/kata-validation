using System;
using System.Linq;
using System.Web.Mvc;
using Kata_Validation.Helpers;
using Kata_Validation.Models;

namespace Kata_Validation.Controllers
{
    public class AjaxJqueryController : Controller
    {
        public ActionResult Index()
        {
            var model = new TestModelAnnotated();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(TestModelAnnotated model)
        {
            // Custom business rule
            // Fail if name and email both contains the letter 'a':
            if (!string.IsNullOrEmpty(model.Name) && !string.IsNullOrEmpty(model.Email) &&
                (model.Name.Contains("a") && model.Email.Contains("a")))
            {
                ModelState.AddModelError("Name", "Name and email both contains the letter 'a' - this is a server side business rule, appended during ajax-call");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetValidationResults();
                var x = errors.ToList();
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.DenyGet,
                    Data = new { result = "error", errors = x }
                };
            }

            var guid = Guid.NewGuid();
            GlobalVariables.InMemoryModels.Add(guid, model);
            return new JsonResult
            {
                Data = new { result = "success", guid = guid }
            };
            // return RedirectToAction("Show", new { id = guid });
        }

        public ActionResult Show(Guid id)
        {
            var model = GlobalVariables.InMemoryModels.FirstOrDefault(x => x.Key == id);
            return View(model.Value);
        }

    }
}