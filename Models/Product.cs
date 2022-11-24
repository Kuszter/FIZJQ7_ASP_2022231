using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIZJQ7_ASP_2022231.Models
{
    public class Product
    {
        public long Id { get; set; }
        [Required(ErrorMessage ="Kérem adjon meg nevet!")]
        public string Name { get; set; }
        public string Slug { get; set; }
        [Required (ErrorMessage ="Adjon meg leírást!")]
        public string Description { get; set; }
        [Column]
        public int Price { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public string Image { get; set; }


    }
}
