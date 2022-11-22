using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProdajaLicenci.Dtos;
using ProdajaLicenci.Interfaces;
using ProdajaLicenci.Models;
using ProdajaLicenci.ViewModels;

namespace ProdajaLicenci.Controllers
{
    public class SalesAndMarketingController : Controller
    {
        private readonly IVendorService _vendorService;
        private readonly ILicenseService _licenseService;
        private readonly UserManager<ApplicationUser> _userManager;
        public SalesAndMarketingController(IVendorService vendorService, ILicenseService licenseService, UserManager<ApplicationUser> userManager)
        {
            _vendorService = vendorService;
            _licenseService = licenseService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            LicensesVM model = new LicensesVM();
            model.Licenses = await _licenseService.GetAllLicenses();
            var purchases = await _licenseService.GetAllLicensePurchases();
            foreach(var purchase in purchases)
            {
                var license = model.Licenses.Where(license => license.Id == purchase.LicenseId).FirstOrDefault();
                if(license != null)
                {
                    license.BoughtBy = purchase.Buyer;
                }
            }
            model.LicenseCategories = await _licenseService.GetAllCategories();
            model.Vendors = await _vendorService.GetAllVendors();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewLicense(LicenseDto license)
        {
            var user = await _userManager.GetUserAsync(User);
            await _licenseService.AddLicense(license, user.Id);

            return Json(new { success = true });
        }
    }
}
