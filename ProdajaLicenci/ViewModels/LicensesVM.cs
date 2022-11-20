using ProdajaLicenci.Dtos;

namespace ProdajaLicenci.ViewModels
{
    public class LicensesVM
    {
        public LicensesVM()
        {
            Licenses = new List<LicenseDto>();
            Vendors = new List<VendorDto>();
            LicenseCategories = new List<LicenseCategoryDto>();
            LicenseSubcategories = new List<LicenseSubcategoryDto>();
        }
        public List<LicenseDto> Licenses { get; set; }
        public List<VendorDto> Vendors { get; set; }
        public List<LicenseCategoryDto> LicenseCategories { get; set; }
        public List<LicenseSubcategoryDto> LicenseSubcategories { get; set; }
    }
}
