using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<List<ApplicationUserDto>> GetAllUsers()
        {
            var dbusers = await _userManager.Users.ToListAsync();
            List<ApplicationUserDto> users = new List<ApplicationUserDto>();
            users = _mapper.Map<List<ApplicationUserDto>>(dbusers);
            foreach(var user in users)
            {
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