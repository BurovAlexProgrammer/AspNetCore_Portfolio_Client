using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebDAL.Entity;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GuestController : ControllerBase
    {
        private ILogger<GuestController> _logger;

        public GuestController(ILogger<GuestController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet] //TODO change to POST later
        //[Route("Default/GetRecordsById/{id}")]
        [Route("{name}/{password}")]
        public IActionResult Login(string name, string password)
        {
            using var db = new PdbContext();

            var requiredGuest = GetGuest(name);

            if (requiredGuest == null)
            {
                return NotFound($"Гость с именем '{name}' не найден.");
            }

            if (requiredGuest.Password != password)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Неверный пароль.");
            }
            
            return new ObjectResult(requiredGuest);
            return NotFound($"Guest name: {name} not found");
        }

        private Guest GetGuest(string name)
        {
            using (var db = new PdbContext())
            {
                var result = db.Guests.Where(x => x.Name == name).ToList();

                if (result.Count > 1)
                {
                    _logger.LogError($"db.Guest - exc: duplicate guest name '{name}'");
                    return null;
                }

                if (result.Count == 0)
                {
                    _logger.LogError($"db.Guest - guest '{name}' not found.");
                    return null;
                }

                return result.First();
            }
        } 
    }
}