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
		//private VillageDataAccess _villageDataAccess;
		private readonly ILogger<RessourceDataAccess> _logger;
		public RessourceDataAccess(GameContext context) {
			this._context = context;
			this._ressourceItemsDataAccess =  new RessourceItemsDataAccess(context);
			//this._villageDataAccess = new VillageDataAccess(context);
		}
		
		
		public Task<RessourceDao?> GetById(int? id) {
			return _context.Ressources.FirstOrDefaultAsync(x => x.Id == id);
		}
		
		   
	   public async Task<RessourceDao> Create(RessourceCreationRequest request) {
		   if(request == null)
			   throw new InvalidDataException("Erreur inconnue");
		   if(request.RessourceItemId <= 0)
			   throw new InvalidDataException("Erreur: ressourceItemId ne peut pas etre <= 0");


		   RessourceItemDao? r = await _ressourceItemsDataAccess.GetRessourceItemById(request.RessourceItemId);
		   if(r == null)
			   throw new InvalidDataException("Erreur: ressourceItem inexistant");
			var newRessource = _context.Ressources.Add(new RessourceDao {
				   Nbr = request.Nbr,
				   Max = request.Max,
				   RessourceItem = r,
				   VillageId = request.VillageId,
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
