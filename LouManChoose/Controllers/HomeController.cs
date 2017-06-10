using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LouManChoose.veiwModels;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using LouManChoose.Models;
using Microsoft.AspNet.Identity;

namespace LouManChoose.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public ActionResult RedButton(UserLocation Point)
        {
            var googleKey = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?key=AIzaSyAUmnlcZvvd_b31I8JVPkHyeW-fUkJVbqM&radius=5000&location={0},{1}&type=restaurant";
            var url = string.Format(googleKey, Point.Latitude, Point.Longitude);

            var request = WebRequest.Create(url);
            var rawResponese = String.Empty;
            var response = request.GetResponse();

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawResponese = reader.ReadToEnd(); 
            }

            var googleData = JsonConvert.DeserializeObject<RootObject>(rawResponese);

            Random random = new Random();
            int number = random.Next(0, 20);
            var randomRest = googleData.results[number];

            if (User.Identity.GetUserId() != null)
            {
                var randomToSave = new FavRestaurants { Name = randomRest.name, /*Image = randomRest.photos.FirstOrDefault().photo_reference, */Address = randomRest.vicinity, UserId = User.Identity.GetUserId() };

                LouManChoose.Controllers.FavRestaurantsController.CoustomCreate(randomToSave);
            }


            return PartialView("_selectedLocations", randomRest);

        }
    }
}