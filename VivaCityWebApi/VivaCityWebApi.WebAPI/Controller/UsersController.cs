using VivaCityWebApi.Common.Interfaces;

namespace VivaCityWebApi.WebAPI.Controller;
using VivaCityWebApi.Business.Interfaces;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    
    private readonly IUserService _userService;
    
    
    public UsersController(IUserService userService) {
        _userService = userService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<GameDto>>> GetGames() {
        return Ok(await _userService.GetUsersAsync());
    }
}