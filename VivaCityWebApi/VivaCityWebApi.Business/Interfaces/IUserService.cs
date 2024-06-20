using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;

namespace VivaCityWebApi.Common.Interfaces;


public interface IUserService
{
    Task<IEnumerable<UsersDto>> GetUsersAsync();
    Task<UsersDto?> GetUserById(int id);
    Task<UsersDto> CreateUserAsync(UserCreationRequest request);
    Task<IEnumerable<UsersDto>> SearchByName(string name);
    Task<Users> UpdateUserAsync(Users user);
    Task DeleteUserAsync(int pseudo);
}