namespace ProdajaLicenci.Dtos
{
    public class LicenseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Key { get; set; }
        public int LicenseCategoryId { get; set; }
        public LicenseCategoryDto LicenseCategory { get; set; }
        public int VendorId { get; set; }
        public VendorDto Vendor { get; set; }
        public float Price { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public ApplicationUserDto? AddedBy { get; set; }
        public string Description { get; set; }
        public ApplicationUserDto? BoughtBy { get; set; }
    }
}
