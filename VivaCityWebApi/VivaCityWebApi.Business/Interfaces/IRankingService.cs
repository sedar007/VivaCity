using VivaCityWebApi.Common.DTO;

namespace VivaCityWebApi.Common.Interfaces;


    public interface IRankingService {
        Task<IEnumerable<RankDto>> GetRanking();
    }
