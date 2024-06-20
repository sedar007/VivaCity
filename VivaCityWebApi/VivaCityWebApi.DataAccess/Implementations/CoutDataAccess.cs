using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.Requests;
using VivaCityWebApi.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace VivaCityWebApi.DataAccess.Implementations {
	public class CoutDataAccess : ICoutDataAccess {
		private readonly GameContext _context;
		private RessourceDataAccess _ressourceDataAccess;
		public CoutDataAccess(GameContext context) {
			this._context = context;
			this._ressourceDataAccess =  new RessourceDataAccess(context);
		}
		
		public Task<CoutDao?> GetCoutById(int id) {
			return _context.Couts.FirstOrDefaultAsync(x => x.Id == id);
		}
		
		public async Task<CoutDao> Create(CoutCreationRequest request) {
			
			RessourceDao?  r = await _ressourceDataAccess.GetById(request.RessourceId);
			if(r == null) 
				throw new InvalidDataException("Erreur: ressourceId n'existe pas");
			
			var newCout = _context.Couts.Add(new CoutDao {
				Nbr = request.Nbr,
				RessourceId = request.RessourceId,
				Ressource = r,
			});
			
			await _context.SaveChangesAsync();
			return await GetCoutById(newCout.Entity.Id) ?? throw new NullReferenceException("Erreur lors de la creation du cout");
		}

		public Task SaveChanges() {
			return _context.SaveChangesAsync();
		}
		
	}
}
