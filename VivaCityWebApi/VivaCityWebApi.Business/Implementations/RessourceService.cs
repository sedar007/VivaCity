using VivaCityWebApi.Business.Interfaces;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;
using VivaCityWebApi.DataAccess.Interfaces;
using Microsoft.Extensions.Logging;
using VivaCityWebApi.Common.DAO;

namespace VivaCityWebApi.Business.Implementations {
	public class RessourceService : IRessourceService {
		private readonly IRessourceDataAccess _ressourceDataAccess;
		
		private readonly ILogger<RessourceService> _logger;
		public RessourceService(ILogger<RessourceService> logger, IRessourceDataAccess ressourceDataAccess) {
			_logger = logger;
			_ressourceDataAccess = ressourceDataAccess;
		}
		
		public async Task<RessourceDto?> GetRessourceById(int id) {
			try {
				return (await _ressourceDataAccess.GetById(id))?.ToDto();
			} catch (Exception e) {
				_logger.LogError(e, e.Message);
				throw;
			}
		}
		
		
		public async Task<RessourceDto> Create(RessourceCreationRequest request) {
			try {
				if (request == null)
					throw new InvalidDataException("Erreur inconnue");
				if(request.Nbr <= 0)
					throw new InvalidDataException("Erreur: nbr ne peut pas etre <= 0");
				
				if(request.Max <= 0)
					throw new InvalidDataException("Erreur: max ne peut pas etre <= 0");
				if(request.Nbr > request.Max)
					throw new InvalidDataException("Erreur: nbr > max");
				
				return (await _ressourceDataAccess.Create(request)).ToDto();
			} catch (Exception e) {
				_logger.LogError(e, e.Message);
				throw;
			}
		}

		public async Task Update(RessourceUpdateRequest ressourceUpdateRequest) {
			try {
				var ressource = await _ressourceDataAccess.GetById(ressourceUpdateRequest.Id);
				if (ressource is null)
					throw new InvalidDataException("Erreur: ressource inexistant!");
				
				if(ressourceUpdateRequest.Max <= 0)
					throw new InvalidDataException("Erreur: max ne peut pas etre <= 0");
				
				CheckNbr(ressourceUpdateRequest.Nbr);
				
				ressource.Max = ressourceUpdateRequest.Max;
				ressource.Nbr = ressourceUpdateRequest.Nbr;
				
				await _ressourceDataAccess.SaveChanges();
			} catch (Exception e) {
				_logger.LogError(e, e.Message);
				throw;
			}
		}
		
		private void CheckNbr(int nbr) {
			if(nbr <= 0)
				throw new InvalidDataException("nbr: ne peut pas etre <= 0");
		}
	}
}