using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
                _logger.Log(LogLevel.Information, "[Post]Login form is valid.");
                // var t = ModelState.ToDictionary(x => x.Key, y => y.Value.RawValue.ToString());
                var response = await Program.ApiClient.GetAsync($"api/Guest/Login/{guest.Name}/{guest.Password}");
                var json = await response.Content.ReadAsStringAsync();
            }
            else
            {
                _logger.Log(LogLevel.Warning, "[Post]Login form is not valid.");
            }

            return View(guest);
        }

        public IActionResult Index()
        {
            var t = ControllerContext.HttpContext.Request;
            var g = new Guest() { Name = "Alex" };
            return View(g);
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