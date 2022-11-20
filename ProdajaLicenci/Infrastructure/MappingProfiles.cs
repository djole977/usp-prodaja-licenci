using AutoMapper;
using ProdajaLicenci.Dtos;
using ProdajaLicenci.Models;

namespace ProdajaLicenci.Infrastructure
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<License, LicenseDto>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
            CreateMap<LicenseCategory, LicenseCategoryDto>().ReverseMap();
            CreateMap<LicenseSubcategory, LicenseSubcategoryDto>().ReverseMap();
            CreateMap<LicensePurchase, LicensePurchaseDto>().ReverseMap();
            CreateMap<Vendor, VendorDto>().ReverseMap();
        }
    }
}
