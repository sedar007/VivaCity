using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.Requests;
using VivaCityWebApi.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using VivaCityWebApi.Common.DTO;
using Microsoft.Extensions.Logging;

namespace VivaCityWebApi.DataAccess.Implementations {
	public class RessourceDataAccess : IRessourceDataAccess {
		private readonly GameContext _context;
		private RessourceItemsDataAccess _ressourceItemsDataAccess;
		private readonly ILogger<RessourceDataAccess> _logger;
		public RessourceDataAccess(GameContext context) {
			this._context = context;
			this._ressourceItemsDataAccess =  new RessourceItemsDataAccess(context);
		}
		
		
		public Task<RessourceDao?> GetById(int id) {
			return _context.Ressources.FirstOrDefaultAsync(x => x.Id == id);
		}
		
		   
	   public async Task<RessourceDao> Create(RessourceCreationRequest request) {
			   RessourceItemDao?  r = await _ressourceItemsDataAccess.GetRessourceItemById(request.RessourceId);
			   if(r == null) 
				   throw new InvalidDataException("Erreur: ressourceId n'existe pas");
			   
			   var newRessource = _context.Ressources.Add(new RessourceDao {
				   Nbr = request.Nbr,
				   Max = request.Max,
				   RessourceItemId = request.RessourceId,
				   RessourceItem = r,
			   });
			   
			   await _context.SaveChangesAsync();
			   return await GetById(newRessource.Entity.Id) ??
			          throw new NullReferenceException("Erreur lors de la creation du ressource");
	   }

		   public Task SaveChanges() {
		   	return _context.SaveChangesAsync();
		   }
	}
}
