using infrastructurre.Entities.Baseclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructurre.DTO
{
    public class SalesDTO : BaseEntities
    {
     public string Product {  get; set; }   
     public int quantity { get; set; }  

    }
}
