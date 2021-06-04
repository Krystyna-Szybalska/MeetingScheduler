namespace MeetingScheduler.Models
{
    public class Attendant
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Meeting Meeting { get; set; }
    }
}
