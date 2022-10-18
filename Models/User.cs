using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Phone { get; set; }
        public string? Status { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public Account Account { get; set; }
        public Address Address { get; set; }
        public Rating Rating { get; set; }
          public IEnumerable<CropDetail> CropDetails { get; set; }  = null!;
}
}
