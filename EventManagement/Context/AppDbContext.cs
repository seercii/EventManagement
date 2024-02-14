using EventManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Context
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SERCAN\\SQLEXPRESS;initial Catalog=EventManagement;integrated Security=true;TrustServerCertificate=true;");
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }
    }
}
