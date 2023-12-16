using LibraryWeb2024.DataAccess.Data;
using LibraryWeb2024.DataAccess.Repository.IRepository;
using LibraryWeb2024.Models;
using LibraryWeb2024.Models.ViewModels;
using LibraryWeb2024.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryWeb2024.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        // GET APPLICATION IMPLEMENTATION:
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        // PRODUCT CONTROLLER WHICH HANDLE DATABASE OPERATIONS
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties:"Category").ToList();
            return View(objProductList);
        }
        // PRODUCT VIEW - GET:
        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ProductVM productVM = new()
            {
                CategoryList = CategoryList,
                Product = new Product()
            };
            if (id == null || id == 0)
            {
                // CREATE
                return View(productVM);
            }
            else {
                // UPDATE
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }
        }
        // FORM SUBMIT HANDLER:
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                // SAVING PRODUCT IMAGE:
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null) { 
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    if (!string.IsNullOrEmpty(productVM.Product.ImageUrl)) { 
                        // DELETE THE OLD IMAGE AND REPLACE WITH NEW ONE:
                        var oldImagePath = Path.Combine(wwwRootPath,productVM.Product.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath)) { 
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create)) { 
                        file.CopyTo(fileStream);
                    }
                    productVM.Product.ImageUrl = @"\images\product\" + fileName;
                }
                if (productVM.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(productVM.Product);
                }
                else { 
                    _unitOfWork.Product.Update(productVM.Product);
                }
                // ADD / SAVE NEW DATA: obj:
                //_unitOfWork.Product.Add(productVM.Product);
                _unitOfWork.Save();
                // REDIRECT - VIEW PAGE / CONTROLLER:
                TempData["success"] = "New product has been added!";
                return RedirectToAction("Index", "Product");
            }
            else {
                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(productVM);
            }
        }

        // PRODUCT VIEW - DELETE:
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        // FORM SUBMIT HANDLER:
        [HttpPost, ActionName("Delete")]
        public IActionResult Delete_POST(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product has been deleted!";
            return RedirectToAction("Index", "Product");
        }
    }
}
