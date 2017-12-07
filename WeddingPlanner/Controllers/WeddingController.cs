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
    public class WeddingController : Controller
    {
        private WedPlannerContext _context;

        public WeddingController(WedPlannerContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("/CreateWedding")]
        public IActionResult CreateWedding()
        {
            int? CurrentUser = HttpContext.Session.GetInt32("CurrentUser");
            Users user = _context.Users.Include(u => u.Weddings).Where(x => x.idUser == CurrentUser).SingleOrDefault();
            return View();
        }

        [HttpPost]
        [Route("/CreateWedding")]
        public IActionResult CreateWedding(WeddingViewModel CreateWedding)
        {
            int? CurrentUser = HttpContext.Session.GetInt32("CurrentUser");
            Users user = _context.Users.Where(x => x.idUser == CurrentUser).SingleOrDefault();

            if (ModelState.IsValid)
            {
                Weddings NewWedding = new Weddings();
                {
                    NewWedding.Bride = CreateWedding.Bride;
                    NewWedding.Groom = CreateWedding.Groom;
                    NewWedding.Date = CreateWedding.Date;
                    NewWedding.Address = CreateWedding.Address;
                    NewWedding.host = user;
                    NewWedding.CreatedAt = DateTime.Now;
                    NewWedding.UpdatedAt = DateTime.Now; 

                    _context.Add(NewWedding);
                    _context.SaveChanges();
                    return RedirectToAction("WeddingProfile");
                }
            }
            return View();
        }

        [HttpGet]
        [Route("/WeddingProfile")]
        public IActionResult WeddingProfile()
        {
            return View();
        }

        [HttpGet]
        [Route("/rsvp/{idWedding}")]
        public IActionResult RSVP(int idWedding)
        {
            if(HttpContext.Session.GetString("CurrentUser")== null)
            {
                return RedirectToAction("loginpage");
            }
            else
            {
                int? CurrentUser = HttpContext.Session.GetInt32("CurrentUser");
                // Users currentUser = _context.Users.SingleOrDefault(u => u.idUser == (int)CurrentUser);
                // Weddings selectedWedding = _context.weddings.SingleOrDefault(e => e.idWedding == weddingid);

                RSVP rsvp = new RSVP
                {
                    idWedding = idWedding,
                    idUser = (int)CurrentUser,
                };
                _context.Add(rsvp);
                _context.SaveChanges();
                return Redirect("/Dashboard");

            }
        }

        [HttpGet]
        [Route("/unRSVP/{idWedding}")]
        public IActionResult unRSVP(int idWedding)
        {
            if (HttpContext.Session.GetString("CurrentUser") == null)
            {
                return RedirectToAction("loginpage");
            }
            else
            {
                int? CurrentUser = HttpContext.Session.GetInt32("CurrentUser");
                // Users user = _context.Users.Where(x => x.idUser == CurrentUser).SingleOrDefault();
                // Weddings selectWedding = _context.weddings.SingleOrDefault(x => x.idWedding == weddingid);
                RSVP removeGuest = _context.rsvp.SingleOrDefault(x => x.idUser == (int)CurrentUser && x.idWedding == idWedding);
                _context.rsvp.Remove(removeGuest);
                _context.SaveChanges();
                return Redirect("/Dashboard");

            }
        }
        [HttpGet]
        [Route("/delete/{idWedding}")]
        public IActionResult DeleteWedding(int idWedding)
        {
            int? CurrentUser = HttpContext.Session.GetInt32("CurrentUser");
            Weddings deleteWedding = _context.weddings.SingleOrDefault(x => x.idWedding == idWedding);

            _context.Remove(deleteWedding);
            _context.SaveChanges();

            return Redirect("/Dashboard");
        }
    }
}