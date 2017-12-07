using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//
using Wall2.Models;
using Wall2.Factory; //Need to include reference to new Factory Namespace
using Newtonsoft.Json;

namespace Wall2.Controllers
{
    public class HomeController : Controller
    {
        private const string LOGGED_IN_USER = "xyz123";
       
        private readonly DbConnector _dbConnector;
        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;

        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString(LOGGED_IN_USER) == null)
            {
                return RedirectToAction("loginreg");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [Route("/loginreg")]
        public IActionResult LoginReg()
        {
            return View();
        }


        [HttpPost]
        [Route("/register")]
        public IActionResult Register(Users user)
        {
            if (ModelState.IsValid)
            {
                string query = $"INSERT INTO Users (FirstName, LastName, Email, Password, Created_at, Updated_at VALUES ('{user.FirstName}','{user.LastName}','{user.Email}','{user.Password}', NOW())";
                _dbConnector.Execute(query);
                string query2 = $"SELECT email, password, firstname, id FROM users WHERE email = '{user.Email}'";
                var theUser = _dbConnector.Query(query2);
                SessionExtensions.SetObjectAsJson(HttpContext.Session, "UserSession", theUser[0]);
                return RedirectToAction("Welcome");
            }
            
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginRegisterViewModel logVM)
        {
            Users user = userFactory.GetUserByEmail(logVM.loginVM.loginEmail);
            if (user != null)
            {
                if (user.Password == logVM.loginVM.loginPassword)
                {
                    HttpContext.Session.SetString(LOGGED_IN_USER, user.FirstName);
                    return RedirectToAction("Index");
                }
            }
            return View("loginreg");
        }

        [HttpGet]
        [Route("Success")]
        public IActionResult Success()
        {
            //We can call upon the methods of the userFactory directly now.
            return View();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(Messages userMessage)
        {
            if (TryValidateModel(userMessage))
            {
                messageFactory.Add(userMessage);

            }
            return RedirectToAction("Success");
        }
        [HttpGet]
        [Route("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }       
}