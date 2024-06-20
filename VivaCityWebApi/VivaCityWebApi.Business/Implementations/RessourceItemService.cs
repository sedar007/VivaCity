using VivaCityWebApi.Business.Interfaces;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;
using VivaCityWebApi.DataAccess.Interfaces;
using Microsoft.Extensions.Logging;

namespace VivaCityWebApi.Business.Implementations {
	public class RessourceItemService : IRessourceItemService {
		private readonly IRessourceItemsDataAccess _ressourceItemDataAccess;
		private readonly ILogger<RessourceItemService> _logger;
		public RessourceItemService(ILogger<RessourceItemService> logger, IRessourceItemsDataAccess ressourceItemDataAccess) {
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

		public async Task<IEnumerable<RessourceItemDto>> SearchByName(string name) {
			try {
				return (await _ressourceItemDataAccess.SearchByName(name))
					.Select(ressourceItemDao => ressourceItemDao.ToDto());
			} catch (Exception e) {
				_logger.LogError(e, e.Message);
				throw;
			}
		}

		private void CheckPicture(string picture) {
			if (string.IsNullOrWhiteSpace(picture)) 
				throw new InvalidDataException("Erreur: picture vide");
		}
		
		
		private async void CheckName(string name) {
			if(await _ressourceItemDataAccess.isExist(name))
				throw new InvalidDataException("RessourceItem already exists!");
				
			if (string.IsNullOrWhiteSpace(name)) 
				throw new InvalidDataException("Erreur: Nom vide");
		}
		
		public async Task<RessourceItemDto> Create(RessourceItemCreationRequest request) {
			try {
				if (request == null) 
					throw new InvalidDataException("Erreur inconnue");
				
				CheckName(request.Name);
				CheckPicture(request.Picture);
				
				return (await _ressourceItemDataAccess.Create(request)).ToDto();
			} catch (Exception e) {
				_logger.LogError(e, e.Message);
				throw;
			}
		}

		public async Task Update(RessourceItemUpdateRequest ressourceItemUpdateRequest) {
			try {
				var ressourceItem = await _ressourceItemDataAccess.GetRessourceItemById(ressourceItemUpdateRequest.Id);
				if (ressourceItem is null) {
					throw new InvalidDataException("Erreur: ressourceItem inexistant!");
				}

				CheckName(ressourceItemUpdateRequest.Name);
				CheckPicture(ressourceItemUpdateRequest.Picture);
				
				ressourceItem.Name = ressourceItemUpdateRequest.Name;
				ressourceItem.Picture = ressourceItemUpdateRequest.Picture;

				await _ressourceItemDataAccess.SaveChanges();
			} catch (Exception e) {
				_logger.LogError(e, e.Message);
				throw;
			}
		}

		public async Task Delete(int id) {
			try {
				var ressourceItem = await _ressourceItemDataAccess.GetRessourceItemById(id);
				if (ressourceItem is null) {
					throw new InvalidDataException("Erreur: jeu inexistant!");
				}

				await _ressourceItemDataAccess.Remove(id);
			} catch (Exception e) {
				_logger.LogError(e, e.Message);
				throw;
			}
		}
	}
}