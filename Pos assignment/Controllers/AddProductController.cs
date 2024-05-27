using infrastructurre.DTO;
using infrastructurre.Entities;
using infrastructurre.Repolayer.Implementation;
using infrastructurre.Repolayer.Inferface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pos_assignment.Helpers;

namespace Pos_assignment.Controllers
{
    [Authorize]
    public class AddProductController : Controller
    {
        private readonly IAddProductRepo _AddProductrepo;
        private readonly ICategoryRepo _catRepo;
        public AddProductController(IAddProductRepo addProductRepo, ICategoryRepo catRepo)
        {
            _AddProductrepo = addProductRepo;
            _catRepo = catRepo;
        }
        public IActionResult create()
        {
            List<CategoryATT> categoryList = _catRepo.List();
            ViewBag.CategoryList = new SelectList(categoryList, "Id", "Categoryname"); 

            //viewbag , viewdata, tempdata

            return View();
        }
        [HttpPost]
        public IActionResult create(AddProductDTO dto)
        {
            if (ModelState.IsValid)
            {
                _AddProductrepo.save(dto);
                AlertHelper.setMessage(this, "Product Succssfully Saved");
                return RedirectToAction("list");
            }
            return View();
        }
        public IActionResult List()
        {
            var AddProductlist = _AddProductrepo.List();
            return View(AddProductlist);
        }
        public IActionResult Update(long id)
        {
            try
            {
                var dto = _AddProductrepo.GetAddproductDataForUpdate(id);
                List<CategoryATT> categoryList = _catRepo.List();
                ViewBag.CategoryList = new SelectList(categoryList, "Id", "Categoryname", dto.category_id);
                return View(dto);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Update(AddProductDTO dto)
        {
            if (ModelState.IsValid)
            {
                _AddProductrepo.UpdateAddproduct(dto);
                return RedirectToAction("list");
            }
            return View(dto);
        }
        public IActionResult Delete(long id) 
        {
         _AddProductrepo.DeleteAddproduct(id);
          return RedirectToAction("list");    
        }


    }
}
