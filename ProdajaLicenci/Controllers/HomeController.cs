using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProdajaLicenci.Dtos;
using ProdajaLicenci.Interfaces;
using ProdajaLicenci.Models;
using ProdajaLicenci.ViewModels;
using System.Diagnostics;

namespace ProdajaLicenci.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILicenseService _licenseService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ISeedService _seedService;

        public HomeController(ILogger<HomeController> logger, ILicenseService licenseService, UserManager<ApplicationUser> userManager, IMapper mapper, ISeedService seedService)
        {
            _logger = logger;
            _licenseService = licenseService;
            _userManager = userManager;
            _mapper = mapper;
            _seedService = seedService;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Licenses()
        {
            LicensesVM model = new LicensesVM();
            model.Licenses = await _licenseService.GetNotPurchasedLicenses();
            await _seedService.SeedData();

            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> PurchaseLicense(int licenseId)
        {
            var user = await _userManager.GetUserAsync(User);
            await _licenseService.PurchaseLicense(licenseId, _mapper.Map<ApplicationUserDto>(user));

            return Json(new { success = true });
        }
        [Authorize]
        public async Task<IActionResult> MyLicenses()
        {
            var user = await _userManager.GetUserAsync(User);
            LicensesVM model = new LicensesVM();
            model.Licenses = await _licenseService.GetUserLicenses(user.Id);

            return View(model);
        }
    }
}