using Microsoft.AspNetCore.Identity;
using ProdajaLicenci.Data;
using ProdajaLicenci.Interfaces;
using ProdajaLicenci.Models;

namespace ProdajaLicenci.Services
{
    public enum Role {
        Admin,
        HR,
        Marketing,
        User
    }
    public class SeedService : ISeedService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SeedService(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedData()
        {
            string password = "Djole123!";
            if (await _roleManager.FindByNameAsync(Role.Admin.ToString()) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(Role.Admin.ToString()));
            }
            if (await _roleManager.FindByNameAsync(Role.User.ToString()) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(Role.User.ToString()));
            }
            if (await _roleManager.FindByNameAsync(Role.HR.ToString()) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(Role.HR.ToString()));
            }
            if (await _userManager.FindByNameAsync("Admin") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin123@gmail.com",
                    Email = "admin123@gmail.com",
                    FullName = "Admin",
                    Balance = 1000
                };
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Role.Admin.ToString());
                }
                await _db.SaveChangesAsync();
            }
            if (await _userManager.FindByNameAsync("DjoleHR") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "djolehr@gmail.com",
                    Email = "djolehr@gmail.com",
                    FullName = "Djole HR",
                    Balance = 1000
                };
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Role.HR.ToString());
                }
                await _db.SaveChangesAsync();
            }
            if (await _userManager.FindByNameAsync("DjoleMarketing") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "djolemarketing@gmail.com",
                    Email = "djolemarketing@gmail.com",
                    FullName = "DjoleMarketing",
                    Balance = 1000
                };
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Role.HR.ToString());
                }
                await _db.SaveChangesAsync();
            }
            if (await _userManager.FindByNameAsync("Obican User") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "djoleuser@gmail.com",
                    Email = "djoleuser@gmail.com",
                    FullName = "Obican User",
                    Balance = 650
                };
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Role.HR.ToString());
                }
                await _db.SaveChangesAsync();
            }
            if (!_db.Vendors.Any())
            {
                _db.Vendors.Add(new Vendor { CreatedAt = DateTime.Now, Name = "Microsoft" });
                _db.Vendors.Add(new Vendor { CreatedAt = DateTime.Now, Name = "Singidunum" });
                _db.Vendors.Add(new Vendor { CreatedAt = DateTime.Now, Name = "Steam" });
                _db.Vendors.Add(new Vendor { CreatedAt = DateTime.Now, Name = "Eset" });
                await _db.SaveChangesAsync();
            }
            if (!_db.LicenseCategories.Any())
            {
                _db.LicenseCategories.Add(new LicenseCategory { CreatedAt = DateTime.Now, Name = "Game" });
                _db.LicenseCategories.Add(new LicenseCategory { CreatedAt = DateTime.Now, Name = "Antivirus" });
                _db.LicenseCategories.Add(new LicenseCategory { CreatedAt = DateTime.Now, Name = "Subscription" });
                _db.LicenseCategories.Add(new LicenseCategory { CreatedAt = DateTime.Now, Name = "Key" });
                await _db.SaveChangesAsync();
            }
            if (!_db.Licenses.Any())
            {
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 1, Description = "Ovo je kljuc za igricu Minecraft.", VendorId = 3 });
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 2, Description = "Ovo je licenca za antivirus ESET NOD32.", VendorId = 2 });
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 3, Description = "Ovo je subskripcija za muziku.", VendorId = 2 });
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 3, Description = "Ovo je kljuc za windows.", VendorId = 1 });
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 1, Description = "Ovo je kljuc za igricu GTA.", VendorId = 3 });
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 2, Description = "Ovo je licenca za antivirus KASPERSKY.", VendorId = 4 });
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 3, Description = "Ovo je subskripcija za muziku.", VendorId = 2 });
                await _db.SaveChangesAsync();
            }
        }
    }
}
