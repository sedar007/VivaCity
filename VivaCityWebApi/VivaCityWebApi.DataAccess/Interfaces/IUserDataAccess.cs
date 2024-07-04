using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;

namespace VivaCityWebApi.DataAccess.Interfaces;

public interface IUserDataAccess
{
    Task<IEnumerable<UserDao>> GetUsersAsync();
    Task<UserDao?> GetUserById(int id);
    Task<IEnumerable<VillageDao?>> GetUserVillageByIdUser(int id);
    
    Task UpdateBatiment(UserUpdateBatimentRequest request);

    
    
    Task<UserDao> CreateUserAsync(UserCreationRequest request);
    
    Task AddVillage(UserAddVillageRequest request);
    Task<UserDao?> SearchByName(string pseudo);
    
    
}