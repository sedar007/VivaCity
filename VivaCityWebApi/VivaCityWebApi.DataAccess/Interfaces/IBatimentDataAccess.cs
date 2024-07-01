using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.Requests;
namespace VivaCityWebApi.DataAccess.Interfaces {
	public interface IBatimentDataAccess {
		Task<BatimentDao?> GetBatimentById(int id);
		Task<BatimentDao?> GetBatimentByType(int type);
		Task<BatimentDao?> GetBatimentByIdType(int id, int type);
		Task<BatimentDao> Create(BatimentCreationRequest request);
		Task AddVillage(VillageDao village, BatimentDao batimentDao);
		
		
	}
}
