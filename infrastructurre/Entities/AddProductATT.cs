using infrastructurre.Entities.Baseclass;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructurre.Entities
{
    public class AddProductATT : BaseEntities
    {
        [Required]
        public string Productname { get; set; }
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }

        public string Description { get; set; }

        public string ImageFile { get; set; }

        public long category_id { get; set; }

        [ForeignKey(nameof(category_id))]
        public virtual CategoryATT Category { get; set; }

    }
}
