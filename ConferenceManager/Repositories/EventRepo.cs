using System.Collections;
using System.Text.Json;
using ConferenceManager.Models;
using Microsoft.Extensions.Options;

namespace ConferenceManager.Repositories
{
    public interface IEventRepo 
    {
        public List<Event> FetchEvents();
        public Event FetchEventbyId(int id);

        public Event AddEvent(Event e);
    }

    public class EventRepo : IEventRepo
    {
        private readonly string filePath = "EventData.json";

        JsonSerializerOptions options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true , WriteIndented = true};

        public List<Event> FetchEvents()
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Event>>(json, options); 

        }
        public Event FetchEventbyId(int id )
        {
            return FetchEvents().FirstOrDefault(e => e.Id == id);
        }

        public Event AddEvent(Event e)
        {

            var events = FetchEvents();
            

            e.Id = events.Any() ? events.Max(e => e.Id) + 1 : 1;
            events.Add(e);

            string result = JsonSerializer.Serialize(events, options);
            File.WriteAllText(filePath, result);

            return e;
        }
    }
}
//I was thinking why we need the constructor instead of loading the json file everytime we create a method
// we could load it once and assign it to a field  like public readonly List<Event> _events and readonl only this class can see it 
//public EventRepo(){var json = File.....; _events =Json.Des......} and then our public fetchevtn will be like rerurn _event