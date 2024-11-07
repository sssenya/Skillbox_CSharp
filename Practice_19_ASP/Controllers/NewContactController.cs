using Microsoft.AspNetCore.Mvc;
using Practice_19_ASP.Models;

namespace Practice_19_ASP.Controllers {
    public class NewContactController : Controller {
        public IActionResult Index() {
            return View();
        }

        public Contact GetDataFromViewField(string name, 
                                            string lastName, 
                                            string middleName, 
                                            string phone, 
                                            string address,
                                            string description) {
            return new Contact() {
                Id = 1000,
                Name = name,
                LastName = middleName,
                MiddleName = middleName,
                Phone = phone,
                Address = address,
                Description = description
            };
        }
    }
}
