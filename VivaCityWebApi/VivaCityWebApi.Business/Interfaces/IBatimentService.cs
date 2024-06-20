using VivaCityWebApi.Common.DTO;

namespace VivaCityWebApi.Business.Interfaces {
	public interface IBatimentService {
		Task<BatimentDto?> GetBatimentById(int id);
		Task<BatimentDto?> GetBatimentByType(int type);
		Task<BatimentDto?> GetBatimentByIdType(int id, int type);
	}
}
