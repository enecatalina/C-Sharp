using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    public class UsersController : Controller
    {
        // GET: /Index/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Process(string First_Name, string Last_Name, int _Age, string _Email, string _Password)
        {
            User NewUser = new User
            {
                FirstName = First_Name,     ///left side is what is named in the models while the right side is what is named in the html form
                LastName = Last_Name,
                Age = _Age,
                Email = _Email,
                Password = _Password,

            };
            //Validations happen
            if (TryValidateModel(NewUser) == false)
            {
                ViewBag.ModelFields = ModelState.Values;
                return View("Index");
            }
            // otherwise validation passes, redirect to success
            else
            {
                return RedirectToAction("Success");  
            }

        }
        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            return View();
        }
    }
}
