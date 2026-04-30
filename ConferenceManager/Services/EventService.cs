using ConferenceManager.Repositories;
using ConferenceManager.Models; 

namespace ConferenceManager.Services
{
    public interface IEventService
    {
        public List<Event> GetEvents();
        public Event GetEventById(int id);
    }
    public class EventService : IEventService
    {
        private readonly IEventRepo _eventRepo;

        public EventService(IEventRepo eventRepo)
        {
            _eventRepo = eventRepo;

        }
        public List<Event> GetEvents()
        {
            return _eventRepo.FetchEvents();
        }
        public Event GetEventById(int id)
        {
            return _eventRepo.FetchEventbyId(id);
        }
    }
}
