using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LetsPlay.Models;
using LetsPlay.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LetsPlay.Controllers
{

    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Takes user Registration page
        /// </summary>
        /// <returns>Registration View</returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        /// <summary>
        /// Posts user Registration data to interiorShoppeIdentityDb
        /// </summary>
        /// <param name="rvm">Register ViewModel</param>
        /// <returns>Home View</returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                // start the registration process
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = rvm.Email,
                    Email = rvm.Email,
                    Name = rvm.Name,
                    GamerTag = rvm.GamerTag,
                    Age = rvm.Age,
                    Location = rvm.Location
                };

                var result = await _userManager.CreateAsync(user, rvm.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(rvm);
        }

        /// <summary>
        /// Takes user Login page
        /// </summary>
        /// <returns>Login View</returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Verifies user login credentials
        /// </summary>
        /// <param name="lvm">Login ViewModel</param>
        /// <returns>Home View</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

                if (result.Succeeded)
                {
                    var userManager = _signInManager.UserManager;
                    var user = await userManager.FindByEmailAsync(lvm.Email);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Wrong username or passsword");
                }
            }

            return View(lvm);
        }

        /// <summary>
        /// Logs user out of the web app
        /// </summary>
        /// <param name="rvm">Register ViewModel</param>
        /// <returns>Home View</returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}