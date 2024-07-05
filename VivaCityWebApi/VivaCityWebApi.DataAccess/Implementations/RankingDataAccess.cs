using Microsoft.EntityFrameworkCore;
using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.DataAccess.Interfaces;

namespace VivaCityWebApi.DataAccess.Implementations;

public class RankingDataAccess : IRankingDataAccess
{
    private readonly GameContext _context;
    public RankingDataAccess(GameContext context) {
        this._context = context;
    }
    
    public async Task <IEnumerable<RankDao>> GetRanking() {
        var rankings = await _context.Users.OrderByDescending(x => x.Scores).Select(x => new RankDao {
            Pseudo = x.Pseudo,
            Score = x.Scores
        }).ToListAsync();
        return rankings;
    }
    
}