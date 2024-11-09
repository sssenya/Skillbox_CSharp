using Microsoft.AspNetCore.Mvc;
using Practice_19_ASP.Models;
using Practice_19_ASP.Context;

namespace Practice_19_ASP.Controllers {
    public class StartViewController : Controller {

        public IActionResult Index() {
            ViewBag.Contacts = new DataContext().Contacts;
            return View();
        }



        [HttpGet]
        public IActionResult DeleteData(int id) {
            using(var db = new DataContext()) {
                var person = db.Contacts.FirstOrDefault(c => c.Id == id);

                if(person == null) {
                    return NotFound();
                }
                else {
                    db.Contacts.Remove(person);
                    db.SaveChanges();
                }

            }
            return Redirect("~/");
        }

        public IActionResult Information() {
            return View();
        }

        public IActionResult AddNewContact() {
            return View();
        }
    }
}
