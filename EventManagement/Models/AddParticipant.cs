namespace EventManagement.Models
{
    public class AddParticipant
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAttending { get; set; }
        public int EventId { get; set; }

    }
}
