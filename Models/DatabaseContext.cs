using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Rating> Ratings { get; set; } = null!;
         public DbSet<CropType> CropTypes { get;set;}= null!;
        public DbSet<CropDetail>  CropDetails { get;set;}= null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=.\sqlexpress;database=model;integrated security=SSPI");
            base.OnConfiguring(optionsBuilder);
        } 
    }
}
