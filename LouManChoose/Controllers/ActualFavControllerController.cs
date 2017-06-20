using LouManChoose.Models;
using LouManChoose.veiwModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace LouManChoose.Controllers
{
    [Authorize]
    public class ActualFavControllerController : ApiController
    {
        // For favoriting restaurants.
        [HttpPost]
        public IHttpActionResult Fav(FavoriteViewModel data)
        {
            var userid = HttpContext.Current.User.Identity.GetUserId();
            var db = new ApplicationDbContext();
            var post = db.Favorites.FirstOrDefault(f => f.GoogleId == data.id && f.UserId == userid);
            post.Faveorited = !post.Faveorited;
                   
            db.SaveChanges();
            return Ok(post);
        }

    }
}
