using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Constants;
using WebClient.Constants;
using WebClient.Extensions;
using WebDAL.Entities;
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
                var response = await Program.ApiClient.PostAsync(ApiEndpoints.AccountLogin, JsonContent.Create(model));
                
                if (!response.IsSuccessStatusCode)
                {
                    // HttpContext.Response.Cookies.Append(CookieNames.Account, accountJson);
                    // return Redirect(model.ReturnUrl);
                    var message = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError("", message);
                    return View(model);
                }
                
                var accountJson = await response.Content.ReadAsStringAsync();
                var account = JsonSerializer.Deserialize<Account>(accountJson);
                account.role = Roles.User; //TODO from db
                var accountClaimsPrincipal = account.ToClaimsPrincipal(AuthSchemes.Cookie);
                await HttpContext.SignInAsync(AuthSchemes.Cookie, accountClaimsPrincipal);
                
                return Redirect(model.ReturnUrl);
            }

            return View(model);
        }

        public async Task<IActionResult> LogOff()
        {
            await HttpContext.SignOutAsync(AuthSchemes.Cookie);
            return Redirect(Endpoints.Home);
        }

        [Authorize(Policy = PolicyNames.User)]
        public IActionResult User()
        {
            return View();
        }

        
        [Authorize(Roles = PolicyNames.Admin)]
        public IActionResult Admin()
        {
            return View();
        }
        
        public IActionResult Profile()
        {
            return View();
        }
    }
}