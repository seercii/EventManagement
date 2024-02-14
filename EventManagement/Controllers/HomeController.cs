using EventManagement.Context;
using EventManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EventManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var events = _context.Events.ToList();
            return View(events);
        }
        [HttpPost]
        public IActionResult Delete(int eventId)
        {
            var eventToDelete = _context.Events.Find(eventId);

            if (eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
