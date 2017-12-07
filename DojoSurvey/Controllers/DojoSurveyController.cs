using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DojoSurveyController.Controllers
{
    public class DojoSurveyController : Controller               //CardController inherits controller
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

        [HttpPost]
        [Route("Submit")]
        public IActionResult Submit(string name, string location, string lauguage, string comments)
        {
            // ViewBag.Errors = new List<string>();

            // if (name == null)
            // {
            //     ViewBag.Errors.Add("Name cannot be empty");
            // }

            // if (location == null)
            // {
            //     ViewBag.Errors.Add("Please select  a valid location");
            // }

            // if (lauguage == null)
            // {
            //     ViewBag.Errors.Add("Please select a valid language");
            // }

            // if (comments == null)
            // {
            //     ViewBag.comment = "";
            // }

            // if (ViewBag.Errors.Count > 0)
            // {
            //     return View("Index");
            // }
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.lauguage = lauguage;
            ViewBag.comments = comments;

            return View("success");
        }
    }
}