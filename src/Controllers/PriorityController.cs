using Microsoft.AspNetCore.Mvc;
using RestApiApp.Models;
using RestApiApp.Services;

namespace RestApiApp.Controllers
{
	[ApiController]
	[Route("api/priority")]
	[Produces("application/json")]
	public class PrioritiesController : ControllerBase
	{
		private IPrioritiesRepository _repository;
		public PrioritiesController(IPrioritiesRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Priority>))]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _repository.GetAll());
		}


		[HttpGet("test")]
		public IActionResult GetResponse()
		{
			return Ok("\"hey gringo\"");
		}
	}
}
