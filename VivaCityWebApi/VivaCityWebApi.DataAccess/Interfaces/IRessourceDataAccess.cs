using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.Requests;

namespace VivaCityWebApi.DataAccess.Interfaces {
	public interface IRessourceDataAccess {
		Task<RessourceDao?> GetById(int id);
		Task<RessourceDao> Create(RessourceCreationRequest request);
		Task SaveChanges();
		
	}
}
