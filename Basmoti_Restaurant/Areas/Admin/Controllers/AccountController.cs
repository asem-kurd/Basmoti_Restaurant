using Basmoti_Restaurant.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Basmoti_Restaurant.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AccountController : Controller
    {


        public UserManager<IdentityUser> UserManager { get; }
        public SignInManager<IdentityUser> SignInManager { get; }
        public AccountController(UserManager<IdentityUser> _UserManager, SignInManager<IdentityUser> _SignInManager)
        {
            UserManager = _UserManager;
            SignInManager = _SignInManager;
        }



        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel collection)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Required data...");
                    return View();
                }


                var data = new IdentityUser
                {
                    UserName = collection.Email,
                    Email = collection.Email,
                    //PasswordHash = collection.Password
                };


                var Res = await SignInManager.PasswordSignInAsync
                    (
                        collection.Email,
                        collection.Password,
                        isPersistent: collection.RememberMe,
                        false
                    );

                if (Res.Succeeded)
                {
                    await SignInManager.SignInAsync(data, isPersistent: false);
                    return RedirectToAction(actionName: "Index", "Home");
                }

                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel collection)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Required data...");
                    return View();
                }


                var data = new IdentityUser
                {
                    Email = collection.Email,
                    UserName = collection.Email,
                    //PasswordHash = collection.Password
                };


                var Res = await UserManager.CreateAsync(data, collection.Password);

                if (Res.Succeeded)
                {
                    await SignInManager.SignInAsync(data, isPersistent: false);
                    return RedirectToAction(actionName: "Index", "Home");
                }

                return RedirectToAction(nameof(Register));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }


    }
}
