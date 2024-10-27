using Microsoft.AspNetCore.Mvc;
using Practice_19_ASP.Models;

namespace Practice_19_ASP.Controllers {
    public class StartViewController : Controller {
        private List<Contact> _contacts = new List<Contact>() {
                new Contact() { Id = 1000, Name = "Ivan", LastName = "Ivanov" },
                new Contact() { Id = 1001, Name = "Nina", LastName = "Ninova" },
                new Contact() { Id = 1002, Name = "Alexey", LastName = "Alexeev" }
            };

        public IActionResult Index() {
            return View(_contacts);
        }

        public IActionResult ContactInfo(int id) {
            var person = _contacts.FirstOrDefault(c => c.Id == id);
            if(person == null) {
                return NotFound();
            }

            return View(person);
        }
    }
}
