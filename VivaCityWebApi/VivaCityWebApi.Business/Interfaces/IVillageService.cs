using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;

namespace VivaCityWebApi.Business.Interfaces {
	public interface IVillageService {
		Task<VillageDto> Create(VillageCreationRequest request);
	}
}
