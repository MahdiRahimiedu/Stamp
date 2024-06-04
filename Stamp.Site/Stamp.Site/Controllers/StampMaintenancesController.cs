using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stamp.Site.Models;

namespace Stamp.Site.Controllers
{
    public class StampMaintenancesController : Controller
    {
        private readonly StampDbContext _context;

        public StampMaintenancesController(StampDbContext Context)
        {
            _context = Context;
        }
        public IActionResult Index()
        {
            return View(_context.StampMaintenances.ToList());
        }

        public IActionResult Details(int id)
        {
            return View(_context.StampMaintenances.Find(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StampMaintenance stampMaintenance)
        {
            _context.StampMaintenances.Add(stampMaintenance);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_context.StampMaintenances.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, StampMaintenance stampMaintenance)
        {
            _context.StampMaintenances.Update(stampMaintenance);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(_context.StampMaintenances.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, StampMaintenance stampMaintenance)
        {
            _context.StampMaintenances.Remove(stampMaintenance);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
