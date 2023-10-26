using System.Collections.Generic;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Constants;
using WebClient.Constants;
using WebDAL.Models;

namespace WebClient.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AccountLoginModel model)
        {
            if (ModelState.IsValid)
            {
                // var response = await Program.ApiClient.PostAsync(ApiEndpoints.AccountLogin, JsonContent.Create(model));
                // var accountJson = await response.Content.ReadAsStringAsync();
                //
                // if (response.IsSuccessStatusCode)
                // {
                //     HttpContext.Response.Cookies.Append(CookieNames.Account, accountJson);
                //     return Redirect(model.ReturnUrl);
                // }

                var claims = new List<Claim>() { new("Demo", "Value") };
                var claimsIdentity = new ClaimsIdentity(claims, "Cookie");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync("Cookie", claimsPrincipal);
                
                return Redirect(model.ReturnUrl);
            }

            return View(model);
        }

        public async Task<IActionResult> LogOff()
        {
            await HttpContext.SignOutAsync("Cookie");
            return Redirect(Endpoints.Home);
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}