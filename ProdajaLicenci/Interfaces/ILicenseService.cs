using ProdajaLicenci.Dtos;

namespace ProdajaLicenci.Interfaces
{
    public interface ILicenseService
    {
        public Task<List<LicenseDto>> GetAllLicenses();
        public Task AddLicense(LicenseDto license, string addedById);
        public Task<List<LicenseCategoryDto>> GetAllCategories();
        public Task<List<LicensePurchaseDto>> GetAllLicensePurchases();
        public Task<List<LicenseDto>> GetNotPurchasedLicenses();
        public Task PurchaseLicense(int licenseId, ApplicationUserDto user);
        public Task<List<LicenseDto>> GetUserLicenses(string userId);
        public Task<LicenseDto> GetLicenseKey(string userId, int licenseId);
    }
}
