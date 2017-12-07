using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Session;
using BeltExam.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace BeltExam.Controllers
{
    public class AuctionController : Controller
    {
        private BeltExamContext _context;

        public AuctionController(BeltExamContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/createAuctions")]
        public IActionResult createAuctions()
        {  
            return View();
        }

        [HttpPost]
        [Route("/createAuctions")]
        public IActionResult createAuctions(AuctionViewModel newAuct)
        {
            int? CurrentUser = HttpContext.Session.GetInt32("CurrentUser");
            Users user = _context.Users.Where(x => x.idUser == CurrentUser).SingleOrDefault();

            if (newAuct.EndDate < DateTime.Now)
            {
                ViewBag.DateError = "End Date must be after today";
                return View("createAuctions");
            }
            if (ModelState.IsValid)
            {
                Auctions auction = new Auctions
                {
                    Product = newAuct.Product,
                    StartingBid = newAuct.StartingBid,
                    Description = newAuct.Description,
                    EndDate = newAuct.EndDate,
                    
                    idUser = user.idUser,
                }; 
               
                    _context.Add(auction);
                    _context.SaveChanges();
                    return Redirect("/Dashboard");
                }
            return Redirect("/Dashboard");
        }
        [HttpGet]
        [Route("/auctionprofile/{idAuction}")]
        public IActionResult AuctionProfile(int idAuction)
        {
            if (HttpContext.Session.GetString("CurrentUser") == null)
            {
                return RedirectToAction("loginpage");
            }
            else
            {
                Auctions auctionprofile = _context.Auctions.SingleOrDefault(u => u.idAuction == idAuction);
                ViewBag.auctionprofile = auctionprofile;

                Auctions auction = _context.Auctions.Include(a => a.User).Include(a => a.Bids).ThenInclude(b => b.User).Where(a => a.idAuction == idAuction).SingleOrDefault();
                ViewBag.auction = auction;

                return View();
            }
        }
        [HttpGet]
        [Route("/delete/{idAuction}")]
        public IActionResult deleteAuction(int idAuction)
        {
            int? CurrentUser = HttpContext.Session.GetInt32("CurrentUser");
            Auctions deleteAuction = _context.Auctions.SingleOrDefault(x => x.idAuction == idAuction);

            _context.Remove(deleteAuction);
            _context.SaveChanges();

            return Redirect("/Dashboard");
        }
    }

}