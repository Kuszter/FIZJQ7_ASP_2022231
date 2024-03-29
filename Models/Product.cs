﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIZJQ7_ASP_2022231.Models
{
    public class Product
    {
        public long Id { get; set; }
        [Required(ErrorMessage ="Kerem adjon meg nevet!")]
        public string Name { get; set; }
        public string Slug { get; set; }
        [Required (ErrorMessage ="Adjon meg leírást!")]
        public string Description { get; set; }
        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage ="Adjon meg árat!")]
        [Column(TypeName ="decimal(8,2)")]
        public int Price { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Adjon meg kategóriát!")]
        public long CategoryId { get; set; }
       
       
        public Category Category { get; set; }
        public string Image { get; set; } = "noimage.png";

        [NotMapped]
        [FileExtensions]
        public IFormFile ImageUpload { get; set; }


    }
}
