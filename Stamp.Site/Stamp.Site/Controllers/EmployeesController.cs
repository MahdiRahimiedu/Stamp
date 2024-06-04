using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stamp.Site.Models;

namespace Stamp.Site.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly StampDbContext _context;

        public EmployeesController(StampDbContext Context)
        {
            _context = Context;
        }
        public IActionResult Index()
        {
            return View(_context.Employees.ToList());
        }

        public IActionResult Details(int id)
        {
            return View(_context.Employees.Find(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_context.Employees.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(_context.Employees.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }                                                                                                                                                                                                              
    }
}
