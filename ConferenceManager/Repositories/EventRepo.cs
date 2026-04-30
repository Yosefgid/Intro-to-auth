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
            return FetchEvents().FirstOrDefault(e => e.Id == id);
        }
    }
}
//I was thinking why we need the constructor instead of loading the json file everytime we create a method
// we could load it once and assign it to a field  like public readonly List<Event> _events and readonl only this class can see it 
//public EventRepo(){var json = File.....; _events =Json.Des......} and then our public fetchevtn will be like rerurn _event