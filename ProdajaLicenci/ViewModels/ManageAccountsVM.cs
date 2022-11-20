using ProdajaLicenci.Dtos;

namespace ProdajaLicenci.ViewModels
{
    public class ManageAccountsVM
    {
        public ManageAccountsVM()
        {
            Users = new List<ApplicationUserDto>();
            Roles = new List<string>();
        }
        public List<ApplicationUserDto> Users { get; set; }
        public List<string> Roles { get; set; }
    }
}
