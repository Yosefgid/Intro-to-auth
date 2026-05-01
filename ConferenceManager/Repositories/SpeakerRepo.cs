using ConferenceManager.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ConferenceManager.Repositories
{
    public interface ISpeakerRepo
    {
        List<Speaker> FetchSpeakersbyEventId(int eventId);

        Speaker AddSpeakerToEvent(int eventId);

        void RemoveSpeakerAtEvent(int eventId, int speakerId);

        Speaker UpdateSpeakerinEvent(int newEventId, int speakerId );

    }
    public class SpeakerRepo : ISpeakerRepo
    {
        private readonly string FilePath = "SpeakerData.json";
        private readonly List<Speaker> _speakers;


        public List<Speaker> FetchSpeakersbyEventId(int eventId)
        {
            
            List<Speaker> speakers = JsonSerializer.Deserialize<List<Speaker>>(FilePath);
            return speakers.Where(x => x.EventId == eventId).ToList();

        }


        public Speaker AddSpeakerToEvent(int eventId)
        {
            List<Speaker> speakers = JsonSerializer.Deserialize<List<Speaker>>(FilePath);
            Speaker speaker = new Speaker();
            speaker.EventId = eventId;
            speaker.SpeakersId = speakers.Any() ? speakers.Max(x => x.SpeakersId) + 1 : 1;

            speakers.Add(speaker);

            string json = JsonSerializer.Serialize(speaker);

            File.WriteAllText(FilePath, json);
            return speaker;
        }

        public void RemoveSpeakerAtEvent(int eventId, int speakerId)
        {
            var speakers = FetchSpeakersbyEventId(eventId);
            Speaker speaker = speakers.FirstOrDefault(x => x.SpeakersId == speakerId );
            speakers.Remove(speaker);
        }

        public Speaker UpdateSpeakerinEvent(int newEventId, int speakerId)
        {
            List<Speaker> speakers = JsonSerializer.Deserialize<List<Speaker>>(FilePath);
            Speaker speaker = speakers.FirstOrDefault(x => x.SpeakersId == speakerId);

            if(speakers.Any(x => x.EventId == newEventId))
            {
                speaker.EventId = newEventId;
            }
            else
            {
                return null;
            }

                return speaker;
        }




    }
}

