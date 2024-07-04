using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.Requests;
using VivaCityWebApi.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using VivaCityWebApi.Common.DTO;

namespace VivaCityWebApi.DataAccess.Implementations {
	public class BatimentDataAccess : IBatimentDataAccess {
		private readonly GameContext _context;
		private CoutDataAccess _coutDataAccess;
		private VillageDataAccess _villageDataAccess;
		private RessourceDataAccess _ressourceDataAccess;
		private RessourceItemsDataAccess _ressourceItemsDataAccess;
		public BatimentDataAccess(GameContext context) {
			this._context = context;
			this._coutDataAccess =  new CoutDataAccess(context);
			this._ressourceDataAccess = new RessourceDataAccess(context);
			this._ressourceItemsDataAccess = new RessourceItemsDataAccess(context);
		}

		public Task<BatimentDao?> GetBatimentById(int id) {
			return _context.Batiments.Include(x => x.Cout).Include(x => x.Village).FirstOrDefaultAsync(x => x.Id == id);
		}

		public Task<BatimentDao?> GetBatimentByType(int type) {
			return _context.Batiments.FirstOrDefaultAsync(x => x.Type == type);
		}
		
		public Task<BatimentDao?> GetBatimentByIdType(int id, int type) {
			return _context.Batiments.FirstOrDefaultAsync(x => x.Id == id && x.Type == type);
		}
		
		
		public CoutDao Cout { get; set; } = null!;
		public VillageDao Village { get; set; }
		public int? VillageId { get; set; }
		
		public async Task<BatimentDao> Create(BatimentCreationRequest request) {
			if(request == null)
				throw new InvalidDataException("Erreur inconnue");
			if (request.nbCout <= 0)
				throw new InvalidDataException("Erreur: nbr ne peut pas etre <= 0");
			
			RessourceDao? r = await _ressourceDataAccess.Create(new RessourceCreationRequest {
				Nbr = 0,
				Max = 100,
				RessourceItemId = request.Type,
			});
			
			CoutDao? c = await _coutDataAccess.Create(new CoutCreationRequest {
				Nbr = request.nbCout,
				RessourceId = r.Id,
			});
			
			if(c == null)
				throw new InvalidDataException("Erreur lors de la creation du cout");
				
			var newBatiment = _context.Batiments.Add(new BatimentDao {
				Name = request.Name,
				Level = 1,
				Type = request.Type,
				Cout = c,
				Picture = request.Picture,
				//Village = request.Village,
				//VillageId = Village.Id
			});

			await _context.SaveChangesAsync();

			return await GetBatimentById(newBatiment.Entity.Id) ?? throw new NullReferenceException("Erreur lors de la creation du batiment");
			
		}
		
		public async Task AddVillage(VillageDao village, BatimentDao batimentDao) {
			batimentDao.Village = village;
			await _context.SaveChangesAsync();

		}
	}
}
