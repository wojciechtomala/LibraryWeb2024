using LibraryWeb2024.DataAccess.Data;
using LibraryWeb2024.DataAccess.Repository.IRepository;
using LibraryWeb2024.Models;
using LibraryWeb2024.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWeb2024.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        // GET APPLICATION IMPLEMENTATION:
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // CATEGORY CONTROLLER WHICH HANDLE DATABASE OPERATIONS
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        // CATEGORY VIEW - GET:
        public IActionResult Create()
        {
            return View();
        }
        // FORM SUBMIT HANDLER:
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                // ADD / SAVE NEW DATA: obj:
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
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
            Category categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
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
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
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
            Category categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
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
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category has been deleted!";
            return RedirectToAction("Index", "Category");
        }
    }
}
