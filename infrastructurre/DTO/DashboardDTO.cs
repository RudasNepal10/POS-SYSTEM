using infrastructurre.Entities.Baseclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructurre.DTO
{
    public class DashboardDTO :BaseEntities
    {
        public string TotalSales { get; set; }
        public string TotalProducts { get; set; }
        public string TotalCategories { get; set; }
        public string TotalCustomers { get; set; }
        public string TotalSalesAmount { get; set; }
    }
}
