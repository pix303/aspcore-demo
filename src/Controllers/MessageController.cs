using Microsoft.AspNetCore.Mvc;
using RestApiApp.Models;

namespace RestApiApp.Services
{
	[ApiController]
	[Route("api/message")]
	[Produces("application/json")]
	public class MessageController : ControllerBase
	{

		private IMessagesRepository _repository;
		public MessageController(IMessagesRepository repository)
		{
			_repository = repository;
		}


		[HttpGet("find")]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		[ProducesResponseType(500)]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Message>))]
		public async Task<IActionResult> Find(string? content, int? priority)
		{
			IEnumerable<Message> result = new List<Message>();

			if (priority is null && content is null)
			{
				return BadRequest("No content and priority to find out");
			}
			else if (priority is null && content is string)
			{
				result = await _repository.GetByContent(content);
			}
			else if (content is null && priority is int)
			{
				result = await _repository.GetByPriority((int)priority);
			}
			else if (content is not null && priority is not null)
			{
				result = await _repository.GetByContentAndPriority(content, (int)priority);
			}

			if (result.Count() > 0)
			{
				return Ok(result);
			}
			return NotFound($"No result with search criteria content={content ?? ""} && priority={priority ?? -1}");
		}


	}
}
