﻿using System.ComponentModel.DataAnnotations;

namespace WEB_API_1_Paskaita.Attributes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                
                if (file.Length>_maxFileSize)
                {
                    return new ValidationResult($"The file exceeds the maximum size of {_maxFileSize} bytes.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
