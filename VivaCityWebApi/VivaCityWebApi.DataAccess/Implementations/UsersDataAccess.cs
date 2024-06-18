using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.DataAccess.Interfaces;

namespace VivaCityWebApi.DataAccess.Implementations;

public class UsersDataAccess:IUserDataAccess
{
    private readonly GameContext _context;
    public UsersDataAccess(GameContext context) {
        this._context = context;
    }
    public async Task<IEnumerable<UserDao>> GetUsersAsync() {
        return _context.Users;
    }
}