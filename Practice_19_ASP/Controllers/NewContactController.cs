using Microsoft.AspNetCore.Mvc;
using Practice_19_ASP.Context;
using Practice_19_ASP.Models;

namespace Practice_19_ASP.Controllers {
    public class NewContactController : Controller {
        private readonly DataContext _context;

        public NewContactController(DataContext context) {
            _context = context;
        }

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
            _context.Contacts.Add(
                new Contact() {
                    Name = name,
                    LastName = middleName,
                    MiddleName = middleName,
                    Phone = phone,
                    Address = address,
                    Description = description
                });

            _context.SaveChanges();

            return Redirect("~/");
        }
    }
}
