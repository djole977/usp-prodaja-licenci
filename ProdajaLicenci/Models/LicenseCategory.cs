namespace ProdajaLicenci.Models
{
    public class LicenseCategory : BaseModel
    {
        public string Name { get; set; }
        public List<LicenseSubcategory> Subcategories { get; set; }
    }
}
