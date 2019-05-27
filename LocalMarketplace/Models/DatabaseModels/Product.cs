using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMarketplace.Models.DatabaseModels
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string WorkLength { get; set; }
        public string WorkType { get; set; }
        public string Payment { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string UserId { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }
}
