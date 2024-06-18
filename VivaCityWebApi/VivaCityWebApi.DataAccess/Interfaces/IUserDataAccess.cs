using VivaCityWebApi.Common.DAO;

namespace VivaCityWebApi.DataAccess.Interfaces;

public interface IUserDataAccess
{
    Task<IEnumerable<UserDao>> GetUsersAsync();
}