
using ConferenceManager.Models;
using System.Text.Json;

namespace ConferenceManager.Repositories
{
    public interface IAttendeeRepo
    {
        public List<Attendee> FetchAttendees();

        public Attendee FetchAttendeeById(int attendeeId);
        public Attendee AddAttendee(Attendee attendee);

        public Attendee UpdateAttendee(int attendeeId, Attendee updateAttendee);
        public bool DeleteAttendee(int attendeeId);

    }
    public class AttendeeRepo : IAttendeeRepo
    {
        private readonly string filePath = "/AttendeeData.json";
        JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true };


        public List<Attendee> FetchAttendees()
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Attendee>>(json);
        }

        public Attendee FetchAttendeeById(int attendeeId)
        {
            return FetchAttendees().FirstOrDefault(a => a.AttendeeId == attendeeId);
        }

        public Attendee AddAttendee(Attendee attendee)
        {
            var attendees = FetchAttendees();
            attendee.AttendeeId = attendees.Count > 0 ? attendees.Max(a => a.AttendeeId) + 1 : 1;
            attendees.Add(attendee);
            var result = JsonSerializer.Serialize(attendees, options);
            File.WriteAllText(filePath, result);
            return attendee;

        }

        public Attendee UpdateAttendee(int attendeeId, Attendee updateAttendee)
        {
            var attendees = FetchAttendees();
            var attending = attendees.FirstOrDefault(a => a.AttendeeId == attendeeId);
            //attending.UserId = updateAttendee.UserId; POTENTIALLY CAN BE USED
            attending.EventId = updateAttendee.EventId;
            var result = JsonSerializer.Serialize(attendees, options);
            File.WriteAllText(filePath, result);
            return attending;
        }
        public bool DeleteAttendee(int attendeeId)
        {
            var attendees = FetchAttendees();
            var attendee = attendees.FirstOrDefault(a => a.AttendeeId == attendeeId);
            attendees.Remove(attendee);
            var result = JsonSerializer.Serialize(attendees, options);
            File.WriteAllText(filePath, result);
            return true;
        }


    }
}










