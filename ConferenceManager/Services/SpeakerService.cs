using ConferenceManager.Models;
using ConferenceManager.Repositories;

namespace ConferenceManager.Services
{
    public interface ISpeakerService
    {
        List<Speaker> FetchSpeakersbyEventId(int eventId);

        Speaker AddSpeakerToEvent(int eventId);

        void RemoveSpeakerAtEvent(int eventId, int speakerId);

        Speaker UpdateSpeakerinEvent(int newEventId, int speakerId);
    } 
    public class SpeakerService : ISpeakerService
    {

        private readonly ISpeakerRepo _speakerRepo;

        public SpeakerService(ISpeakerRepo speakerRepo)
        {
            _speakerRepo = speakerRepo;   
        }


        public List<Speaker> FetchSpeakersbyEventId(int eventId)
        {
            return _speakerRepo.FetchSpeakersbyEventId(eventId);
        }

        public Speaker AddSpeakerToEvent(int eventId)
        {
            return _speakerRepo.AddSpeakerToEvent(eventId);
        }


        public void RemoveSpeakerAtEvent(int eventId, int speakerId)
        {
            _speakerRepo.RemoveSpeakerAtEvent(eventId, speakerId);
        }


        public Speaker UpdateSpeakerinEvent(int newEventId, int speakerId)
        {
            return _speakerRepo.UpdateSpeakerinEvent(newEventId, speakerId); 
        }

       
    }
}
