using Microsoft.AspNetCore.Identity;

namespace ProdajaLicenci.Models
{
    public class ApplicationUser : IdentityUser
    {
        public float Balance { get; set; }
        public string FullName { get; set; }
        public List<LicensePurchase> LicensePurchases { get; set; }
    }
}
