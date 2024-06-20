using Microsoft.EntityFrameworkCore;
using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.Requests;
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

    public Task<UserDao?> GetUserById(int id) {
        return _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<UserDao> CreateUserAsync(UserCreationRequest request) {
        var newGame = _context.Users.Add(new UserDao() {
            Name = request.Name,
            Pseudo = request.Pseudo,
           
        });

        await _context.SaveChangesAsync();

        return await GetUserById(newGame.Entity.Id) ?? throw new NullReferenceException("Erreur lors de la creation du jeu");
    }
    
    public async Task<IEnumerable<UserDao>> SearchByName(string name) {
        return _context.Users.Where(x => x.Name.Contains(name));
    }
}