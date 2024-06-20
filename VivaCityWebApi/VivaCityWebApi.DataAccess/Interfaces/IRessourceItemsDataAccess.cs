using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.Requests;

namespace VivaCityWebApi.DataAccess.Interfaces {
	public interface IRessourcesItemsDataAccess {
		Task<IEnumerable<RessourceItemDao>> GetRessourceItems();
		Task<RessourceItemDao?> GetRessourceItemById(int id);
		Task<RessourceItemDao> Create(RessourceItemCreationRequest request);
	}
}
