using ConferenceManager.Services;
using Microsoft.AspNetCore.Mvc;
using ConferenceManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace ConferenceManager.Controllers
{
    [ApiController]
    [Route("events")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        [HttpGet]
        public IActionResult GetAllEvents()
        {
            return Ok(_eventService.GetEvents());
        }
        [HttpGet("{id}")]
        public IActionResult GetEventById(int id)
        {
            var eventbyID = _eventService.GetEventById(id);
            return Ok(eventbyID);
        }

        [Authorize]
        [HttpPost]
        public IActionResult MakeEvent(Event e)
        {
            var createdEvent = _eventService.AddEvent(e);   
            return CreatedAtAction(nameof(GetEventById) , new {id = createdEvent.Id} , createdEvent);
        }
    }
}
