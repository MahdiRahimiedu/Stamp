using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stamp.Site.Models;

namespace Stamp.Site.Controllers
{
    public class StampOutputsController : Controller
    {
        private readonly StampDbContext _context;

        public StampOutputsController(StampDbContext Context)
        {
            _context = Context;
        }
        public IActionResult Index()
        {
            return View(_context.StampOutputs.ToList());
        }

        public IActionResult Details(int id)
        {
            return View(_context.StampOutputs.Find(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StampOutput stampOutput, IFormFile? img, IFormFile? img2)
        {
            stampOutput.FormOfTransformation = img == null ? null : ConvertFileBytes(img);
            stampOutput.MinutesForm = img2 == null ? null : ConvertFileBytes(img2);

            _context.StampOutputs.Add(stampOutput);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_context.StampOutputs.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, StampOutput stampOutput, IFormFile? img, IFormFile? img2)
        {
            stampOutput.FormOfTransformation = img == null ? null : ConvertFileBytes(img);
            stampOutput.MinutesForm = img2 == null ? null : ConvertFileBytes(img2);

            _context.StampOutputs.Update(stampOutput);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(_context.StampOutputs.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, StampOutput stampOutput)
        {
            _context.StampOutputs.Remove(stampOutput);
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
