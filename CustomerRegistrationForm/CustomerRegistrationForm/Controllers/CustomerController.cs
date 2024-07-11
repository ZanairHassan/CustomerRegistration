using CustomerRegistrationForm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CustomerRegistrationForm.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Cities = _context.Cities.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cities = _context.Cities.ToList();
            return View(customer);
        }

        public IActionResult Index(int page = 1, string sortOrder = "")
        {
            int pageSize = 5;
            var customers = _context.Customers.AsQueryable();

            // Sorting logic
            switch (sortOrder)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(c => c.CustomerName);
                    break;
                case "city_asc":
                    customers = customers.OrderBy(c => c.city_id);
                    break;
                case "city_desc":
                    customers = customers.OrderByDescending(c => c.city_id);
                    break;
                case "gender_asc":
                    customers = customers.OrderBy(c => c.Gender);
                    break;
                case "gender_desc":
                    customers = customers.OrderByDescending(c => c.Gender);
                    break;
                default:
                    customers = customers.OrderBy(c => c.CustomerName);
                    break;
            }

            var pagedCustomers = customers.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)customers.Count() / pageSize);

            return View(pagedCustomers);
        }

        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Find(id);
            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.Find(id);
            ViewBag.Cities = _context.Cities.ToList();
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cities = _context.Cities.ToList();
            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}