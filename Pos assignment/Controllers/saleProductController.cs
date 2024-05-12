using infrastructurre.DTO;
using infrastructurre.Repolayer.Inferface;
using Microsoft.AspNetCore.Mvc;
using Pos_assignment.Helpers;

namespace Pos_assignment.Controllers
{
    public class saleProductController : Controller
    {
        private readonly ISaleProductRepo _SaleProductrepo;
        public saleProductController(ISaleProductRepo saleproductrepo)
        {
            _SaleProductrepo = saleproductrepo;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SaleProductDTO dto)
        {
             if (ModelState.IsValid)
            {
                _SaleProductrepo.save(dto);
                AlertHelper.setMessage(this, "Product Succssfully Saved");
                return RedirectToAction("List");

            }
            return View();

        }
        public IActionResult list()
        {
            var SaleProductlist = _SaleProductrepo.List();
            return View(SaleProductlist);
        }
        public IActionResult Update(long id)
        {
            try
            {
                var dto = _SaleProductrepo.GetSaleProductDataForUpdate(id);
                return View(dto);
            }
            catch (Exception ex)
            {
                return View();
            }

        }
        [HttpPost]
        public IActionResult Update(SaleProductDTO dto)
        {
            if (ModelState.IsValid)
            {
                _SaleProductrepo.UpdateSaleProduct(dto);
                return RedirectToAction("List");
            }
            return View(dto);

        }

    }
}
