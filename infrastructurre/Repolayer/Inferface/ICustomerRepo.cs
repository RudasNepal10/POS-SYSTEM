using infrastructurre.DTO;
using infrastructurre.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructurre.Repolayer.Inferface
{
    public interface ICustomerRepo
    {
      void Save(CustomerDTO dto);
      List<CustomerATT> List();
      CustomerDTO GetCustomerDataForUpdate(long id);
      void UpdateCustomer(CustomerDTO dto); 
      void DeleteCustomer(long id);
    }
}
