using VivaCityWebApi.Business.Interfaces;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace VivaCityWebApi.WebAPI.Controller {
	[ApiController]
	[Route("api/ressourceItem/[controller]")]
	public class RessourceItemsController : ControllerBase {
		private readonly IRessourceItemService _ressourceItemService;
		public RessourceItemsController(IRessourceItemService ressourceItemService) {
			_ressourceItemService = ressourceItemService;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<RessourceItemDto>>> GetRessourceItems() {
			return Ok(await _ressourceItemService.GetRessourceItems());
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<RessourceItemDto?>> GetRessourceItemById(int id) {
			var ressourceItem = await _ressourceItemService.GetRessourceItemById(id);
			if (ressourceItem == null) {
				return NotFound();
			}
			return Ok(ressourceItem);
		}

		[HttpGet("searchByName/{name}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<RessourceItemDto>>> SearchByName(string name) {
			return Ok(await _ressourceItemService.SearchByName(name));
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Create(RessourceItemCreationRequest ressourceItemRequest) {
			try {
				var ressourceItem = await _ressourceItemService.Create(ressourceItemRequest);
				return Created($"/api/RessourceItems/{ressourceItem.Id}", ressourceItem);
			} catch (InvalidDataException ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("update")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Update(RessourceItemUpdateRequest ressourceItemUpdateRequest) {
			try {
				await _ressourceItemService.Update(ressourceItemUpdateRequest);
				return Ok();
			} catch (InvalidDataException ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("delete/{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult> Delete(int id) {
			try {
				await _ressourceItemService.Delete(id);
				return NoContent();
			} catch (InvalidDataException) {
				return NotFound();
			}
		}
	}
}
