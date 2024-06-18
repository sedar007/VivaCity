using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.DTO;

namespace VivaCityWebApi.Common.Interfaces;


public interface IUserService
{
    Task<IEnumerable<UsersDto>> GetUsersAsync();
    Task<Users> GetUserByIdAsync(int id);
    Task<Users> AddUserAsync(Users user);
    Task<Users> UpdateUserAsync(Users user);
    Task DeleteUserAsync(int pseudo);
}