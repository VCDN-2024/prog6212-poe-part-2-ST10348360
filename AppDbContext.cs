/*Code Attribution
 https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-8.0
Author: Microsoft*/

using Microsoft.EntityFrameworkCore;

namespace CMS
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Claim> Claims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Claim>()
                .Property(c => c.HourlyRate)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Claim>()
                .Property(c => c.HoursWorked)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Claim>()
                .Property(c => c.TotalAmount)
                .HasColumnType("decimal(18,2)");
        }
    }


public class Claim
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string DocumentPath { get; set; }
        public string Status { get; set; }
        public string AdditionalNotes { get; set; }
        public decimal HourlyRate { get; set; } 
        public decimal HoursWorked { get; set; } 
        public decimal TotalAmount { get; set; } 
        public DateTime ClaimDate { get; set; } 
    }
}
