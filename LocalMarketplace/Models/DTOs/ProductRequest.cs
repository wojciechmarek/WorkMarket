using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMarketplace.Models.DTOs
{
    public class ProductRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Product name is required")]
        public string Name { get; set; }

        public string Description { get; set; }
        public IList<Picture> Pictures { get; set; }
    }
}
