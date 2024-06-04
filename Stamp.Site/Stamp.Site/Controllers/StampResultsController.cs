using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stamp.Site.Models;

namespace Stamp.Site.Controllers
{
    public class StampResultsController : Controller
    {
        private readonly StampDbContext _context;

        public StampResultsController(StampDbContext Context)
        {
            _context = Context;
        }

        public IActionResult Index()
        {
            return View(_context.StampResults.ToList());
        }

        public IActionResult Details(int id)
        {
            return View(_context.StampResults.Find(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StampResult stampResult)
        {
            _context.StampResults.Add(stampResult);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_context.StampResults.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, StampResult stampResult)
        {
            _context.StampResults.Update(stampResult);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(_context.StampResults.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, StampResult stampResult)
        {
            _context.StampResults.Remove(stampResult);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public byte[] ConvertFileBytes(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                byte[] fileBytes = ms.ToArray();
                return fileBytes;
            }
        }
    }
}
