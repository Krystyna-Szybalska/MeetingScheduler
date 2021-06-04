using MeetingScheduler.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetingScheduler.Controllers
{
    public class MeetingGet
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IList<AttendantGet> Attendants { get; set; }
    }
}
