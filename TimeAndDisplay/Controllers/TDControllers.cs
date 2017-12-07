using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TDControllers.Controllers
{
    public class TDController : Controller               //CardController inherits controller
    {
        [HttpGetAttribute]
        // Inside your Controller class
        // Other code

        // A GET method
        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            return View("Index");
        }

        // A POST method
        // [HttpPost]
        // [Route("")]
        // public IActionResult Other()
        // {
        //     // Return a view (We'll learn how soon!)
        // }


    }
}