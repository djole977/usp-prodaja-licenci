using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProdajaLicenci.Data;
using ProdajaLicenci.Dtos;
using ProdajaLicenci.Interfaces;
using ProdajaLicenci.Models;

namespace ProdajaLicenci.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _db = db;
        }

        public async Task<List<ApplicationUserDto>> GetAllUsers()
        {
            var dbusers = await _userManager.Users.ToListAsync();
            var userLicenses = await _db.LicensePurchases.Select(license => _mapper.Map<LicensePurchaseDto>(license)).ToListAsync();
            List<ApplicationUserDto> users = new List<ApplicationUserDto>();
            users = _mapper.Map<List<ApplicationUserDto>>(dbusers);
            foreach(var user in users)
            {
                user.Licenses = userLicenses.Where(license => license.Buyer.Id == user.Id).Select(lic => lic.License).ToList();
                var role = await _userManager.GetRolesAsync(dbusers.Where(u => u.Id == user.Id).FirstOrDefault());
                if(role.Count != 0)
                {
                    user.Role = role[0];
                }
                else
                {
                    user.Role = "NONE";
                }
            }

            return users;
        }
    }
}