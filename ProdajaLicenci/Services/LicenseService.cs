using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProdajaLicenci.Data;
using ProdajaLicenci.Dtos;
using ProdajaLicenci.Interfaces;
using ProdajaLicenci.Models;

namespace ProdajaLicenci.Services
{
    public class LicenseService : ILicenseService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public LicenseService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<LicenseDto>> GetAllLicenses()
        {
            var dblicenses = await _db.Licenses.Include(license => license.Vendor).ToListAsync();
            var licenses = _mapper.Map <List<LicenseDto>>(dblicenses);
            foreach(var license in licenses)
            {
                var find = await _db.LicensePurchases.Where(license => license.License.Id == license.Id).Include(license => license.Buyer).FirstOrDefaultAsync();
                if(find != null)
                {
                    license.BoughtBy = _mapper.Map<ApplicationUserDto>(find.Buyer);
                }
            }
            return _mapper.Map<List<LicenseDto>>(licenses);
        }
        public async Task<List<LicenseDto>> GetNotPurchasedLicenses()
        {
            var dbLicenses = await _db.Licenses.Where(license => !_db.LicensePurchases.Select(p => p.License.Id).Contains(license.Id) && license.ValidTo > DateTime.Now).Include(l => l.Vendor).ToListAsync();
            var licenses = _mapper.Map<List<LicenseDto>>(dbLicenses);
            licenses.ForEach(license => license.Key = "");

            return licenses;
        }
        public async Task<List<LicensePurchaseDto>> GetAllLicensePurchases()
        {
            var licensePurchases = await _db.LicensePurchases.Include(license => license.License).Include(license => license.Buyer).ToListAsync();
            return _mapper.Map<List<LicensePurchaseDto>>(licensePurchases);
        }
        public async Task<List<LicenseCategoryDto>> GetAllCategories()
        {
            return await _db.LicenseCategories.Select(category => _mapper.Map<LicenseCategoryDto>(category)).ToListAsync();
        }
        public async Task AddLicense(LicenseDto license, string addedById)
        {
            license.CreatedAt = DateTime.Now;
            var addedBy = await _userManager.Users.Where(user => user.Id == addedById).FirstOrDefaultAsync();
            license.AddedBy = _mapper.Map<ApplicationUserDto>(addedBy);
            var a = _mapper.Map<License>(license);
            _db.Licenses.Add(_mapper.Map<License>(license));
            await _db.SaveChangesAsync();
        }
        public async Task PurchaseLicense(int licenseId, ApplicationUserDto user)
        {
            var license = await _db.Licenses.Where(license => license.Id == licenseId).FirstOrDefaultAsync();
            var findUser = await _db.Users.Where(u => u.Id == user.Id).FirstOrDefaultAsync();
            if(license == null || findUser == null)
            {
                throw new Exception();
            }
            LicensePurchase newPurchase = new LicensePurchase
            {
                LicenseId = licenseId,
                Buyer = findUser
            };
            _db.LicensePurchases.Add(newPurchase);
            findUser.Balance -= license.Price;

            await _db.SaveChangesAsync();
        }
        public async Task<List<LicenseDto>> GetUserLicenses(string userId)
        {
            var licenses = await _db.LicensePurchases.Where(lp => lp.Buyer.Id == userId).Include(lp => lp.License).ThenInclude(license => license.Vendor).Select(lp => lp.License).ToListAsync();
            
            return _mapper.Map<List<LicenseDto>>(licenses);
        }
        public async Task<LicenseDto> GetLicenseKey(string userId, int licenseId)
        {
            var license = await _db.LicensePurchases.Where(lp => lp.Buyer.Id == userId && lp.LicenseId == licenseId).Include(lp => lp.License).ThenInclude(license => license.Vendor).Select(lp => lp.License).FirstOrDefaultAsync();
            if(license == null)
            {
                throw new Exception("License not found!");
            }
            return _mapper.Map<LicenseDto>(license);
        }
    }
}
