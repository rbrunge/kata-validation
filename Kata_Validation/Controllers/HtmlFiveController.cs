using System;
using System.Linq;
using System.Web.Mvc;
using Kata_Validation.Models;

namespace Kata_Validation.Controllers
{
    public class HtmlFiveController : Controller
    {
        // GET: ValidateFormMvcServer
        public ActionResult Index()
        {
            var model = new TestModelNotAnnotated();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(TestModelNotAnnotated model)
        {
            var guid = Guid.NewGuid();
            GlobalVariables.InMemoryModels.Add(guid, model);
            return RedirectToAction("Show", new { id = guid });
        }

        public ActionResult Show(Guid id)
        {
            var model = GlobalVariables.InMemoryModels.FirstOrDefault(x => x.Key == id);
            return View(model.Value);
        }

    }
}