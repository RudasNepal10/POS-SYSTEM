using infrastructurre.Repolayer.Inferface;
using Microsoft.AspNetCore.Mvc;

namespace Pos_assignment.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISalesRepo _salesrepo;
        public SaleController(ISalesRepo salesrepo)
        {
         _salesrepo= salesrepo;
        }
        public IActionResult Create() 
        {
         return View(); 
        }
       

    }
}
