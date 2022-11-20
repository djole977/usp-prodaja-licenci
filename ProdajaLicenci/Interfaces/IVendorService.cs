using ProdajaLicenci.Dtos;

namespace ProdajaLicenci.Interfaces
{
    public interface IVendorService
    {
        public Task<List<VendorDto>> GetAllVendors();
    }
}
