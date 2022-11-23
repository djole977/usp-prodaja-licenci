using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdajaLicenci.Dtos;
using ProdajaLicenci.Interfaces;
using ProdajaLicenci.Models;
using ProdajaLicenci.ViewModels;

namespace ProdajaLicenci.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;
        private readonly ILicenseService _licenseService;
        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IUserService userService, ILicenseService licenseService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;
            _licenseService = licenseService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ManageAccounts()
        {
            ManageAccountsVM model = new ManageAccountsVM();
            model.Roles = await _roleManager.Roles.Select(role => role.Name).ToListAsync();
            model.Users = await _userService.GetAllUsers();

            return View(model);
        }
        public async Task<IActionResult> CreateRole(string roleName)
        {
            //var user = await _userManager.GetUserAsync(User);
            await _roleManager.CreateAsync(new IdentityRole(roleName));
            return Json(new { success = true });
        }
        public async Task<IActionResult> CreateUser(ApplicationUserDto user)
        {
            var userr = new ApplicationUser
            {
                UserName = user.Email,
                Email = user.Email,
                EmailConfirmed = true,
                FullName = user.FullName
            };
            var result = await _userManager.CreateAsync(userr, user.Password);
            await _userManager.AddToRoleAsync(userr, user.Role);

            return Json(new { success = true });
        }
        public async Task<IActionResult> ChartProfits()
        {
            return View();
        }
        public async Task<IActionResult> GetChartData(int year)
        {
            var licensePurchases = await _licenseService.GetAllLicensePurchases();
            float[] chartData = new float[12];
            for(int i = 0; i < 12; i++)
            {
                chartData[i] = licensePurchases.Where(lp => lp.CreatedAt.Month == i + 1).Sum(lp => lp.License.Price);
            }
            return Json(chartData);
        }
    }
}
