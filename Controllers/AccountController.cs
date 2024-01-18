﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using IndainCuisine.Models;

namespace IndainCuisine.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userMngr,SignInManager<User> signInMngr)
        {
            userManager = userMngr;
            signInManager = signInMngr;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Username };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    bool isPersistent = false;
                    await signInManager.SignInAsync(user, isPersistent);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {

            await signInManager.SignOutAsync();
            var cart = new Cart(HttpContext);
            cart.Clear();
            cart.Save();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnURL };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.Username))
                {
                    if (!string.IsNullOrEmpty(model.Password))
                    {
                        var IsLogin = await signInManager.PasswordSignInAsync(
                            model.Username, model.Password, isPersistent: model.RememberMe,
                            lockoutOnFailure: false);
                        if (IsLogin.Succeeded)
                        {
                            if (!string.IsNullOrEmpty(model.ReturnUrl) &&
                                Url.IsLocalUrl(model.ReturnUrl))
                            {
                                return Redirect(model.ReturnUrl);
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Incorrect Username/Password.");
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please enter your password.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please enter your username");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
            }
            return View(model);
        }


        public ViewResult AccessDenied()
        {
            return View();
        }
    }
}