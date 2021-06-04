using System.ComponentModel.DataAnnotations;

namespace MeetingScheduler.Models
{
    public class AttendantGet
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public AttendantGet()
        {

        }
        public AttendantGet(Attendant attendant)
        {
            Name = attendant.Name;
            Email = attendant.Email;
        }
    }
}
