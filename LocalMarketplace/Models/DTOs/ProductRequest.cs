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

        [Required(ErrorMessage = "Nazwa ogłoszenia jest wymanana")]
        [Display(Name ="Tytuł")]
        public string Title { get; set; }

        [Display(Name = "Kategoria")]
        public string Category { get; set; }

        [Display(Name = "Czas pracy")]
        public string WorkLength { get; set; }

        [Display(Name = "Typ pracy")]
        public string WorkType { get; set; }

        [Display(Name = "Płaca")]
        public string Payment { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Dane kontaktowe są wymagane")]
        [Display(Name = "Dane kontaktowe")]
        public string Contact { get; set; }

        public IList<Picture> Pictures { get; set; }
    }
}
