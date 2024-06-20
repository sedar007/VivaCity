using VivaCityWebApi.Business.Interfaces;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace VivaCityWebApi.WebAPI.Controller {
	[ApiController]
	[Route("api/[controller]")]
	public class RessourceItemController : ControllerBase {
		private readonly IRessourceItemService _ressourceItemService;
		public RessourceItemController(IRessourceItemService ressourceItemService) {
			_ressourceItemService = ressourceItemService;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<RessourceItemDto>>> GetRessourceItem() {
			return Ok(await _ressourceItemService.GetRessourceItems());
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<RessourceItemDto?>> GetRessourceItemById(int id) {
			var ressourceItem = await _ressourceItemService.GetRessourceItemById(id);
			if (ressourceItem == null)
			{
				return NotFound();
			}

			return Ok(ressourceItem);
		}
	}
}
