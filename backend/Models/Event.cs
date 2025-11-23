using backend.Validators;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models


{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2,ErrorMessage ="name must be 2-50 characters")]
        public string Name { get; set; } = string.Empty;


        [StringLength(500, ErrorMessage = "maximum 500 characters")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage="date should be correct type")]
        [FutureDateAttribute(ErrorMessage = "Event date must be today or later.")]
        public DateTime Date { get; set; }
    }
}