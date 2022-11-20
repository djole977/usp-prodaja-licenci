namespace ProdajaLicenci.Dtos
{
    public class ApplicationUserDto
    {
        public ApplicationUserDto()
        {
            Licenses = new List<LicenseDto>();
        }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public float Balance { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public List<LicenseDto> Licenses { get; set; }
    }
}
