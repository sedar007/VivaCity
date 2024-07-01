using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.Requests;

namespace VivaCityWebApi.DataAccess.Interfaces {
	public interface ICoutDataAccess {
		Task<CoutDao?> GetCoutById(int id);
		Task<CoutDao> Create(CoutCreationRequest request);
		Task SaveChanges();
	}
}
