using infrastructurre.DTO;
using infrastructurre.Entities;
using infrastructurre.Repolayer.Inferface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pos_assignment.Helpers;

namespace Pos_assignment.Controllers
{
    [Authorize]
    public class SalesController : Controller
    {
        private readonly ISaleProductRepo _SaleProductrepo;
        private readonly IAddProductRepo _productrepo;
        private readonly ICustomerRepo _customerrepo;

        public SalesController(ISaleProductRepo saleproductrepo, IAddProductRepo productrepo, ICustomerRepo customerrepo)
        {
            _SaleProductrepo = saleproductrepo;
            _productrepo = productrepo;
            _customerrepo = customerrepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public List<AddProductATT> GetAllProduct() {
            var list =_productrepo.List();
            return list;
        }

        public List<CustomerATT> GetAllCustomer()
        {
            var list = _customerrepo.List();
            return list;
        }

        public List<PaymentMethodATT> GetAllPaymentMethod()
        {
            var list = _SaleProductrepo.PaymentMethodList();
            return list;
        }

        [HttpPost]
        public string SaveSales(SaleProductDTO data)
        {

            {
                _SaleProductrepo.save(data);
                AlertHelper.setMessage(this, "Product Succssfully Saved");
                return "Saved";

            }

        }

    }
}
