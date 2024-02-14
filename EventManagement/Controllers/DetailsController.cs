using EventManagement.Context;
using EventManagement.Entities;
using EventManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Controllers
{
    public class DetailsController : Controller
    {
        private readonly AppDbContext _context;

        public DetailsController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Details(int id)
        {
            var evt = _context.Events.Include(e => e.Participants).FirstOrDefault(e => e.Id == id);
            var viewModel = new EventDetailViewModel
            {
                Event = evt,
                Participants = evt?.Participants.ToList()
            };
            return View(viewModel);
        }

       
    }
}
