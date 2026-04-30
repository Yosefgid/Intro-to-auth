using System.Text.Json;
using ConferenceManager.Models;

namespace ConferenceManager.Repositories
{
    public interface IEventRepo 
    {
        public List<Event> FetchEvents();
        public Event FetchEventbyId(int id);
    }

    public class EventRepo : IEventRepo
    {
        private readonly string filePath = "Data/EventData.json";

        public List<Event> FetchEvents()
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Event>>(json);

        }
        public Event FetchEventbyId(int id )
        {
            var json = File.ReadAllText(filePath);
            var events = JsonSerializer.Deserialize<List<Event>>(json);
            return events.FirstOrDefault(a => a.Id == id);
        }
    }
}
