﻿namespace EventManagement.Entities
{
    public class Participant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAttending { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
