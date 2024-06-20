using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;

namespace VivaCityWebApi.Business.Interfaces {
	public interface IRessourceItemService {
		Task<IEnumerable<RessourceItemDto>> GetRessourceItems();
		Task<RessourceItemDto?> GetRessourceItemById(int id);
		Task<RessourceItemDto> Create(RessourceItemCreationRequest request);
	}
}
