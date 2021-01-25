using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Session;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Zemoga.DTO;

namespace Zemoga.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private IOptions<List<UserToLogin>> _users;
        public AccountController(IOptions<List<UserToLogin>> users)
        {
            _users = users;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserToLogin userToLogin)
        {
            var user = _users.Value.Find(c => c.UserName == userToLogin.UserName && c.Password == userToLogin.Password);
            var controllerToRedirect = string.Empty;
            if (!(user is null))
            {
                controllerToRedirect = "/writer/Index";
                List<Claim> claims;
                if (user.UserName == "writer@writer.com")
                {
                    claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,userToLogin.UserName),
                        new Claim("FullName", userToLogin.UserName),
                        new Claim(ClaimTypes.Role, "Writer")
                    };
                }
                else
                {
                    controllerToRedirect = "/editor/Index";
                    claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, userToLogin.UserName),
                        new Claim("FullName", userToLogin.UserName),
                        new Claim(ClaimTypes.Role, "Editor")
                    };
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    RedirectUri = "/Home/Index"
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return Redirect(controllerToRedirect);
            }

            return Redirect("/Account/Error");
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}