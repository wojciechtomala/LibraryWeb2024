using LibraryWeb2024.Data;
using LibraryWeb2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWeb2024.Controllers
{
    public class CategoryController : Controller
    {
        // GET APPLICATION IMPLEMENTATION:
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        // CATEGORY CONTROLLER WHICH HANDLE DATABASE OPERATIONS
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        // CATEGORY VIEW - GET:
        public IActionResult Create() { 
            return View();
        }
        // FORM SUBMIT HANDLER:
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid) {
                // ADD / SAVE NEW DATA: obj:
                _db.Categories.Add(obj);
                _db.SaveChanges();
                // REDIRECT - VIEW PAGE / CONTROLLER:
                TempData["success"] = "New category has been added!";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        // CATEGORY VIEW - EDIT:
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        // FORM SUBMIT HANDLER:
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                // ADD / SAVE NEW DATA: obj:
                _db.Categories.Update(obj);
                _db.SaveChanges();
                // REDIRECT - VIEW PAGE / CONTROLLER:
                TempData["success"] = "Category has been updated!";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        // CATEGORY VIEW - DELETE:
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        // FORM SUBMIT HANDLER:
        [HttpPost, ActionName("Delete")]
        public IActionResult Delete_POST(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null) 
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category has been deleted!";
            return RedirectToAction("Index", "Category");
        }
    }
}
