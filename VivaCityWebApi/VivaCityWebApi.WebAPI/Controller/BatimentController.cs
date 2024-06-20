using VivaCityWebApi.Business.Interfaces;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace VivaCityWebApi.WebAPI.Controller {
	[ApiController]
	[Route("api/batiment/[controller]")]
	public class BatimentsController : ControllerBase {
		private readonly IBatimentService _batimentService;
		public BatimentsController(IBatimentService batimentService) {
			_batimentService = batimentService;
		}
		
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<BatimentDto?>> GetBatimentById(int id) {
			var batiment = await _batimentService.GetBatimentById(id);
			if (batiment == null) {
				return NotFound();
			}
			return Ok(batiment);
		}
		
		[HttpGet("ByLevel/{type}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<BatimentDto?>> GetBatimentByType(int type) {
			var batiment = await _batimentService.GetBatimentByType(type);
			if (batiment == null) {
				return NotFound();
			}
			return Ok(batiment);
		}
		
		[HttpGet("ById/{id}Level/{type}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<BatimentDto?>> GetBatimentByIdType(int id, int type) {
			var batiment = await _batimentService.GetBatimentByIdType(id, type);
			if (batiment == null) {
				return NotFound();
			}
			return Ok(batiment);
		}
	}
}
