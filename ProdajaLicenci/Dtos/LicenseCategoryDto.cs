namespace ProdajaLicenci.Dtos
{
    public class LicenseCategoryDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public List<LicenseSubcategoryDto> Subcategories { get; set; }
    }
}
