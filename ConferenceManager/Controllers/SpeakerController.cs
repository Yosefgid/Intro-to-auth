using ConferenceManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers
{

    [ApiController]
    [Route("/speaker")]
    public class SpeakerController : ControllerBase
    {
        private readonly ISpeakerService _speakerService;

        public SpeakerController(ISpeakerService speakerService)
        {
            _speakerService = speakerService;   
        }

        [HttpGet("{eventId}")]
        public IActionResult GetSpeakersByEventId(int eventId)
        {
            return Ok(_speakerService.FetchSpeakersbyEventId(eventId));
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("{eventId}")]
        public IActionResult AddSpeakerByEventId(int eventId)
        {
            var speaker = _speakerService.AddSpeakerToEvent(eventId);

            return CreatedAtAction(nameof(GetSpeakersByEventId), new { Id = speaker.SpeakersId }, speaker);
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{eventId}")]
        public IActionResult AddSpeakerByEventId(int eventId , int speakerId )
        {

            _speakerService.RemoveSpeakerAtEvent(eventId, speakerId);
            return NoContent();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{eventId}")]
        public IActionResult UpdateSpeakerinEvent(int eventId, int speakerId)
        {
            _speakerService.UpdateSpeakerinEvent(eventId, speakerId);
            return Ok(); 
        }







    }
}
