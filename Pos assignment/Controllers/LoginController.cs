using infrastructurre.DTO;
using infrastructurre.Entities;
using infrastructurre.Repolayer.Inferface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using infrastructurre.Repolayer.Implementation;

namespace Pos_assignment.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public LoginController(SignInManager<User> signInManager, UserManager<User> userManager)
        { 
            _signInManager = signInManager;
            _userManager = userManager;
        }
        
        public IActionResult Index() 
        { 
         return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDTO model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByNameAsync(model.Username) ?? throw new Exception("Username is invalid.");

                    if (await _userManager.CheckPasswordAsync(user, model.Password) == false)
                    {
                        ModelState.AddModelError("Message", "Invalid credentials.");
                        return View(model);
                    }

                    var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

                    // var userDetail = _userRepo.GetQueryableWithNoTracking().Where(a => a.IdentityUserId == user.Id).Single();
                    if (result.Succeeded)
                    {
                        var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                        identity.AddClaim(new Claim("user_id", user.Id.ToString()));


                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return RedirectToAction("Index", "Dashboard");
                    }
                    else if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("Message", "Account is locked out.");
                    }
                    else
                    {
                        ModelState.AddModelError("Message", "Invalid login attempt");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Message", "Invalid credentials.");
            }
            return View();

        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
