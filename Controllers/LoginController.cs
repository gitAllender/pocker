using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using poker.Models;

namespace poker.Controllers
{
    public class LoginController : Controller
    {  
        List<Programmer> myRegisteredUsers = new List<Programmer>();
         
        public IActionResult Index()
        {
            return View();
        }
        
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        // [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model, string returnUrl = null)
        {
            //ViewData["ReturnUrl"] = returnUrl;
            
            // if ( !String.IsNullOrEmpty(returnUrl ))
            // {
            //     return RedirectToLocal(returnUrl);
            // }
            
            
            
            if (ModelState.IsValid)
            {
                myRegisteredUsers.Add( new Programmer( myRegisteredUsers.Count, model.Name  )  );
                
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
                
                
            //     // This doesn't count login failures towards account lockout
            //     // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            //     var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            //     if (result.Succeeded)
            //     {
            //         _logger.LogInformation(1, "User logged in.");
            //         return RedirectToLocal(returnUrl);
            //     }
            //     if (result.RequiresTwoFactor)
            //     {
            //         return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            //     }
            //     if (result.IsLockedOut)
            //     {
            //         _logger.LogWarning(2, "User account locked out.");
            //         return View("Lockout");
            //     }
            //     else
            //     {
            //         ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            //         return View(model);
            //     }
            // }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}