using ProdajaLicenci.Dtos;

namespace ProdajaLicenci.Interfaces
{
    public interface ILicenseService
    {
        public Task<List<LicenseDto>> GetAllLicenses();
        public Task AddLicense(LicenseDto license);
        public Task<List<LicenseCategoryDto>> GetAllCategories();
    }
}
