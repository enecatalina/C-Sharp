using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeController.Controllers
{
    public class HomeController : Controller               //CardController inherits controller
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

        [HttpGet]
        [Route("projects")]
        public IActionResult Home()
        {
            return View("projects");
        }
        
        [HttpGet]
        [Route("contact")]
        public IActionResult Contact()
        {
            return View("contact");
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