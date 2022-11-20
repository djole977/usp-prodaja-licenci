namespace ProdajaLicenci.Dtos
{
    public class LicenseSubcategoryDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public LicenseCategoryDto Category { get; set; }
    }
}
