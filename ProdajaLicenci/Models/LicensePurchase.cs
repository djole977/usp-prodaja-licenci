namespace ProdajaLicenci.Models
{
    public class LicensePurchase : BaseModel
    {
        public int LicenseId { get; set; }
        public License License { get; set; }
        public ApplicationUser Buyer { get; set; }
    }
}
