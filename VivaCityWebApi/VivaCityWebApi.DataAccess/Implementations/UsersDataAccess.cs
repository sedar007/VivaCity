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
        return _context.Users
            .Include(x => x.Villages).ThenInclude((x) => x.Batiments)
                                                                .ThenInclude(x => x.Cout)
                                                                .ThenInclude(x => x.Ressource)
                                                                .ThenInclude(x => x.RessourceItem)
            .Include(x => x.Villages).ThenInclude((x) => x.Ressources)
                                                                .ThenInclude(x=>x.RessourceItem)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    public Task<UserDao?> SearchByName(string pseudo) {
        return _context.Users.Include(x => x.Villages).FirstOrDefaultAsync(x => x.Pseudo.Equals(pseudo));
    }
    
    public async Task<UserDao> CreateUserAsync(UserCreationRequest request) {
        
        VillageDao v = await _villageDataAccess.Create(new VillageCreationRequest {
            Name = "Calais",
        });
  
  
        var newGame = _context.Users.Add(new UserDao() {
            Pseudo = request.Pseudo,
           Villages = new List<VillageDao> { v},
        });

        await _context.SaveChangesAsync();

        return await GetUserById(newGame.Entity.Id) ?? throw new NullReferenceException("Erreur lors de la creation du village");
    }
    
    
    public async Task AddVillage(UserAddVillageRequest request) {
        VillageDao v = await _villageDataAccess.Create(new VillageCreationRequest {
            Name = request.VillageName,
        });
        
        var user = await GetUserById(request.IdUser);
        
        if(user == null)
            throw new NullReferenceException("Utilisateur non trouvé");

        user.Villages.Add(v);
       await UpdateRessources(new UserUpdateRessourcesRequest {
            IdUser = user.Id
        });
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task<UserDao> UpdateRessources(UserUpdateRessourcesRequest request) {
        UserDao? user = await GetUserById(request.IdUser);
        if(user == null)
            throw new NullReferenceException("Utilisateur non trouvé");
        await UpgradeRessource(user);
        return GetUserById(user.Id).Result ?? throw new NullReferenceException("Erreur lors de la mise à jour des batiments");

    }

    public async Task<UserDao?> UpdateBatiment(UserUpdateBatimentRequest request) {
        UserDao? user = await GetUserById(request.IdUser);
        if(user == null)
            throw new NullReferenceException("Utilisateur non trouvé");
        await UpgradeRessource(user); // Update ressource

        VillageDao? village = user.Villages.FirstOrDefault(v => v.Id == request.IdVillage);
        if(village == null)
            throw new NullReferenceException("Village non trouvé");
        
        var batiment = village.Batiments.FirstOrDefault(b => b.Id == request.IdBatiment);
       if(batiment == null)
            throw new NullReferenceException("Batiment non trouvé");
       
       UpgradeBatiment(village, batiment, user);
       
       
       _context.Users.Update(user);
       await _context.SaveChangesAsync();
       
       return GetUserById(user.Id).Result ?? throw new NullReferenceException("Erreur lors de la mise à jour des batiments");
 
    }
    
    
    private void UpgradeBatiment(VillageDao village, BatimentDao batiment, UserDao userDao) {
        foreach (RessourceDao ressource in village.Ressources)
            if (ressource.RessourceItem == batiment.Cout.Ressource.RessourceItem && batiment.Cout.Nbr <= ressource.Nbr)
            {
                userDao.Scores += batiment.Level * 10;
                ressource.Nbr -= batiment.Cout.Nbr;
                batiment.Level++;
                batiment.Cout.Nbr += Convert.ToInt32(Math.Round(batiment.Cout.Nbr * batiment.Level * 0.25));
                return;
            }
    }


    private async Task  UpgradeRessource(UserDao user) {
        if(user == null)
            throw new NullReferenceException("Utilisateur non trouvé");

        foreach (VillageDao village in user.Villages) {
            foreach (BatimentDao batiment in village.Batiments)
                UpdateB(batiment, village);
            village.UpdatedAt = DateTime.UtcNow;
        }
       _context.Users.Update(user); 
       await _context.SaveChangesAsync();
    }


    private void UpdateB(BatimentDao batiment, VillageDao village) {
        foreach ( RessourceDao ressourceDao in village.Ressources)
            if (ressourceDao.RessourceItem == batiment.Cout.Ressource.RessourceItem) {
                int ressourcenbr = ressourceDao.Nbr + Convert.ToInt32(Math.Round((DateTime.UtcNow - village.UpdatedAt).TotalSeconds * batiment.Level *
                    0.50)/100);
                ressourceDao.Nbr  = ressourcenbr < ressourceDao.Max ? ressourcenbr : ressourceDao.Max;
                return;
            }


    }
    
  
    
    
    public async Task<IEnumerable<VillageDao?>> GetUserVillageByIdUser(int id) {
        var user = await GetUserById(id);
        if(user == null)
            throw new NullReferenceException("Utilisateur non trouvé");
        
        return user.Villages;
        
    }

}