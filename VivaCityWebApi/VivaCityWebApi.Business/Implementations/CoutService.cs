using VivaCityWebApi.Business.Interfaces;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;
using VivaCityWebApi.DataAccess.Interfaces;
using Microsoft.Extensions.Logging;
using VivaCityWebApi.Common.DAO;

namespace VivaCityWebApi.Business.Implementations {
	public class CoutService : ICoutService {
		private readonly ICoutDataAccess _coutDataAccess;
		private readonly ILogger<CoutService> _logger;
		public CoutService(ILogger<CoutService> logger, ICoutDataAccess coutDataAccess) {
			_logger = logger;
			_coutDataAccess = coutDataAccess;
		}
		
		public async Task<CoutDto?> GetCoutById(int id) {
			try {
				return (await _coutDataAccess.GetCoutById(id))?.ToDto();
			} catch (Exception e) {
				_logger.LogError(e, e.Message);
				throw;
			}
		}
		
		public async Task<CoutDto> Create(CoutCreationRequest request) {
			try {
				if (request == null)
					throw new InvalidDataException("Erreur inconnue");

				CheckNbr(request.Nbr);
				CheckRessource(request.RessourceId);
				
				return (await _coutDataAccess.Create(request)).ToDto();
			} catch (Exception e) {
				_logger.LogError(e, e.Message);
				throw;
			}
		}

		public async Task Update(CoutUpdateRequest coutUpdateRequest) {
			try {
				var cout = await _coutDataAccess.GetCoutById(coutUpdateRequest.Id);
				if (cout is null)
					throw new InvalidDataException("Erreur: cout inexistant!");
				
				CheckNbr(coutUpdateRequest.Nbr);
				cout.Nbr = coutUpdateRequest.Nbr;
				await _coutDataAccess.SaveChanges();
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
		}
	}
}