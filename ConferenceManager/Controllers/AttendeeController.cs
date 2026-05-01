using ConferenceManager.Models;
using ConferenceManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllAttendees()
        {
            return Ok(_attendeeService.FetchAllAttendees());

        }
        //[Authorize]
        [HttpGet("{attendeeId")]
        public IActionResult GetAllAttendeeById(int attendeeId)
        {
            return Ok(_attendeeService.FetchAttendeeById(attendeeId));
        }

        //[Authorize(Roles = "Admin"]
        [HttpPost]
        public IActionResult AddAttendee(Attendee newAttendee)
        {
            var created = _attendeeService.AddAttendee(newAttendee);
            return CreatedAtAction(nameof(GetAllAttendeeById), new { id = newAttendee.AttendeeId }, newAttendee);
        }


        //[Authorize(Roles = "Admin"]
        [HttpPut("{attendeeId}")] 
        public IActionResult UpdateAttendee(int attendeeId, Attendee updateAttendee)
        {
            var result = _attendeeService.UpdateAttendee(attendeeId, updateAttendee);
            return Ok(result);
        }



        //[Authorize(Roles = "Admin"]
        [HttpDelete("{attendeeId}")]
        public IActionResult DeleteAttendee(int attendeeId)
        {
            var result = _attendeeService.DeleteAttendee(attendeeId);
            return NoContent();
        }



    }
}
