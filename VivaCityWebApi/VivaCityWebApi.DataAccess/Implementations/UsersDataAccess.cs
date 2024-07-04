using Microsoft.EntityFrameworkCore;
using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.Requests;
using VivaCityWebApi.DataAccess.Interfaces;

namespace VivaCityWebApi.DataAccess.Implementations;

public class UsersDataAccess:IUserDataAccess
{
    private readonly GameContext _context;
    private VillageDataAccess _villageDataAccess;
    public UsersDataAccess(GameContext context) {
        this._context = context;
        this._villageDataAccess =  new VillageDataAccess(context);
    }
    public async Task<IEnumerable<UserDao>> GetUsersAsync() {
        return _context.Users;
    }

    public Task<UserDao?> GetUserById(int id) {
        return _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }
    public Task<UserDao?> SearchByName(string pseudo) {
        return _context.Users.FirstOrDefaultAsync(x => x.Pseudo.Equals(pseudo));
    }
    
    public async Task<UserDao> CreateUserAsync(UserCreationRequest request) {
        
        VillageDao v = await _villageDataAccess.Create(new VillageCreationRequest {
            Name = "Village1",
        });
  
  
        var newGame = _context.Users.Add(new UserDao() {
            Pseudo = request.Pseudo,
           Villages = new List<VillageDao> { v},
        });

        await _context.SaveChangesAsync();

        return await GetUserById(newGame.Entity.Id) ?? throw new NullReferenceException("Erreur lors de la creation du jeu");
    }
    
    
    
}