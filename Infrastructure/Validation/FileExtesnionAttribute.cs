﻿using System.ComponentModel.DataAnnotations;

namespace FIZJQ7_ASP_2022231.Infrastructure.Validation
{
    public class FileExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);

                string[] extensions = { "jpg", "png" };
                bool result = extensions.Any(x => extension.EndsWith(x));

                if (!result)
                {
                    return new ValidationResult("A kiterjesztés : .jpg .png lehet!");
                }
            }

            return ValidationResult.Success;
        }
    }
}