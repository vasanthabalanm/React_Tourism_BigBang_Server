using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MakeMyTrip.Models
{
    public class Specialty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? SpecialtyId { get; set; }

        [ForeignKey("Spot")]
        public int? SpotId { get; set; }

        public string? SpecialtyLocation { get; set; }

        public string? WhatSpecial { get; set; }
        public string? ImageName { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [NotMapped]
        public string? ImageSrc { get; set; }
    }
}
