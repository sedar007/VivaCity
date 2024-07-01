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
    public async Task<ActionResult<IEnumerable<UsersDto>>> GetUsers() {
        return Ok(await _userService.GetUsersAsync());
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsersDto?>> GetUserById(int id) {
        var user = await _userService.GetUserById(id);
        if (user == null) {
            return NotFound();
        }
        return Ok(user);
    }
    
    [HttpGet("searchByName/{pseudo}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsersDto>> SearchByName(string pseudo) {
        var user = await _userService.SearchByName(pseudo);
        if (user == null) {
            return NotFound();
        }
        return Ok(user);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateUserAsync(UserCreationRequest userCreationRequest) {
        try {
            var user = await _userService.CreateUserAsync(userCreationRequest);
            return Created($"/api/Users/{user.Pseudo}", user);
        } catch (InvalidDataException ex) {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost("createVillage")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddVillage(UserAddVillageRequest userAddVillageRequest) {
        try {
            await _userService.AddVillage(userAddVillageRequest);
            return Ok();
        } catch (InvalidDataException ex) {
            return BadRequest(ex.Message);
        }
    }
    
    
}