using infrastructurre.Entities.Baseclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructurre.Entities
{
    public class SalesATT : BaseEntities
    {
        public string Product { get; set; }
        public int quantity { get; set; }
    }
}
