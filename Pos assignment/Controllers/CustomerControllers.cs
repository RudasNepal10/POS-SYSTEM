using infrastructurre.DTO;
using infrastructurre.Repolayer.Implementation;
using infrastructurre.Repolayer.Inferface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pos_assignment.Helpers;

namespace Pos_assignment.Controllers
{
    public class CustomerControllers : Controller
    {
        private readonly ICustomerRepo _customerrepo;
        public CustomerControllers(ICustomerRepo customerRepo)
        {
         _customerrepo = customerRepo;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CustomerDTO dto) 
        {
            if (ModelState.IsValid)
            {
                _customerrepo.Save(dto);
                AlertHelper.setMessage(this, "customer Succssfully Saved");
                return RedirectToAction("List");

            }
            return View();

        }
        public IActionResult list()
        {
            var Customerlist = _customerrepo.List();
            return View(Customerlist);
        }
        public IActionResult Delete(long id) 
        {
         _customerrepo.DeleteCustomer(id);
         return RedirectToAction("list");
        
        }
        public IActionResult Update(long id)
        {
            try
            {
                var dto = _customerrepo.GetCustomerDataForUpdate(id);
                return View(dto);

            }
            catch (Exception ex) 
            { 
             return View();
            }
            
        }
        [HttpPost]
        public IActionResult Update(CustomerDTO dto)
        {
            if (ModelState.IsValid)
            {
                _customerrepo.UpdateCustomer(dto);
                return RedirectToAction("list");
            }
            return View(dto);
        }
    }
}
