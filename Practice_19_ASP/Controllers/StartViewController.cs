using Microsoft.AspNetCore.Mvc;
using Practice_19_ASP.Models;
using Practice_19_ASP.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;

namespace Practice_19_ASP.Controllers {
    [Authorize]
    public class StartViewController : Controller {
        private readonly DataContext _context;

        public StartViewController(DataContext context) {
            _context = context;
        }

        public IActionResult Index() {
            return View(_context.Contacts);
        }

        [HttpGet]
        public IActionResult DeleteData(int id) {
            var person = _context.Contacts.FirstOrDefault(c => c.Id == id);

            if(person == null) {
                return NotFound();
            }
            else {
                _context.Contacts.Remove(person);
                _context.SaveChanges();
            }

            return Redirect("~/");
        }

        public IActionResult Information() {
            return View();
        }
    }
}
