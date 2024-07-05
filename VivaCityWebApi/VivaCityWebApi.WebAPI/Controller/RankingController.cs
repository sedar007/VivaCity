using VivaCityWebApi.Common.Interfaces;

namespace VivaCityWebApi.WebAPI.Controller;
using VivaCityWebApi.Common.DTO;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class RankingController : ControllerBase
{
    
    private readonly IRankingService _rankingService;
    
    public RankingController(IRankingService rankingService) {
        _rankingService = rankingService;
    }
    
   
    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<RankDto>>> GetRanking() {
        return Ok(await _rankingService.GetRanking());
    }
    
}
    