using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeMyTrip.Models
{
    public class Admin_User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public string? Role { get; set; }
        public long? Phone { get; set; }
        public string? AgencyName { get; set; }
        public string? AgencyDescription { get; set; }
        public string? Aadharnumber { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        public ICollection<AdminImageGallery>? AdminImages { get; set; } = new List<AdminImageGallery>();

        public ICollection<PackageOffering>? Packages { get; set; } = new List<PackageOffering>();
        public ICollection<Book>? Books { get; set; } = new List<Book>();



    }
}
