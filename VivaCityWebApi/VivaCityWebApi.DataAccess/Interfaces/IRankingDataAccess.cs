using VivaCityWebApi.Common.DAO;

namespace VivaCityWebApi.DataAccess.Interfaces;

public interface IRankingDataAccess { 
    Task<IEnumerable<RankDao>> GetRanking();
}