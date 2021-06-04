using System.ComponentModel.DataAnnotations;

namespace MeetingScheduler.Models.Meetings
{
    public class MeetingPost
    {
        [Required]
        public string Name { get; set; }
    }
}
