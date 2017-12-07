using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallingCard.Controllers
{
    public class CardController : Controller               //CardController inherits controller
    {
        [HttpGetAttribute]
        // Inside your Controller class
        // Other code

        // A GET method
        [HttpGet]
        [Route("/{FirstName}/{LastName}/{Age}/{FavColor}")]
        public JsonResult CallCard(string FirstName, string LastName, int Age, string FavColor)
        {
            //This builds a JSON response with the given route parameters
            return Json(new { FirstName = FirstName, LastName = LastName, Age = Age, FavoriteColor = FavColor });
        }

    }
}