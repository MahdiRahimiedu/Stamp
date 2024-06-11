using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stamp.Site.Models;

namespace Stamp.Site.Controllers
{
    public class StampMakersController : Controller
    {
        private readonly StampDbContext _context;

        public StampMakersController(StampDbContext Context)
        {
            _context = Context;
        }

        public IActionResult Index()
        {
            return View(_context.StampMakers.ToList());
        }

        public IActionResult Details(int id)
        {
            return View(_context.StampMakers.Find(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StampMaker stampMaker, IFormFile? img)
        {
            stampMaker.ConfirmationReceipt = img == null ? null : ConvertFileBytes(img);

            _context.StampMakers.Add(stampMaker);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_context.StampMakers.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, StampMaker stampMaker, IFormFile? img)
        {
            stampMaker.ConfirmationReceipt = img == null ? null : ConvertFileBytes(img);

            _context.StampMakers.Update(stampMaker);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(_context.StampMakers.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, StampMaker stampMaker)
        {
            _context.StampMakers.Remove(stampMaker);
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
