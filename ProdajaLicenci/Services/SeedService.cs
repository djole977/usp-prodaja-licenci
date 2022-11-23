using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                    Balance = 5000
                };
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Role.User.ToString());
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
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 1, Description = "Ovo je kljuc za igricu Minecraft.", VendorId = 3, ValidFrom = new DateTime(2022, 8, 10), ValidTo = new DateTime(2023, 8, 10), Price = 130 });
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 2, Description = "Ovo je licenca za antivirus ESET NOD32.", VendorId = 2, ValidFrom = new DateTime(2021, 8, 10), ValidTo = new DateTime(2022, 8, 10), Price = 45 });
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 3, Description = "Ovo je subskripcija za muziku.", VendorId = 2, ValidFrom = new DateTime(2022, 10, 15), ValidTo = new DateTime(2023, 10, 15), Price = 32 });
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 3, Description = "Ovo je kljuc za windows.", VendorId = 1, ValidFrom = new DateTime(2020, 8, 10), ValidTo = new DateTime(2021, 8, 10), Price = 213 });
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 1, Description = "Ovo je kljuc za igricu GTA.", VendorId = 3, ValidFrom = new DateTime(2021, 8, 10), ValidTo = new DateTime(2022, 10, 10), Price = 320 });
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 2, Description = "Ovo je licenca za antivirus KASPERSKY.", VendorId = 4, ValidFrom = new DateTime(2022, 8, 10), ValidTo = new DateTime(2023, 8, 10), Price = 120 });
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 3, Description = "Ovo je subskripcija za muziku.", VendorId = 2, ValidFrom = new DateTime(2022, 8, 10), ValidTo = new DateTime(2023, 8, 10), Price = 150 });
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 1, Description = "Ovo je kljuc za igricu Minecraft.", VendorId = 3, ValidFrom = new DateTime(2022, 8, 10), ValidTo = new DateTime(2023, 8, 10), Price = 65 });
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 2, Description = "Ovo je licenca za antivirus ESET NOD32.", VendorId = 2, ValidFrom = new DateTime(2022, 8, 10), ValidTo = new DateTime(2023, 8, 10), Price = 60 });
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 3, Description = "Ovo je subskripcija za muziku.", VendorId = 2, ValidFrom = new DateTime(2022, 8, 10), ValidTo = new DateTime(2023, 8, 10), Price = 75 });
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 3, Description = "Ovo je kljuc za windows.", VendorId = 1, ValidFrom = new DateTime(2022, 8, 10), ValidTo = new DateTime(2023, 8, 10), Price = 111 });
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 1, Description = "Ovo je kljuc za igricu GTA.", VendorId = 3, ValidFrom = new DateTime(2022, 8, 10), ValidTo = new DateTime(2023, 8, 10), Price = 90 });
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 2, Description = "Ovo je licenca za antivirus KASPERSKY.", VendorId = 4, ValidFrom = new DateTime(2022, 8, 10), ValidTo = new DateTime(2023, 8, 10), Price = 89 });
                _db.Licenses.Add(new License { CreatedAt = DateTime.Now, Key = Guid.NewGuid().ToString(), LicenseCategoryId = 3, Description = "Ovo je subskripcija za muziku.", VendorId = 2, ValidFrom = new DateTime(2022, 8, 10), ValidTo = new DateTime(2023, 8, 10), Price = 99, AddedBy = await _userManager.FindByEmailAsync("djolehr@gmail.com") });

                await _db.SaveChangesAsync();

                _db.LicensePurchases.Add(new LicensePurchase
                {
                    Buyer = await _userManager.FindByEmailAsync("djoleuser@gmail.com"),
                    CreatedAt = new DateTime(2022, 2, 10),
                    License = await _db.Licenses.Where(l => l.Id == 1).FirstOrDefaultAsync()
                });
                _db.LicensePurchases.Add(new LicensePurchase
                {
                    Buyer = await _userManager.FindByEmailAsync("djoleuser@gmail.com"),
                    CreatedAt = new DateTime(2022, 3, 10),
                    License = await _db.Licenses.Where(l => l.Id == 2).FirstOrDefaultAsync()
                });
                _db.LicensePurchases.Add(new LicensePurchase
                {
                    Buyer = await _userManager.FindByEmailAsync("djoleuser@gmail.com"),
                    CreatedAt = new DateTime(2022, 4, 10),
                    License = await _db.Licenses.Where(l => l.Id == 3).FirstOrDefaultAsync()
                });
                _db.LicensePurchases.Add(new LicensePurchase
                {
                    Buyer = await _userManager.FindByEmailAsync("djoleuser@gmail.com"),
                    CreatedAt = new DateTime(2022, 5, 10),
                    License = await _db.Licenses.Where(l => l.Id == 4).FirstOrDefaultAsync()
                });
                _db.LicensePurchases.Add(new LicensePurchase
                {
                    Buyer = await _userManager.FindByEmailAsync("djoleuser@gmail.com"),
                    CreatedAt = new DateTime(2022, 6, 10),
                    License = await _db.Licenses.Where(l => l.Id == 5).FirstOrDefaultAsync()
                });
                _db.LicensePurchases.Add(new LicensePurchase
                {
                    Buyer = await _userManager.FindByEmailAsync("djoleuser@gmail.com"),
                    CreatedAt = new DateTime(2022, 2, 10),
                    License = await _db.Licenses.Where(l => l.Id == 6).FirstOrDefaultAsync()
                });
                _db.LicensePurchases.Add(new LicensePurchase
                {
                    Buyer = await _userManager.FindByEmailAsync("djoleuser@gmail.com"),
                    CreatedAt = new DateTime(2022, 7, 10),
                    License = await _db.Licenses.Where(l => l.Id == 7).FirstOrDefaultAsync()
                });
                _db.LicensePurchases.Add(new LicensePurchase
                {
                    Buyer = await _userManager.FindByEmailAsync("djoleuser@gmail.com"),
                    CreatedAt = new DateTime(2021, 4, 10),
                    License = await _db.Licenses.Where(l => l.Id == 8).FirstOrDefaultAsync()
                });
                _db.LicensePurchases.Add(new LicensePurchase
                {
                    Buyer = await _userManager.FindByEmailAsync("djoleuser@gmail.com"),
                    CreatedAt = new DateTime(2021, 8, 10),
                    License = await _db.Licenses.Where(l => l.Id == 9).FirstOrDefaultAsync()
                });

                await _db.SaveChangesAsync();
            }
        }
    }
}
