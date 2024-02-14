using EventManagement.Context;
using EventManagement.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEvent(Event newEvent)
        {
            _context.Events.Add(newEvent);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
