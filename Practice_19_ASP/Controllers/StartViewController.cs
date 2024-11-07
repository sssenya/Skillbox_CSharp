using Microsoft.AspNetCore.Mvc;
using Practice_19_ASP.Models;
using Practice_19_ASP.Context;

namespace Practice_19_ASP.Controllers {
    public class StartViewController : Controller {

        public IActionResult Index() {
            ViewBag.Contacts = new DataContext().Contacts;
            return View();
        }

        public IActionResult ContactInfo(int id) {
            List<Contact> contacts = ViewBag.Contacts;
            var person = contacts.FirstOrDefault(c => c.Id == id);
            if(person == null) {
                return NotFound();
            }

            return View(person);
        }

        public IActionResult Information() {
            return View();
        }

        public IActionResult AddNewContact() {
            return View();
        }
    }
}
