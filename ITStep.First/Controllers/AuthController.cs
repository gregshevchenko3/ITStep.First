using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ITStep.First.Models;
using ITStep.First.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ITStep.First.Controllers
{
    public class AuthController : Controller
    {
        AppDbContext _ctx;
        ILogger<AuthController> _logger;

        public AuthController(AppDbContext ctx)
        {
            _ctx = ctx;
            ILoggerFactory loggerFactory = LoggerFactory.Create(opts => opts.AddConsole());
            _logger = loggerFactory.CreateLogger<AuthController>();
        }
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            _logger.LogInformation($"Login: {model.Username}; Password: {model.Password}");
            if (ModelState.IsValid)
            {
                User user = await _ctx.Users.Include(u => u.Roles)
                    .FirstOrDefaultAsync(u => (u.Email.ToLower() == model.Username.ToLower() || u.Login.ToLower() == model.Username.ToLower()) && u.Secret == model.Password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "User name or password are invalid");
            }
            return View(model);
        }
        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>();
            
            claims.Add(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email ?? user.Login));
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Name));
            }
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
