using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GuestController : ControllerBase
    {
        public GuestController()
        {

        }
        
        [HttpGet] //TODO change to POST later
        //[Route("Default/GetRecordsById/{id}")]
        [Route("{name}/{password}")]
        public IActionResult Login(string name, string password)
        {
            using var db = new PdbContext();

            var isExist = db.Guests.Any(x => x.Name == name && x.Password == password);

            if (isExist)
            {
                return new ObjectResult(db.Guests.First()); //new JsonResult($"Guest name: {name}");
            }

            return new ObjectResult(db.Guests.First());
            return NotFound($"Guest name: {name} not found");
        }
    }
}