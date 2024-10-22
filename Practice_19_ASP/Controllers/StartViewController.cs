using Microsoft.AspNetCore.Mvc;

namespace Practice_19_ASP.Controllers {
    public class StartViewController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
