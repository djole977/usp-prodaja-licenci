using ProdajaLicenci.Dtos;

namespace ProdajaLicenci.ViewModels
{
    public class ManageAccountsVM
    {
        public ManageAccountsVM()
        {
            Users = new List<ApplicationUserDto>();
        }
        public List<ApplicationUserDto> Users { get; set; }
    }
}
