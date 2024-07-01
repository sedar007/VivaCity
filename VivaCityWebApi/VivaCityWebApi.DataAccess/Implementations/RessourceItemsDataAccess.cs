using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.Requests;
using VivaCityWebApi.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace VivaCityWebApi.DataAccess.Implementations {
    public class RessourceItemsDataAccess : IRessourceItemsDataAccess {
        private readonly GameContext _context;
        public RessourceItemsDataAccess(GameContext context) {
            this._context = context;
        }

        public async Task<IEnumerable<RessourceItemDao>> GetRessourceItems() {
            return _context.RessourceItem;
        }

        public Task<RessourceItemDao?> GetRessourceItemById(int id) {
            return _context.RessourceItem.FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public Task<RessourceItemDao?> GetRessourceItemById(int? id) {
            return _context.RessourceItem.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<RessourceItemDao>> SearchByName(string name) {
            return _context.RessourceItem.Where(x => x.Name.Contains(name));
        }

        public async Task<RessourceItemDao> Create(RessourceItemCreationRequest request) {
            var newRessourceItem = _context.RessourceItem.Add(new RessourceItemDao {
                Name = request.Name,
                Picture = request.Picture,
            });

            await _context.SaveChangesAsync();

            return await GetRessourceItemById(newRessourceItem.Entity.Id) ?? throw new NullReferenceException("Erreur lors de la creation du RessourceItem");
        }

        public Task SaveChanges() {
            return _context.SaveChangesAsync();
        }

        public async Task Remove(int id) {
            var ressourceItem = await GetRessourceItemById(id);
            _context.RessourceItem.Remove(ressourceItem);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> isExist(string name) {
            return (await SearchByName(name)).Any();
        }

    }
}