using Microsoft.AspNetCore.Mvc;
using ProdajaLicenci.Dtos;
using ProdajaLicenci.Interfaces;
using ProdajaLicenci.ViewModels;

namespace ProdajaLicenci.Controllers
{
    public class SalesAndMarketingController : Controller
    {
        private readonly IVendorService _vendorService;
        private readonly ILicenseService _licenseService;
        public SalesAndMarketingController(IVendorService vendorService, ILicenseService licenseService)
        {
            _vendorService = vendorService;
            _licenseService = licenseService;
        }
        public async Task<IActionResult> Index()
        {
            LicensesVM model = new LicensesVM();
            model.Licenses = await _licenseService.GetAllLicenses();
            model.LicenseCategories = await _licenseService.GetAllCategories();
            model.Vendors = await _vendorService.GetAllVendors();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewLicense(LicenseDto license)
        {
            await _licenseService.AddLicense(license);

            return Json(new { success = true });
        }
    }
}
