using VivaCityWebApi.Business.Interfaces;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace VivaCityWebApi.WebAPI.Controller {
	[ApiController]
	[Route("api/ressource/[controller]")]
	public class RessourcesController : ControllerBase {
		private readonly IRessourceService _ressourceService;
		public RessourcesController(IRessourceService ressourceService) {
			_ressourceService = ressourceService;
		}
		
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<RessourceDto?>> GetRessourceById(int id) {
			var ressource = await _ressourceService.GetRessourceById(id);
			if (ressource == null) {
				return NotFound();
			}
			return Ok(ressource);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Create(RessourceCreationRequest ressourceRequest) {
			try {
				var ressource = await _ressourceService.Create(ressourceRequest);
				return Created($"/api/Ressources/{ressource.Id}", ressource);
			} catch (InvalidDataException ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("update")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Update(RessourceUpdateRequest ressourceUpdateRequest) {
			try {
				await _ressourceService.Update(ressourceUpdateRequest);
				return Ok();
			} catch (InvalidDataException ex) {
				return BadRequest(ex.Message);
			}
		}
		
	}
}
