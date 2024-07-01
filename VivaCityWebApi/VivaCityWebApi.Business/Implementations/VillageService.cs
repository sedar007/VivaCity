using VivaCityWebApi.Business.Interfaces;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;
using VivaCityWebApi.DataAccess.Interfaces;
using Microsoft.Extensions.Logging;
using VivaCityWebApi.Common.DAO;

namespace VivaCityWebApi.Business.Implementations {
	public class VillageService : IVillageService {
		private readonly IVillageDataAccess _villageDataAccess;
		private readonly ILogger<VillageService> _logger;
		public VillageService(ILogger<VillageService> logger, IVillageDataAccess villageDataAccess) {
			_logger = logger;
			_villageDataAccess = villageDataAccess;
		}
		
		public async Task<VillageDto?> GetvillageById(int id)
		{
			throw new NotImplementedException();
			/*	try {
					return (await _villageDataAccess.GetvillageById(id))?.ToDto();
				} catch (Exception e) {
					_logger.LogError(e, e.Message);
					throw;
				}*/
		}
		
		public async Task<VillageDto> Create(VillageCreationRequest request) {
			try {
				if (request == null)
					throw new InvalidDataException("Erreur inconnue");
				
				if(request.Name == null)
					throw new InvalidDataException("Erreur: Nom du village manquant!");
				if(request.Name.Length < 3)
					throw new InvalidDataException("Erreur: Nom du village trop court!");
				
				return (await _villageDataAccess.Create(request)).ToDto();
			} catch (Exception e) {
				_logger.LogError(e, e.Message);
				throw;
			}
		}

		/*public async Task Update(villageUpdateRequest villageUpdateRequest) {
			try {
				var village = await _villageDataAccess.GetvillageById(villageUpdateRequest.Id);
				if (village is null)
					throw new InvalidDataException("Erreur: village inexistant!");
				
				CheckNbr(villageUpdateRequest.Nbr);
				village.Nbr = villageUpdateRequest.Nbr;
				await _villageDataAccess.SaveChanges();
			} catch (Exception e) {
				_logger.LogError(e, e.Message);
				throw;
			}
		}
		
		private void CheckNbr(int nbr) {
			if(nbr <= 0)
				throw new InvalidDataException("nbr: ne peut pas etre <= 0");
		}
		
		private void CheckRessource(int? ressourceId) {
			if(ressourceId <= 0)
				throw new InvalidDataException("ressourceId: ne peut pas etre <= 0");
		} */
	}
}