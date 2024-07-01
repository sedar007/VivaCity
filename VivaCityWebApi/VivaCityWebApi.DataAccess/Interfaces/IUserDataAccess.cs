using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.Requests;

namespace VivaCityWebApi.DataAccess.Interfaces;

public interface IUserDataAccess
{
    Task<IEnumerable<UserDao>> GetUsersAsync();
    Task<UserDao?> GetUserById(int id);
    Task<UserDao> CreateUserAsync(UserCreationRequest request);
    
    Task AddVillage(UserAddVillageRequest request);
    Task<UserDao?> SearchByName(string pseudo);
    
    
}