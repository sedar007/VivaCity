using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;

namespace VivaCityWebApi.Common.Interfaces;


public interface IUserService
{
    Task<IEnumerable<UsersDto>> GetUsersAsync();
    Task<UsersDto?> GetUserById(int id);
    Task<IEnumerable<VillageDto>> GetUserVillageByIdUser(int id);
   
    Task<UsersDto> CreateUserAsync(UserCreationRequest request);
    Task AddVillage(UserAddVillageRequest request);
    
    Task<UsersDto> SearchByName(string name);
    Task<UserDao> UpdateUserAsync(UserDao user);
    Task DeleteUserAsync(int pseudo);
    
    
}