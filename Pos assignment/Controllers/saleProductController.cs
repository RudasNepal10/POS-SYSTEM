using infrastructurre.DTO;
using infrastructurre.Entities;
using infrastructurre.Repolayer.Inferface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pos_assignment.Helpers;

namespace Pos_assignment.Controllers
{
    public class saleProductController : Controller
    {
        private readonly ISaleProductRepo _SaleProductrepo;
        private readonly IAddProductRepo _productrepo;
        private readonly ICustomerRepo _customerrepo;
        public saleProductController(ISaleProductRepo saleproductrepo, IAddProductRepo productrepo, ICustomerRepo customerrepo)
        {
            _SaleProductrepo = saleproductrepo;
            _productrepo = productrepo;
            _customerrepo = customerrepo;
        }
        public IActionResult Create()
        {

            List<AddProductATT> productList = _productrepo.List().ToList();
            List<PaymentMethodATT> paymentMethodList = _SaleProductrepo.PaymentMethodList().ToList();
            List<CustomerATT> customerList = _customerrepo.List().ToList();
            ViewBag.ProductList = new SelectList(productList, "Id", "Productname");
            ViewBag.PaymentMethodList = new SelectList(paymentMethodList, "Id", "Name");
            ViewBag.CustomerList = new SelectList(customerList, "Id", "CustomerName");

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



        [HttpPost]
        public string Save(SaleProductDTO data)
        {
          
            {
                _SaleProductrepo.save(data);
                AlertHelper.setMessage(this, "Product Succssfully Saved");
                return "Saved";

            }
            
        }

    }
}
