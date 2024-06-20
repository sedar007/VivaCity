using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;

namespace VivaCityWebApi.Business.Interfaces {
    public interface IRessourceItemService {
        Task<IEnumerable<RessourceItemDto>> GetRessourceItems();
        Task<RessourceItemDto?> GetRessourceItemById(int id);
        Task<IEnumerable<RessourceItemDto>> SearchByName(string name);
        Task<RessourceItemDto> Create(RessourceItemCreationRequest request);
        Task Update(RessourceItemUpdateRequest ressourceItemUpdateRequest);
        Task Delete(int id);
    }
}