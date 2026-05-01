using ConferenceManager.Models;
using ConferenceManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConferenceManager.Controllers
{
    [ApiController]
    [Route("/attendees")]
    public class AttendeeController : Controller
    {
        private readonly IAttendeeServices _attendeeService;
        private readonly IEventService _eventService;

        public AttendeeController(IAttendeeServices attendeeServices, IEventService eventService)
        {
            _attendeeService = attendeeServices;
            _eventService = eventService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllAttendees()
        {

            var roles = HttpContext.User.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value);

            foreach (var item in roles)
            {
                Console.WriteLine(item);
            }

            return Ok(_attendeeService.FetchAllAttendees());

        }
        [Authorize]
        [HttpGet("{attendeeId}")]
        public IActionResult GetAttendeeById(int attendeeId)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var attendee = _attendeeService.FetchAttendeeById(attendeeId);
            if (attendee == null) return NotFound($"There is no Attendee with this associated id{attendeeId}");
            if(attendee.UserId != int.Parse(userId))
            {
                return Forbid();
            }
            return Ok(_attendeeService.FetchAttendeeById(attendeeId));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddAttendee(Attendee newAttendee)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            var e = _eventService.GetEventById(newAttendee.EventId);
            if(e == null)
            {
                return NotFound("event could not be found for this associated AttendeeId");
            }
            newAttendee.UserId = int.Parse(userId);
            var created = _attendeeService.AddAttendee(newAttendee);
            return CreatedAtAction(nameof(GetAttendeeById), new { id = newAttendee.AttendeeId }, newAttendee);
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("{attendeeId}")] 
        public IActionResult UpdateAttendee(int attendeeId, Attendee updateAttendee)
        {
            var result = _attendeeService.UpdateAttendee(attendeeId, updateAttendee);
            return Ok(result);
        }



        [Authorize(Roles = "Admin")]
        [HttpDelete("{attendeeId}")]
        public IActionResult DeleteAttendee(int attendeeId)
        {
            var result = _attendeeService.DeleteAttendee(attendeeId);
            return NoContent();
        }



    }
}
