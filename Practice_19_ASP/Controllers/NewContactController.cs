using Microsoft.AspNetCore.Mvc;
using Practice_19_ASP.Context;
using Practice_19_ASP.Models;

namespace Practice_19_ASP.Controllers {
    public class NewContactController : Controller {
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult GetDataFromViewField(string name, 
                                                  string lastName, 
                                                  string middleName, 
                                                  string phone, 
                                                  string address,
                                                  string description) {
            using(var db = new DataContext()) {
                db.Contacts.Add(
                    new Contact() {
                        Name = name,
                        LastName = middleName,
                        MiddleName = middleName,
                        Phone = phone,
                        Address = address,
                        Description = description
                    });

                db.SaveChanges();
            }
            return Redirect("~/");
        }

        public IActionResult DeleteData() {
            return Redirect("~/");
        }
    }
}
