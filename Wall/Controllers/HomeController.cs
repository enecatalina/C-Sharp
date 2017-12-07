using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//
using Wall.Models;
using Newtonsoft.Json;
using Wall.Factory;

namespace Wall.Controllers
{
    public class HomeController : Controller
    {
        private const string LOGGED_IN_USER = "xyz123";
        private readonly UserFactory userFactory;
        //private readonly DbConnector _dbConnector;

        public HomeController(DbConnector connect)
        {
            userFactory = new UserFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("/Register")]
        public IActionResult Register(LoginRegisterViewModel RegisterUser)
        {
            if (TryValidateModel(RegisterUser.registerVM))
            {
                ViewBag.errors = ModelState.Values;
                return View("Register");
            }
            else
            {
                userFactory.Register(RegisterUser.registerVM);
                HttpContext.Session.SetString(LOGGED_IN_USER, RegisterUser.registerVM.FirstName);
                return RedirectToAction("Success");
            }
        }   

        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
    }
}
