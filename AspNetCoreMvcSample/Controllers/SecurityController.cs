using AspNetCoreMvcSample.Identity;
using AspNetCoreMvcSample.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AspNetCoreMvcSample.Controllers
{
    public class SecurityController : Controller
    {
        UserManager<AppIdentityUser> _userManager;
        SignInManager<AppIdentityUser> _signInManager;
        public SecurityController(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (user != null)
            {
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(string.Empty, "Confirm your email please");
                    return View(loginViewModel);
                }
            }

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Username or password is invalid");
            return View(loginViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index3", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            var user = new AppIdentityUser
            {
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email,
            };
            var result = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (result.Succeeded)
            {
                var confirmationCode = _userManager.GenerateEmailConfirmationTokenAsync(user);

                var callBackUrl = Url.Action("ConfirmEmail", "Security", new { UserId = user.Id, Code = confirmationCode.Result });

                //Send Email

                return RedirectToAction("Login");
            }
            ModelState.AddModelError(string.Empty, "Please check informations");
            return View(registerViewModel);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                throw new ApplicationException("UserId or code must be supplied for confirm email");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException("Unable to find the user");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return View("ConfirmEmail");
            }
            ModelState.AddModelError(string.Empty, "Please confirm email");
            return RedirectToAction("Index", "Student");   // Email doğrulanmadıysa yönlendirdik 

        }

        public IActionResult ForgotPassword()
        
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (email == null)
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return View();
            }

            var confirmationCode = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callBackUrl = Url.Action("ResetPassword", "Security", new { UserId = user.Id, Code = confirmationCode });

            // Send callback Url with email

            return RedirectToAction("ForgotPasswordEmailSent");

        }

        public IActionResult ForgotPasswordEmailSent()
        {
            return View();
        }

        public IActionResult ResetPassword(string userId, string code)
        {
            if (userId == null || code == null)
            {
                throw new ApplicationException("UserId or code must be supplied for password reset");
            }

            var model = new ResetPasswordViewModel { Code = code };
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPasswordViewModel);
            }

            var user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);
            if (user == null)
            {
                throw new ApplicationException("User not found");
            }
            var result = await _userManager.ResetPasswordAsync(user, resetPasswordViewModel.Code, resetPasswordViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirm");
            }
            return View();

        }

        public IActionResult ResetPasswordConfirm()
        {
            return View();
        }

    }
}
