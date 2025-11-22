using System.ComponentModel.DataAnnotations;

namespace Backend.Models


{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; set; }
    }
}