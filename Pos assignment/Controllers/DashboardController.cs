using infrastructurre.DTO;
using infrastructurre.Entities;
using infrastructurre.Repolayer.Inferface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Pos_assignment.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IAddProductRepo _ProdRepo;
        private readonly ISaleProductRepo _SalProdRepo;
        private readonly ICategoryRepo _CatRepo;
        private readonly ICustomerRepo _CusRepo;

        public DashboardController(IAddProductRepo ProdRepo, ISaleProductRepo SalProdRepo, ICategoryRepo CatRepo, ICustomerRepo CusRepo)
        {
            _CatRepo = CatRepo;
            _ProdRepo = ProdRepo;
            _SalProdRepo = SalProdRepo;
            _CusRepo = CusRepo;   
        }
        public IActionResult Index()
        {
            DashboardDTO att = new DashboardDTO();
            var sales = _SalProdRepo.List();
            decimal sum = 0;
            foreach (var item in sales) {
                sum = sum + item.total_amount + item.vat_amount;
            }
            att.TotalSalesAmount = sum.ToString();

            att.TotalCategories= _CatRepo.List().Count().ToString();   
            att.TotalProducts= _ProdRepo.List().Count().ToString();
            att.TotalSales= _SalProdRepo.List().Count().ToString();
            att.TotalCustomers= _CusRepo.List().Count().ToString();
            return View(att);
        }
    
    }
}
