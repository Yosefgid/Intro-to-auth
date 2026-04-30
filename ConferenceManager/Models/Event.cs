namespace ConferenceManager.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateOnly Date { get; set; }

        public string Venue { get; set; }
        public string Description {get; set; }

        public string Category { get; set; }

    }
}
