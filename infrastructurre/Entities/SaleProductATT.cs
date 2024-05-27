using infrastructurre.Entities.Baseclass;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace infrastructurre.Entities
{
    public class SaleProductATT : BaseEntities
    {
        public long customer_Id { get; set; }
        [ForeignKey(nameof(customer_Id))]
        public virtual CustomerATT Customer { get; set; }
        public long payment_method_id { get; set; }

        [ForeignKey(nameof(payment_method_id))]
        public virtual PaymentMethodATT PaymentMethod { get; set; }
        public decimal total_amount { get; set; }
        public decimal vat_amount { get; set; }
        public decimal due_amount { get; set; }
        public decimal return_amount { get; set; }
        public decimal paid_amount { get; set; }
        public string sales_date { get; set; } = DateTime.Now.ToString();
        public virtual List<SalesProduct> SalesProduct { get; set; } = new List<SalesProduct>();
    }


    public class SalesProduct
    {
        public decimal quantity { get; set; }
        public decimal total_prod_amount { get; set; }
        public long id { get; set; }
        public long product_id { get; set; }

        [ForeignKey(nameof(product_id))]
        public virtual AddProductATT ProductATT { get; set; }

        public long sales_id { get; set; }
        [ForeignKey(nameof(sales_id))]
        public virtual SaleProductATT Sales { get; set; }

    }
}
