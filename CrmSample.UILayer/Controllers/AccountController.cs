using CrmSample.EntityLayer.Concrete;
using CrmSample.UILayer.Helpers;
using CrmSample.UILayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrmSample.UILayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(forgotPasswordModel);

            var user = await _userManager.FindByEmailAsync(forgotPasswordModel.Email);

            if (user != null)
            {
                //return RedirectToAction(nameof(ForgotPasswordConfirmation));

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var link = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);

                ForgotPassword forgotPassword = new ForgotPassword();
                UILayer.Helpers.ForgotPassword.SendEmailPasswordReset(user.Email, link);


                return RedirectToAction("ForgotPasswordConfirmation");
            }
            else
            {
                return RedirectToAction("ForgotPassword");
            }

        }

		public IActionResult ForgotPasswordConfirmation()
		{
			return View();
		}

		[HttpGet]
		public IActionResult ResetPassword(string token, string email)
		{
			var model = new ResetPassword { Token = token, Email = email };
			return View(model);
		}

		[HttpPost]

		public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
		{
			if (!ModelState.IsValid)
				return View(resetPassword);

			var user = await _userManager.FindByEmailAsync(resetPassword.Email);
			if (user == null)
				RedirectToAction("ResetPasswordConfirmation");

			var resetPasswordResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
			if (!resetPasswordResult.Succeeded)
			{
				foreach (var error in resetPasswordResult.Errors)
					ModelState.AddModelError(error.Code, error.Description);
				return View();
			}

			return RedirectToAction("ResetPasswordConfirmation");
		}

		public IActionResult ResetPasswordConfirmation()
		{
			return View();
		}

	}
}
