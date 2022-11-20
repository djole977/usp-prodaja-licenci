using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProdajaLicenci.Models;

namespace ProdajaLicenci.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<License> Licenses { get; set; }
        public DbSet<LicenseCategory> LicenseCategories { get; set; }
        public DbSet<LicenseSubcategory> LicenseSubcategories { get; set; }
        public DbSet<LicensePurchase> LicensePurchases { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
    }
}