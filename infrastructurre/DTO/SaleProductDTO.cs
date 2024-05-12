using infrastructurre.Entities.Baseclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructurre.DTO
{
    public class SaleProductDTO : BaseEntities
    {
        public DateTime SaleDate {  get; set; } 
        public string ProductName{ get; set; } 
        public int Quantity { get; set; }
        public decimal TotalAmount {  get; set; }   

    }
}
