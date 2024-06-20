using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;

namespace VivaCityWebApi.Business.Interfaces {
	public interface ICoutService {
		Task<CoutDto?> GetCoutById(int id);
		Task<CoutDto> Create(CoutCreationRequest request);
		Task Update(CoutUpdateRequest coutUpdateRequest);
	}
}
