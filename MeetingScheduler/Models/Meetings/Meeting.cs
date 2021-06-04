using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetingScheduler.Models
{
    public class Meeting
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; }
        public IList<Attendant> Attendants { get; set; }
    }
}
