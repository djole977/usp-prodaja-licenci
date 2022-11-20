using ProdajaLicenci.Dtos;

namespace ProdajaLicenci.ViewModels
{
    public class LicensesVM
    {
        public LicensesVM()
        {
            Licenses = new List<LicenseDto>();
        }
        public List<LicenseDto> Licenses { get; set; }
    }
}
