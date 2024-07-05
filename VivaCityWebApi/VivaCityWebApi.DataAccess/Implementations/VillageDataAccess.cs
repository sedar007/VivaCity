using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.Requests;
using VivaCityWebApi.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace VivaCityWebApi.DataAccess.Implementations {
	public class VillageDataAccess : IVillageDataAccess {
		private readonly GameContext _context;
		private RessourceDataAccess _ressourceDataAccess;
		private BatimentDataAccess _batimentDataAccess;
		public VillageDataAccess(GameContext context) {
			this._context = context;
			this._ressourceDataAccess =  new RessourceDataAccess(context);
			this._batimentDataAccess = new BatimentDataAccess(context);
		}
		
		public Task<VillageDao?> GetVillageById(int? id) {
			return _context.Villages.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
		}
		
		public async Task<VillageDao> Create(VillageCreationRequest request) {
			
			BatimentDao b1 = await _batimentDataAccess.Create(new BatimentCreationRequest {
					Name = "Coinfort",
					Type = 1,
					Picture = "coin",
					nbCout = 70,
			});
			
			BatimentDao b2 = await _batimentDataAccess.Create(new BatimentCreationRequest {
				Name = "Sylvabastion",
				Type = 2,
				Picture = "wood",
				nbCout = 30,
			});
			
			BatimentDao b3 = await _batimentDataAccess.Create(new BatimentCreationRequest {
				Name = "Rocfort",
				Type = 3,
				Picture = "stone",
				nbCout = 35,
			});
			
			RessourceDao r = await _ressourceDataAccess.Create(new RessourceCreationRequest {
				Nbr = 1000,
				Max = 1000,
				RessourceItemId = 2,
			});
			
			RessourceDao r2 = await _ressourceDataAccess.Create(new RessourceCreationRequest {
				Nbr = 1500,
				Max = 1500,
				RessourceItemId = 1,
			});
			
			RessourceDao r3 = await _ressourceDataAccess.Create(new RessourceCreationRequest {
				Nbr = 2000,
				Max = 2000,
				RessourceItemId = 3,
			});
			
			var newVillage = _context.Villages.Add(new VillageDao {
				Name = request.Name,
				Level = 1,
				Batiments = new List<BatimentDao> { b1, b2, b3},
				Ressources = new List<RessourceDao>{r, r2, r3},
				UpdatedAt = DateTime.UtcNow
			});
			
			//await _batimentDataAccess.AddVillage(newVillage.Entity, b1);
			await _context.SaveChangesAsync();
			return await GetVillageById(newVillage.Entity.Id) ?? throw new NullReferenceException("Erreur lors de la creation du village");
			
		}

		public Task SaveChanges() {
			return _context.SaveChangesAsync();
		}
		
	}
}
