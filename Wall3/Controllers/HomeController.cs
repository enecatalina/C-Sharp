using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//
using Wall2.Models;
using Newtonsoft.Json;

namespace Wall2.Controllers
{
    public class HomeController : Controller
    {
        private const string LOGGED_IN_USER = "xyz123";
       
        private readonly DbConnector _dbConnector;

        public DbConnector DbConnector => _dbConnector;

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
                DbConnector.Execute(query);
                string query2 = $"SELECT Email, Password, Firstname, id FROM users WHERE Email = '{user.Email}'";
                var currentUser = DbConnector.Query(query2);
                SessionExtensions.SetObjectAsJson(HttpContext.Session, "UserInSession", currentUser[0]);
                return RedirectToAction("Index");
            }
            return View("loginreg");
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string email, string password)
        {
            TempData["Error"] = null;

            Login theUser = new Login
            {
                loginEmail = email,
                loginPassword = password,
            };

            if (TryValidateModel(theUser))
            {
                string query = $"SELECT FirstName, Email, Password id FROM Users WHERE Email = '{theUser.loginEmail}'";
                var currentUser = DbConnector.Query(query);
                if (currentUser.Count == 0)
                {
                    //validating if the email is in the database
                    string[] message = { "Email is not valid! Please try again!" };
                    TempData["Error"] = message;
                    return RedirectToAction("loginreg");
                    //if it is in the datebase check and see if the password is correct!
                }
                else if (password != (string)currentUser[0]["password"])
                {
                    string[] message = { "Password doesn't match the email! Please try again!" };
                    TempData["Error"] = message;
                    return RedirectToAction("loginreg");
                }
                else
                {
                    // Setting the session as an Json String to desirialize it later
                    SessionExtensions.SetObjectAsJson(HttpContext.Session, "UserInSession", currentUser[0]);
                    return RedirectToAction("Welcome");
                }
            }
            else
            {
                List<string> theErrors = new List<string>();
                foreach (var error in ModelState.Values)
                {
                    if (error.Errors.Count > 0)
                    {

                        theErrors.Add(error.Errors[0].ErrorMessage.ToString());
                    }
                }
                TempData["Error"] = theErrors;
                return RedirectToAction("Index");
            }
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
        public IActionResult Create(string MessageContent)
        {
            TempData["Error"] = null;

            Messages UserMessage = new Messages
            {
                Message = MessegeContent
            };

            if (TryValidateModel(UserMessage))
            {
                Users currentUser = SessionExtensions.GetObjectFromJson<Users>(HttpContext.Session, "UserSession");
                string query = $"INSERT INTO Messages (Users_id, Message, Created_at, Updated_at) " +
                $"VALUES ({currentUser.id}, '{UserMessage.Message}', NOW(), NOW())";
                _dbConnector.Execute(query);
                return RedirectToAction("Index");
            }
            else
            {
                List<string> theErrors = new List<string>();
                foreach (var error in ModelState.Values)
                {
                    if (error.Errors.Count > 0)
                    {

                        theErrors.Add(error.Errors[0].ErrorMessage.ToString());
                    }
                }
                TempData["Error"] = theErrors;
                return RedirectToAction("Success");
            }
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