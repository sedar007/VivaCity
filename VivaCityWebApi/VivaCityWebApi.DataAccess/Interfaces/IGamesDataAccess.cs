using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.Requests;

namespace VivaCityWebApi.DataAccess.Interfaces {
	public interface IGamesDataAccess {
		Task<IEnumerable<GameDao>> GetGames();
		Task<GameDao?> GetGameById(int id);
		Task<IEnumerable<GameDao>> SearchByName(string name);
		Task<GameDao> Create(GameCreationRequest request);
		Task SaveChanges();
		Task Remove(int id);
	}
}
