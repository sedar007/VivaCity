using VivaCityWebApi.Business.Interfaces;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace VivaCityWebApi.WebAPI.Controller {
	[ApiController]
	[Route("api/[controller]")]
	public class VillagesController : ControllerBase {
		private readonly IVillageService _villageService;
		public VillagesController(IVillageService villageService) {
			_villageService = villageService;
		}
		
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Create(VillageCreationRequest villageRequest) {
			try {
				var village = await _villageService.Create(villageRequest);
				return Created($"/api/Villages/{village.Id}", village);
			} catch (InvalidDataException ex) {
				return BadRequest(ex.Message);
			}
		}

		
		
		/*[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<VillageDto>>> GetVillages() {
			return Ok(await _villageService.GetVillages());
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<VillageDto?>> GetVillageById(int id) {
			var village = await _villageService.GetVillageById(id);
			if (village == null) {
				return NotFound();
			}
			return Ok(village);
		}

		[HttpGet("searchByName/{name}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<VillageDto>>> SearchByName(string name) {
			return Ok(await _villageService.SearchByName(name));
		}

		

		[HttpPost("update")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Update(VillageUpdateRequest villageUpdateRequest) {
			try {
				await _villageService.Update(villageUpdateRequest);
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
				await _villageService.Delete(id);
				return NoContent();
			} catch (InvalidDataException) {
				return NotFound();
			}
		}*/
	}
}
