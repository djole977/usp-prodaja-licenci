namespace ProdajaLicenci.Models
{
    public class LicenseSubcategory : BaseModel
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public LicenseCategory Category { get; set; }
    }
}
