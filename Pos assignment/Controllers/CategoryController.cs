using infrastructurre.DTO;
using infrastructurre.Repolayer.Inferface;
using Microsoft.AspNetCore.Mvc;
using Pos_assignment.Helpers;

namespace Pos_assignment.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo _categoryrepo;
        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryrepo = categoryRepo;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                _categoryrepo.save(dto);
                AlertHelper.setMessage(this, "Category Added Succssfully");
                return RedirectToAction("List");

            }
            return View();
        }
        public IActionResult list()
        {
            var Categorylist = _categoryrepo.List();
            return View(Categorylist);
        }
        public IActionResult Delete(long id)
        {
            _categoryrepo.DeleteCategory(id);
            AlertHelper.setMessage(this, "Category Deleted Succssfully");
            return RedirectToAction("list");

        }
        public IActionResult Update(long id)
        {
            try
            {
                var dto = _categoryrepo.GetCategoryDataForUpdate(id);
                return View(dto);

            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Update(CategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                _categoryrepo.UpdateCategory(dto);
                AlertHelper.setMessage(this, "Category Edited Succssfully");
                return RedirectToAction("list");
            }
            return View(dto);
        }

    }
}
