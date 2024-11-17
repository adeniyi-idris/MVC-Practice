using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> category = _context.Categories.ToList();
            return View(category);
        }

        //Get
        public IActionResult Create()
        { 
            return View();
        }

        //Post
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                //var category = _context.Categories.Add();
                _context.Categories.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryDb = _context.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (categoryDb == null)
            {
                return NotFound();
            }

            return View(categoryDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                //var category = _context.Categories.Add();
                _context.Categories.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryDb = _context.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (categoryDb == null)
            {
                return NotFound();
            }

            return View(categoryDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var categoryDb = _context.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (categoryDb == null)
            {
                return NotFound();
            }
            //var category = _context.Categories.Add();
            _context.Categories.Remove(categoryDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
            
            //return View(obj);
        }



    }
}
