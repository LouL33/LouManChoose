using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public bool Faveorited { get; set; } = true;
        public string GoogleId { get; set; }

        // TODO: change this back to a not list
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        

    }
}