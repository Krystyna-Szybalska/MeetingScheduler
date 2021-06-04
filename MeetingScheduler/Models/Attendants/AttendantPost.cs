using System.ComponentModel.DataAnnotations;

namespace MeetingScheduler.Models
{
    public class AttendantPost
    {
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
