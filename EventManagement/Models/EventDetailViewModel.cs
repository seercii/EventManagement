using EventManagement.Entities;

namespace EventManagement.Models
{
    public class EventDetailViewModel
    {
        public Event Event { get; set; }
        public List<Participant> Participants { get; set; }
    }
}
