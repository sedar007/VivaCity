using Microsoft.Extensions.Logging;
using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Interfaces;
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

    public Task<Users> GetUserByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

public Task<Users> AddUserAsync(Users user)
{
    throw new NotImplementedException();
}

public Task<Users> UpdateUserAsync(Users user)
{
    throw new NotImplementedException();
}

public Task DeleteUserAsync(int pseudo)
{
    throw new NotImplementedException();
}
}