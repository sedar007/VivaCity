using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.Requests;
using VivaCityWebApi.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace VivaCityWebApi.DataAccess.Implementations {
	public class RessourceItemsDataAccess : IRessourcesItemsDataAccess {
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
		
		public async Task<RessourceItemDao> Create(RessourceItemCreationRequest request) {
			var newRessourceItem = _context.RessourceItem.Add(new RessourceItemDao {
				Name = request.Name,
				Picture = request.Picture,
			});

			await _context.SaveChangesAsync();

			return await GetRessourceItemById(newRessourceItem.Entity.Id) ?? throw new NullReferenceException("Erreur lors de la creation de la ressourceItem");
		}
		
		public Task SaveChanges() {
			return _context.SaveChangesAsync();
		}

	
	}
}
