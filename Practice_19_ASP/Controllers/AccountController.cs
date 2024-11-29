using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Practice_19_ASP.Authentication;

namespace Practice_19_ASP.Controllers {
    public class AccountController : Controller {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<User> userManager, 
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager) {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
    }

        [HttpGet]
        public IActionResult Login(string returnUrl = "/") {
            return View(new UserLogin() {
                ReturnUrl = returnUrl
            });
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
                    if(Url.IsLocalUrl(userLogin.ReturnUrl)) {
                        return Redirect(userLogin.ReturnUrl);
                    }

                    return RedirectToAction("Index", "StartView");
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
                    if(!await _roleManager.RoleExistsAsync(model.Role)) {
                        await _roleManager.CreateAsync(new IdentityRole(model.Role));
                    }

                    await _userManager.AddToRoleAsync(user, model.Role);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "StartView");
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

        [HttpGet]
        public async Task<IActionResult> Logout() {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "StartView");
        }
    }
}
