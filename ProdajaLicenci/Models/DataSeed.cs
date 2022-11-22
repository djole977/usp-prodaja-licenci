using Microsoft.AspNetCore.Identity;
using ProdajaLicenci.Data;

namespace ProdajaLicenci.Models
{
    public enum Role
    {
        Admin,
        HR,
        Marketing,
        User
    }
    public class DataSeed
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();
            string AdminId = "";
            string password = "Admin123!";
            if (await roleManager.FindByNameAsync(Role.Admin.ToString()) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(Role.Admin.ToString()));
            }
            if (await roleManager.FindByNameAsync(Role.User.ToString()) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(Role.User.ToString()));
            }
            if (await roleManager.FindByNameAsync(Role.HR.ToString()) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(Role.HR.ToString()));
            }
            if (await userManager.FindByNameAsync("Admin123") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin123@gmail.com",
                    Email = "admin123@gmail.com",
                    FullName = "Admin"
                };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Role.Admin.ToString());
                }
                AdminId = user.Id;
                await context.SaveChangesAsync();
            }
            if (!context.Vendors.Any())
            {
                context.Vendors.Add(new Vendor { CreatedAt = DateTime.Now, Name = "Microsoft" });
                context.Vendors.Add(new Vendor { CreatedAt = DateTime.Now, Name = "Singidunum" });
                context.Vendors.Add(new Vendor { CreatedAt = DateTime.Now, Name = "Steam" });
                context.Vendors.Add(new Vendor { CreatedAt = DateTime.Now, Name = "Eset" });
                await context.SaveChangesAsync();
            }
            if (!context.LicenseCategories.Any())
            {
                context.LicenseCategories.Add(new LicenseCategory { CreatedAt = DateTime.Now, Name = "Game" });
                context.LicenseCategories.Add(new LicenseCategory { CreatedAt = DateTime.Now, Name = "Antivirus" });
                context.LicenseCategories.Add(new LicenseCategory { CreatedAt = DateTime.Now, Name = "Subscription" });
                context.LicenseCategories.Add(new LicenseCategory { CreatedAt = DateTime.Now, Name = "Key" });
                await context.SaveChangesAsync();
            }
            if (!context.Licenses.Any())
            {
                context.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 1, Description = "Ovo je kljuc za igricu Minecraft.", VendorId = 3});
                context.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 2, Description = "Ovo je licenca za antivirus ESET NOD32.", VendorId = 2 });
                context.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 3, Description = "Ovo je subskripcija za muziku.", VendorId = 2 });
                context.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 3, Description = "Ovo je kljuc za windows.", VendorId = 1 });
                context.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 1, Description = "Ovo je kljuc za igricu GTA.", VendorId = 3 });
                context.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 2, Description = "Ovo je licenca za antivirus KASPERSKY.", VendorId = 4 });
                context.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 3, Description = "Ovo je subskripcija za muziku.", VendorId = 2 });
                await context.SaveChangesAsync();
            }
        }
    }
}
