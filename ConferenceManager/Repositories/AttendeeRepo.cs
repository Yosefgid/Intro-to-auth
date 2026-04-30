using ConferenceManager.Models;

namespace ConferenceManager.Repositories
{
    public interface IAttendeeRepo
    {
        List<Attendee> FetchAttendees(int eventId);

        Attendee FetchAttendeeById(int eventId ,int attendeeId);

    }
    public class AttendeeRepo
    {
        private readonly List<Attendee> _attendees;


        
    }
}
