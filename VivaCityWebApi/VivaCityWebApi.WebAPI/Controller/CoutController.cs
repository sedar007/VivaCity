using VivaCityWebApi.Business.Interfaces;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace VivaCityWebApi.WebAPI.Controller {
	[ApiController]
	[Route("api/cout/[controller]")]
	public class CoutsController : ControllerBase {
		private readonly ICoutService _coutService;
		public CoutsController(ICoutService coutService) {
			_coutService = coutService;
		}
		
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<CoutDto?>> GetCoutById(int id) {
			var cout = await _coutService.GetCoutById(id);
			if (cout == null) {
				return NotFound();
			}
			return Ok(cout);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Create(CoutCreationRequest coutRequest) {
			try {
				var cout = await _coutService.Create(coutRequest);
				return Created($"/api/Couts/{cout.Id}", cout);
			} catch (InvalidDataException ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("update")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Update(CoutUpdateRequest coutUpdateRequest) {
			try {
				await _coutService.Update(coutUpdateRequest);
				return Ok();
			} catch (InvalidDataException ex) {
				return BadRequest(ex.Message);
			}
		}
		
	}
}
