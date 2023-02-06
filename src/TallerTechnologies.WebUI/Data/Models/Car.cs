using System.ComponentModel.DataAnnotations;

namespace TallerTechnologies.WebUI.Data.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; } = DateTime.Now.Year;
        [Required]
        [Range(1, 5)]
        public int Doors { get; set; } = 1;
        [Required]
        public string Color { get; set; } = "Black";
        [Required]
        public decimal Price { get; set; }
    }
}
