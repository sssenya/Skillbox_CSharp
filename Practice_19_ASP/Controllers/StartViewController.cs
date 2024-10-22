using Microsoft.AspNetCore.Mvc;
using Practice_19_ASP.Models;

namespace Practice_19_ASP.Controllers {
    public class StartViewController : Controller {
        public IActionResult Index() {
            List<Contact> contacts = new List<Contact>() {
                new Contact() { Id = 1000, Name = "hanme1ef", LastName = "sdfsdf" },
                new Contact() { Id = 1001, Name = "gdfg", LastName = "sdfsf" },
                new Contact() { Id = 1002, Name = "hanme1ef", LastName = "sfdf" },
                new Contact() { Id = 1003, Name = "hanme1ef", LastName = "dsf" }
            };
            return View(contacts);
        }
    }
}
