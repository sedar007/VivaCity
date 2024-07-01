using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.Requests;

namespace VivaCityWebApi.DataAccess.Interfaces {
	public interface IVillageDataAccess {
		Task<VillageDao?> GetVillageById(int? id);
		Task<VillageDao> Create(VillageCreationRequest request);
	}
}
