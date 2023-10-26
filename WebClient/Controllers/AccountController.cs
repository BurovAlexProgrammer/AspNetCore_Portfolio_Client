using System.Net.Http.Json;
using System.Threading.Tasks;
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
                var response = await Program.ApiClient.PostAsync(ApiEndpoints.GuestLogin, JsonContent.Create(model));
                var accountJson = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    HttpContext.Response.Cookies.Append(CookieNames.Account, accountJson);
                    return Redirect(model.ReturnUrl);
                }
            }

            return View(model);
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}