using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;

namespace VivaCityWebApi.Business.Interfaces {
	public interface IRessourceService {
		Task<RessourceDto?> GetRessourceById(int id);
		Task<RessourceDto> Create(RessourceCreationRequest request);
		Task Update(RessourceUpdateRequest ressourceUpdateRequest);
	}
}
