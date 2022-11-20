using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProdajaLicenci.Data;
using ProdajaLicenci.Dtos;
using ProdajaLicenci.Interfaces;

namespace ProdajaLicenci.Services
{
    public class VendorService : IVendorService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public VendorService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<List<VendorDto>> GetAllVendors()
        {
            return await _db.Vendors.Select(vendor => _mapper.Map<VendorDto>(vendor)).ToListAsync();
        }
    }
}
