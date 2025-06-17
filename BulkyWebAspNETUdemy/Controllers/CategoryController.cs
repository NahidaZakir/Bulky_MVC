using BulkyWebAspNETUdemy.Data;
using BulkyWebAspNETUdemy.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWebAspNETUdemy.Controllers
{
    public class CategoryController : Controller
    {
        //Get Categories Data in the Category Controller
        //Get an implementtaion of ApplicationDbContext
        //Call constructor first
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        { _db = db;}

        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        //creating new action method 
        public IActionResult Create()
        {
            return View();
        }

        //form will be posted here so use HTTPpost data anootations;
        [HttpPost]
        //will get an obj of Category type
        public IActionResult Create(Category obj)
        {
            //custom validation
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                //here "name" is the key for the asp_validation_for
                ModelState.AddModelError("name", "Name and Display Order Cannot be same");
            }

            if (ModelState.IsValid)
            {
                //add it to the table
                _db.Categories.Add(obj);
                //save all the changes always
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        //Edit
        //creating new action method 
        public IActionResult Edit(int? id)
        {
            //get the specific ID category
            //find works on primary key only
            Category? categoryFromDb = _db.Categories.Find(id);
            //Alternative here you can check any values
            Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=> u.ID ==id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        //will get an obj of Category type
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                //Update it to the table
                _db.Categories.Update(obj);
                //save all the changes always
                _db.SaveChanges();
                TempData["success"] = "Category Edited Successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        //Delete
        //creating new action method 
        public IActionResult Delete(int? id)
        {
            //get the specific ID category
            //find works on primary key only
            Category? categoryFromDb = _db.Categories.Find(id);
            //Alternative here you can check any values
        
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        //will get an obj of Category type
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
          

        }
    }
}
