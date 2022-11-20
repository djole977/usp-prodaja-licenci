namespace ProdajaLicenci.Dtos
{
    public class LicensePurchaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int LicenseId { get; set; }
        public LicenseDto License { get; set; }
        public ApplicationUserDto Buyer { get; set; }
    }
}
