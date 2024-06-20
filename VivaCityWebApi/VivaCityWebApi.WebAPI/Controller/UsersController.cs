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
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsersDto?>> GetUserById(int id) {
        var game = await _userService.GetUserById(id);
        if (game == null) {
            return NotFound();
        }
        return Ok(game);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateUserAsync(UserCreationRequest userCreationRequest) {
        try {
            var user = await _userService.CreateUserAsync(userCreationRequest);
            return Created($"/api/Users/{user.Name}", user);
        } catch (InvalidDataException ex) {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("searchByName/{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<GameDto>>> SearchByName(string name) {
        return Ok(await _userService.SearchByName(name));
    }
}