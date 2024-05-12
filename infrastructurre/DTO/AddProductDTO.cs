using infrastructurre.Entities.Baseclass;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructurre.DTO
{
    public class AddProductDTO : BaseEntities
    {
        [Required(ErrorMessage = "Please enter your product")]
        public string Productname { get; set; }
        [Required(ErrorMessage = "Please enter price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please enter Quantity")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Please enter Description")]
        public string Description { get; set; }
        public IFormFile ImageFile { get; set; }
        public string FileName { get; set; }

        [Required]
        public long category_id { get; set; }
    }
}
