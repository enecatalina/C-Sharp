using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Session;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private WedPlannerContext _context;

        public HomeController(WedPlannerContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Route("create")]
        public IActionResult Create(RegisterViewModel RegisterUser)
        {
            if (ModelState.IsValid)
            {
                PasswordHasher<Users> Hasher = new PasswordHasher<Users>();
                Users NewUser = new Users();
                NewUser.Password = Hasher.HashPassword(NewUser, RegisterUser.Password);
                NewUser.FirstName = RegisterUser.FirstName;
                NewUser.LastName = RegisterUser.LastName;
                NewUser.Email = RegisterUser.Email;
                NewUser.CreatedAt = DateTime.Now;
                NewUser.UpdatedAt = DateTime.Now;

                _context.Add(NewUser);
                _context.SaveChanges();
                //taking the last user that was put into the database and setting into a session
                int CurrentUser = _context.Users.Last().idUser;
                HttpContext.Session.SetInt32("CurrentUser", CurrentUser);
                return Redirect("Dashboard");
            }
            else
            {
                return View("Index", RegisterUser);
            }
        }
        [HttpGet]
        [Route("/loginpage")]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string Email, string Password)
        {
            //find the email
            Users CurrentUser = _context.Users.Where(x => x.Email == Email).SingleOrDefault();
            //match email and password
            if (CurrentUser != null && Password != null)
            {
                var Hasher = new PasswordHasher<Users>();
                if (0 != Hasher.VerifyHashedPassword(CurrentUser, CurrentUser.Password, Password))
                {
                    //set to session and redirect to success
                    HttpContext.Session.SetInt32("CurrentUser", CurrentUser.idUser);
                    return Redirect("Dashboard");
                }
            }
            return View("loginpage");
        }

        [HttpGet]
        [Route("/Dashboard")]
        public IActionResult Dashboard()
        {
            int? CurrentUser = HttpContext.Session.GetInt32("CurrentUser");
            //user including weddings model 
            Users user = _context.Users.Include(u => u.Weddings).Where(x => x.idUser == CurrentUser).SingleOrDefault();
            List<Weddings> AllWeddings = _context.weddings.Include(u => u.Guests).ToList();
            ViewBag.AllWeddings = AllWeddings;
            ViewBag.UserProfile = user;

            // List<Weddings> AllWeddings = _context.weddings.Include(u => u.Guests).ToList();
            return View();
        }

        [HttpGet]
        [Route("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("loginpage");
        }
    }

}