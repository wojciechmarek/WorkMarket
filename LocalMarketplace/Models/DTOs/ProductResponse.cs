using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMarketplace.Models.DTOs
{
    public class ProductResponse
    {
        public int Id { get; set; }

        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        public string Category { get; set; }
        public string WorkLength { get; set; }
        public string WorkType { get; set; }
        public string Payment { get; set; }

        [Display(Name = "Opis ogłoszenia")]
        public string Description { get; set; }
        public string Contact { get; set; }

        public IList<Picture> Pictures { get; set; }
    }
}
