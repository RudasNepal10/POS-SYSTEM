using infrastructurre.Entities;
using infrastructurre.Entities.Baseclass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructurre.DTO
{
    public class SaleProductDTO : BaseEntities
    {
        public long customer_Id { get; set; }
        public long payment_method_id { get; set; }
        public decimal total_amount { get; set; }
        public decimal due_amount { get; set; }
        public decimal return_amount { get; set; }
        public decimal vat_amount { get; set; }

        public decimal paid_amount {  get; set; }    

        public List<SalesProductDTO> SalesProduct { get; set; } = new List<SalesProductDTO>();

    }

    public class SalesProductDTO
    {
        public decimal quantity { get; set; }
        public long id { get; set; }
        public long product_id { get; set; }
        public decimal total_prod_amount { get; set; } 
       
    }
}
