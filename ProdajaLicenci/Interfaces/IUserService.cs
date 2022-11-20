using ProdajaLicenci.Dtos;

namespace ProdajaLicenci.Interfaces
{
    public interface IUserService
    {
        public Task<List<ApplicationUserDto>> GetAllUsers();
    }
}
