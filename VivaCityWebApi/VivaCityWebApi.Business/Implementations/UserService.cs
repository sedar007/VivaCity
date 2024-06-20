using Microsoft.Extensions.Logging;
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

            // TODO: check name duplications

            if (string.IsNullOrWhiteSpace(request.Name)) {
                throw new InvalidDataException("Erreur: Nom vide");
            }

            CheckName(request.Name);
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

    public async Task<IEnumerable<UsersDto>> SearchByName(string name)
    {
        try {
            return (await userDataAccess.SearchByName(name))
                .Select(gameDao => gameDao.ToDto());
        } catch (Exception e) {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}