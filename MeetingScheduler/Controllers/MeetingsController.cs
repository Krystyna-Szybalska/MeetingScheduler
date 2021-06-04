using MeetingScheduler.Models;
using MeetingScheduler.Models.Meetings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingScheduler.Controllers
{
    [Route("api/Meetings")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly MeetingsContext _context;

        public MeetingsController(MeetingsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingGet>>> GetMeetings()
        {
            return await _context.Meetings
                .Include(a => a.Attendants)
                .Select(x => MeetingGet(x))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingGet>> GetMeeting(long id)
        {
            var meeting = await _context.Meetings.Include(a => a.Attendants).SingleOrDefaultAsync(a => a.Id == id);

            if (meeting == null)
            {
                return NotFound();
            }

            return MeetingGet(meeting);
        }

        [HttpPost]
        public async Task<ActionResult<MeetingGet>> CreateMeeting(MeetingPost meetingPost)
        {
            var meeting = new Meeting
            {
                Name = meetingPost.Name
            };

            _context.Meetings.Add(meeting);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetMeeting),
                new { id = meeting.Id },
                MeetingGet(meeting));
        }
        [HttpPost("{id}/Attendant")]
        public async Task<ActionResult<AttendantGet>> AddAttendant(long id, AttendantPost attendantPost)
        {

            var meeting = await _context.Meetings.Include(a => a.Attendants).SingleOrDefaultAsync(a => a.Id == id);
            var attendant = new Attendant
            {
                Name = attendantPost.Name,
                Email = attendantPost.Email
            };
            
            if (meeting.Attendants.Count == 25)
            {
                return BadRequest();
            }
            meeting.Attendants.Add(attendant);
            await _context.SaveChangesAsync();
            AttendantGet attendantGet = new AttendantGet() { Name = attendant.Name, Email = attendant.Email };
            return base.Ok(attendantGet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeeting(long id)
        {
            var meeting = await _context.Meetings.FindAsync(id);

            if (meeting == null)
            {
                return NotFound();
            }

            _context.Meetings.Remove(meeting);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool MeetingExists(long id)
        {
            return _context.Meetings.Any(e => e.Id == id);
        }

        private static MeetingGet MeetingGet(Meeting meeting) =>
            new MeetingGet
            {
                Id = meeting.Id,
                Name = meeting.Name,
                Attendants = meeting.Attendants?.Select(a => new AttendantGet(a)).ToList()
            };
    }
}
