using EventManagement.Context;
using EventManagement.Entities;
using EventManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly AppDbContext _context;

        public ParticipantController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AddParticipant(int eventId)
        {
            var addParticipantViewModel = new AddParticipant { EventId = eventId };
            return View(addParticipantViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddParticipant(AddParticipant addParticipant)
        {
            if (ModelState.IsValid)
            {
                
                addParticipant.IsAttending = true;
        
                var participant = new Participant
                {
                    FirstName = addParticipant.FirstName,
                    LastName = addParticipant.LastName,
                    Email = addParticipant.Email,
                    IsAttending = addParticipant.IsAttending,
                    EventId = addParticipant.EventId
                };

                _context.Participants.Add(participant);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Details", new { id = addParticipant.EventId });
            }

            return View(addParticipant);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteParticipant(int id)
        {
            var participant = await _context.Participants.FindAsync(id);

            if (participant == null)
            {
                return NotFound();
            }

            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Details", new { id = participant.EventId });
        }
    }
}
