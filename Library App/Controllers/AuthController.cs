using Library_App.Models;
using Library_App.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App.Controllers
{
    public class AuthController: Controller
    {
        public UserManager<User> _userManager { get; }
        public SignInManager<User> _signInManager { get; }
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;         
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(model.UserName);        
                if(user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, true);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Password is not correct");
                    }
                }
                else
                {
                    user = new User { UserName = model.UserName, Email = model.UserName + "@mail.com" };

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, true);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var err in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, err.Description);
                        }
                    }
                }             
            }
            return View(model);
        }
    }
}
