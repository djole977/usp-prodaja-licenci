using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProdajaLicenci.Interfaces;
using ProdajaLicenci.Models;
using ProdajaLicenci.ViewModels;

namespace ProdajaLicenci.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ILicenseService _licenseService;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(ILicenseService licenseService, UserManager<ApplicationUser> userManager)
        {
            _licenseService = licenseService;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetLicenseKey(int licenseId)
        {
            var user = await _userManager.GetUserAsync(User);
            var key = await _licenseService.GetLicenseKey(user.Id, licenseId);

            return Json(new { license = key });
        }
        public async Task<IActionResult> MyLicenses()
        {
            var user = await _userManager.GetUserAsync(User);
            LicensesVM model = new LicensesVM();
            model.Licenses = await _licenseService.GetUserLicenses(user.Id);

            return View(model);
        }
    }
}
