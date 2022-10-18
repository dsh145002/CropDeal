﻿using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Dtos
{
    public class AddCropDto
    {
        [Required]
        public string CropType { get; set; } = null!;

        [Required]
        public string CropName { get; set; } = null!;

        [Required]
        public string CropLocation { get; set; } = null!;

        [Required]
        public int CropQtyAvailable { get; set; }

        [Required]
        public decimal CropExpectedPrice { get; set; } 
    }
}
