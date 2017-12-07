using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Session;
using REST.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class ReviewsController : Controller
{
    private ReviewsContext _context;

    public ReviewsController(ReviewsContext context)
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
    [Route("/create")]
    public IActionResult Create(UserReview nr)
    {
        if (ModelState.IsValid)
        {
            UserReview NewUserReview = new UserReview
            {
                Reviewer = nr.Reviewer,
                Restaurants = nr.Restaurants,
                Review = nr.Review,
                Visit = nr.Visit,
                Stars = nr.Stars,
            };
            if( nr.Visit > DateTime.Now)
            {
                TempData["InvalidDate"] = "Date has to be before todays date";
            }
            else
            {
                _context.Add(NewUserReview);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
        }
        return RedirectToAction("Index");
    }
    [HttpGet]
    [Route("/Reviews")]
    public IActionResult Reviews()
    {
        List<UserReview> AllReviews = _context.Reviews.ToList();
        ViewBag["Reviews"] = AllReviews;
        return View();
    }
}



