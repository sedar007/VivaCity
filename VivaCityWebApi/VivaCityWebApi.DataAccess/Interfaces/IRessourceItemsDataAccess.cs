using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.Requests;

namespace VivaCityWebApi.DataAccess.Interfaces {
    public interface IRessourceItemsDataAccess {
        Task<IEnumerable<RessourceItemDao>> GetRessourceItems();
        Task<RessourceItemDao?> GetRessourceItemById(int id);
        Task<IEnumerable<RessourceItemDao>> SearchByName(string name);
        Task<RessourceItemDao> Create(RessourceItemCreationRequest request);
        Task SaveChanges();
        Task Remove(int id);
        
        Task <Boolean> isExist(string name);
    }
}