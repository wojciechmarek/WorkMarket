using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMarketplace.Models.DTOs
{
    public class ProductAdd
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }
}
