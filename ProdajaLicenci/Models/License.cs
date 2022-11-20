namespace ProdajaLicenci.Models
{
    public class License : BaseModel
    {
        public string Key { get; set; }
        public int LicenseCategoryId { get; set; }
        public LicenseCategory LicenseCategory { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public float Price { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public ApplicationUser AddedBy { get; set; }
        public string Description { get; set; }
    }
}
