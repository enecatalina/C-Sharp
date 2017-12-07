
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//
using LoginRegister.Models;
using Newtonsoft.Json;
using LoginRegister.Factory;
// For Password Hashing :
using Microsoft.AspNetCore.Identity;


namespace LoginRegister.Controllers
{
    public class HomeController : Controller
    {
        private const string Current_User = "xyz123";

        // We started with the DB connector...
        private readonly DbConnector _dbConnector;
        // Now we've moved onto factories...
        private readonly UserFactory _userFactory;

        public HomeController(DbConnector connector)
        {
            _userFactory = new UserFactory();
            _dbConnector = connector;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index() //if a user is NOT in session direct them to the loginreg page
        {
            if (HttpContext.Session.GetString(Current_User) == null)
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
        public IActionResult Register(LoginRegViewModel registerUser)
        {
            RegisterViewModel registerVM = registerUser.registerVM;

            if(TryValidateModel(registerVM))
            {
                if(registerVM.RegisterPassword == registerVM.ConfirmPassword) //if the two passwords match
                {
                    PasswordHasher<RegisterViewModel> Hasher = new PasswordHasher<RegisterViewModel>();
                    registerVM.RegisterPassword = Hasher.HashPassword(registerVM, registerVM.RegisterPassword);
                    _userFactory.Register(registerUser.registerVM);
                    HttpContext.Session.SetString(Current_User, registerUser.registerVM.FirstName);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("/login")]
        public IActionResult Login(LoginRegViewModel logUser)
        {
            Users UserLoginIn = _userFactory.GetUserByEmail(logUser.loginVM.loginEmail);
            if (Current_User !=null)
            {
                //hash password
                PasswordHasher<Users> Hasher = new PasswordHasher<Users>();
                if (0 != Hasher.VerifyHashedPassword(UserLoginIn, UserLoginIn.Password, logUser.loginVM.loginPassword))
                {
                    //Handle success
                    HttpContext.Session.SetString(Current_User, UserLoginIn.FirstName);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
