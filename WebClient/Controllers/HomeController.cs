using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
                // var t = ModelState.ToDictionary(x => x.Key, y => y.Value.RawValue.ToString());
                var response = await Program.ApiClient.GetAsync($"api/Guest/Login/{guest.Name}/{guest.Password}");
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var guestResponse = JsonConvert.DeserializeObject<Guest>(content);
                    HttpContext.Response.Cookies.Append("GuestName", guestResponse.Name);
                    return RedirectToRoute(Endpoints.Home);
                }
            }

            return View(guest);
        }

        public IActionResult Index()
        {
            var guest = new Guest() { Name = ControllerContext.HttpContext.Request.Cookies["GuestName"] };
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