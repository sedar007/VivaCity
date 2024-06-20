using VivaCityWebApi.Business.Interfaces;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;
using VivaCityWebApi.DataAccess.Interfaces;
using Microsoft.Extensions.Logging;

namespace VivaCityWebApi.Business.Implementations {
	public class RessourceItemService : IRessourceItemService {
		private readonly IRessourcesItemsDataAccess _ressourceItemDataAccess;
		private readonly ILogger<RessourceItemService> _logger;
		public RessourceItemService(ILogger<RessourceItemService> logger, IRessourcesItemsDataAccess ressourceItemDataAccess) {
			_logger = logger;
			_ressourceItemDataAccess = ressourceItemDataAccess;
		}

		public async Task<IEnumerable<RessourceItemDto>> GetRessourceItems() {
			try {
				return (await _ressourceItemDataAccess.GetRessourceItems())
					.Select(ressourceItemDao => ressourceItemDao.ToDto());
			} catch (Exception e) {
				_logger.LogError(e, e.Message);
				throw;
			}
		}

		public async Task<RessourceItemDto?> GetRessourceItemById(int id) {
			try {
				return (await _ressourceItemDataAccess.GetRessourceItemById(id))?.ToDto();
			} catch (Exception e) {
				_logger.LogError(e, e.Message);
				throw;
			}
		}

		private void CheckPicture(string picture) {
			if (string.IsNullOrWhiteSpace(picture)) {
				throw new InvalidDataException("Erreur: picture vide");
			}
		}
		
		public async Task<RessourceItemDto> Create(RessourceItemCreationRequest request) {
			try {
				if (request == null) {
					throw new InvalidDataException("Erreur inconnue");
				}

				// TODO: check name duplications

				if (string.IsNullOrWhiteSpace(request.Name)) {
					throw new InvalidDataException("Erreur: Nom vide");
				}
				CheckPicture(request.Picture);
				
				return (await _ressourceItemDataAccess.Create(request)).ToDto();
			} catch (Exception e) {
				_logger.LogError(e, e.Message);
				throw;
			}
		}

	
	}
}