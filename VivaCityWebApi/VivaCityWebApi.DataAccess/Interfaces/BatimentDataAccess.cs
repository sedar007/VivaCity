using VivaCityWebApi.Common.DAO;

namespace VivaCityWebApi.DataAccess.Interfaces {
	public interface IBatimentDataAccess {
		Task<BatimentDao?> GetBatimentById(int id);
		Task<BatimentDao?> GetBatimentByType(int type);
		Task<BatimentDao?> GetBatimentByIdType(int id, int type);
		
	}
}
