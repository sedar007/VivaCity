using Microsoft.Extensions.Logging;
using VivaCityWebApi.Business.Interfaces;
using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Interfaces;
using VivaCityWebApi.Common.Requests;
using VivaCityWebApi.DataAccess.Interfaces;

namespace VivaCityWebApi.Business.Implementations;

public class RankingService : IRankingService
{
    private readonly IRankingDataAccess _rankingDataAccess;
    private readonly ILogger<RankingService> _logger;
    
    public RankingService(IRankingDataAccess rankingDataAccess, ILogger<RankingService> logger)
    {
        this._rankingDataAccess = rankingDataAccess;
        _logger = logger;
    }
    
    public async Task<IEnumerable<RankDto>> GetRanking()
    {
        try {
            return (await _rankingDataAccess.GetRanking())
                .Select(RankDao => RankDao.ToDto());
        } catch (Exception e) {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}