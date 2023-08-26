using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Constants;
using WebClient.Constants;
using WebClient.Models;
using WebDAL.Entity;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Guest guest)
        {
            if (ModelState.IsValid)
            {
                var response = await Program.ApiClient.PostAsync(ApiEndpoints.GuestLogin, JsonContent.Create(guest));
                var guestJson = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    HttpContext.Response.Cookies.Append(CookieNames.Guest, guestJson);
                    return RedirectToAction("Index");
                }
            }

            return View(guest);
        }

        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index()
        {
            var guestCookie = ControllerContext.HttpContext.Request.Cookies[CookieNames.Guest];
            var guest = JsonSerializer.Deserialize<Guest>(guestCookie);
            return View(guest);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}