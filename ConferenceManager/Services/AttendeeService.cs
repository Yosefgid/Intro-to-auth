using ConferenceManager.Models;
using ConferenceManager.Repositories;

namespace ConferenceManager.Services
{
    public interface IAttendeeServices
    {
        public List<Attendee> FetchAllAttendees();

        public Attendee FetchAttendeeById(int attendeeId);
        public Attendee AddAttendee(Attendee attendee);

        public Attendee UpdateAttendee(int attendeeId, Attendee updateAttendee);
        public bool DeleteAttendee(int attendeeId);

    }
    public class AttendeeService : IAttendeeServices
    {
        private readonly IAttendeeRepo _attendeeRepo;
        public AttendeeService(IAttendeeRepo attendeeRepo)
        {
            _attendeeRepo = attendeeRepo;
        }

        public List<Attendee> FetchAllAttendees()
        {
            return _attendeeRepo.FetchAttendees();
            
        }
        public Attendee FetchAttendeeById(int attendeeId)
        {
            return _attendeeRepo.FetchAttendeeById(attendeeId);
        }
        public Attendee AddAttendee(Attendee attendee)
        {
            return _attendeeRepo.AddAttendee(attendee);
        }

        public Attendee UpdateAttendee(int attendeeId, Attendee updateAttendee)
        {
            return _attendeeRepo.UpdateAttendee(attendeeId, updateAttendee);
        }
        public bool DeleteAttendee(int attendeeId)
        {
            return _attendeeRepo.DeleteAttendee(attendeeId);
        }
    }
}
