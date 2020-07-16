using System;
using System.ComponentModel.DataAnnotations;

namespace fullstack_gregslist.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        [Required]
        public string Body { get; set; }
    }

    public class ViewModelCarFavorite : Car
    {
        public int FavoriteId { get; set; }
    }
}