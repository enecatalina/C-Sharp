using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
// Other usings
using Microsoft.EntityFrameworkCore;
using RESTauranter.Models;
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
        List<Reviews> AllUsers = _context.Review.ToList();
        // Other code
        return View();
    }
    
}

