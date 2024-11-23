using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Practice_19_ASP.Authentication;

namespace Practice_19_ASP.Controllers {
    public class AccountController : Controller {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin userLogin) {
            if(ModelState.IsValid) {
                var result = await _signInManager.PasswordSignInAsync(
                    userLogin.UserName,
                    userLogin.Password,
                    false,
                    lockoutOnFailure: false);

                if(result.Succeeded) {
                    return RedirectToAction("Index", "Contacts");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(userLogin);
        }

        [HttpGet]
        public IActionResult Registration() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(UserRegistration model) {
            if(ModelState.IsValid) {
                var user = new User { UserName = model.UserName };
                var result = await _userManager.CreateAsync(user, model.Password);
                if(result.Succeeded) {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Redirect("StartView");
                }
                foreach(var error in result.Errors) {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AccessDenied() {
            return View();
        }
    }
}
