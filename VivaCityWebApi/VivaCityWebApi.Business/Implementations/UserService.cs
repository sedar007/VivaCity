using Microsoft.Extensions.Logging;
using VivaCityWebApi.Business.Interfaces;
using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Interfaces;
using VivaCityWebApi.Common.Requests;
using VivaCityWebApi.DataAccess.Interfaces;

namespace VivaCityWebApi.Business.Implementations;

public class UserService : IUserService
{
    private readonly IUserDataAccess userDataAccess;
    private readonly ILogger<UserService> _logger;
    private readonly IVillageService _villageService;

    public UserService(IUserDataAccess userDataAccess, ILogger<UserService> logger)
    {
        this.userDataAccess = userDataAccess;
        _logger = logger;
    }

    public async Task<IEnumerable<UsersDto>> GetUsersAsync()
    {
        try {
            return (await userDataAccess.GetUsersAsync())
                .Select(userDao => userDao.ToDto());
        } catch (Exception e) {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    public async Task<UsersDto?> GetUserById(int id)
    {
        try {
            return (await userDataAccess.GetUserById(id))?.ToDto();
        } catch (Exception e) {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
    
    public async Task<IEnumerable<VillageDto>> GetUserVillageByIdUser(int id)
    {
        try {
            return (await userDataAccess.GetUserVillageByIdUser(id))
                .Select(villageDao => villageDao.ToDto());
        } catch (Exception e) {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    public async Task<UsersDto?> UpdateBatiment(UserUpdateBatimentRequest request)
    {
        try {
            if (request == null) 
                throw new InvalidDataException("Erreur inconnue");
            if(request.IdBatiment <= 0)
                throw new InvalidDataException("IdBatiment peut pas être inférieur à 0");

            return (await userDataAccess.UpdateBatiment(request))?.ToDto();
        } catch (Exception e) {
            _logger.LogError(e, e.Message);
            throw;
        }   
    }

    public async  Task<UsersDto?> UpdateRessources(UserUpdateRessourcesRequest request)
    {
       
        
        try {
            if(request == null)
                throw new InvalidDataException("Erreur inconnue");
            return (await userDataAccess.UpdateRessources(request))?.ToDto();
        } catch (Exception e) {
            _logger.LogError(e, e.Message);
            throw;
        }   
        
    }
    
    private void CheckPseudo(string pseudo) {
        if (string.IsNullOrWhiteSpace(pseudo)) {
            throw new InvalidDataException("Erreur: Pseudo vide");
        }

        
    }

    private void CheckName(string name) {
        if (string.IsNullOrWhiteSpace(name)) {
            throw new InvalidDataException("Erreur: Nom vide");
        }
    }

    public async Task<UsersDto> CreateUserAsync(UserCreationRequest request)
    {
        try {
            if (request == null) {
                throw new InvalidDataException("Erreur inconnue");
            }
            
            CheckPseudo(request.Pseudo);

            return (await userDataAccess.CreateUserAsync(request)).ToDto();
        } catch (Exception e) {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
    

    public Task<UserDao> UpdateUserAsync(UserDao user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(int pseudo)
    {
        throw new NotImplementedException();
    }

    public async Task<UsersDto> SearchByName(string name)
    {
        try {
            return  (await userDataAccess.SearchByName(name))?.ToDto();
        } catch (Exception e) {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
    
    public async Task AddVillage(UserAddVillageRequest request)
    {
        try {
            if (request == null) 
                throw new InvalidDataException("Erreur inconnue");
            if(request.IdUser <= 0)
                throw new InvalidDataException("IdUser peut pas être inférieur à 0");
            
            if(request.VillageName == null)
                throw new InvalidDataException("VillageName ne peut pas être null");


            await userDataAccess.AddVillage(request);
        } catch (Exception e) {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    
}