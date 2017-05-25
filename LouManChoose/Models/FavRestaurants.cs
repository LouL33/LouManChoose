using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LouManChoose.Models
{
    public class FavRestaurants
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}