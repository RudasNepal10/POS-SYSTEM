using infrastructurre.Entities.Baseclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructurre.DTO
{
    public class CustomerDTO:BaseEntities
    { 
     public string CustomerName { get; set; }
     public string CustomerEmail { get; set; }
     public string CustomerPhone { get; set; }
     public string Address { get; set; }
     
    }
}
