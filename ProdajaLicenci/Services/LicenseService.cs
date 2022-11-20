using AutoMapper;
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
        public LicenseService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<LicenseDto>> GetAllLicenses()
        {
            return await _db.Licenses.Select(license => _mapper.Map<LicenseDto>(license)).ToListAsync();
        }
        public async Task<List<LicenseCategoryDto>> GetAllCategories()
        {
            return await _db.LicenseCategories.Select(category => _mapper.Map<LicenseCategoryDto>(category)).ToListAsync();
        }
        public async Task AddLicense(LicenseDto license)
        {
            license.CreatedAt = DateTime.Now;
            var a = _mapper.Map<License>(license);
            _db.Licenses.Add(_mapper.Map<License>(license));
            await _db.SaveChangesAsync();
        }
    }
}
