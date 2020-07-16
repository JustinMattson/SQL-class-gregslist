using System.ComponentModel.DataAnnotations;

namespace fullstack_gregslist.Models
{
    public class DTOCarFavorite
    {
        public int Id { get; set; }
        [Required]
        public int CarId { get; set; }
        public string User { get; set; }
    }
}