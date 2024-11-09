using Microsoft.AspNetCore.Mvc;
using Practice_19_ASP.Context;
using System.Net;
using System.Numerics;

namespace Practice_19_ASP.Controllers {
    public class ContactInfoController : Controller {
        [HttpGet]
        public IActionResult Index(int id) {
            var person = new DataContext().Contacts.FirstOrDefault(c => c.Id == id);
            if(person == null) {
                return NotFound();
            }

            return View(person);
        }

        public IActionResult UpdateData(int id,
                                        string name,
                                        string lastName,
                                        string middleName,
                                        string phone,
                                        string address,
                                        string description) {
            using(var db = new DataContext()) {
                var person = db.Contacts.FirstOrDefault(c => c.Id == id);

                if(person == null) {
                    return NotFound();
                }
                else {
                    person.Name = name;
                    person.LastName = middleName;
                    person.MiddleName = middleName;
                    person.Phone = phone;
                    person.Address = address;
                    person.Description = description;

                    db.SaveChanges();
                }
            }
            return Redirect("~/");
        }
    }
}
