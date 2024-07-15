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
		[ProducesResponseType(200, Type = typeof(IEnumerable<MessageDto>))]
		public async Task<IActionResult> Find(string? content, int? priority)
		{
			var resultDto = new List<MessageDto>();
			IEnumerable<Message> tempResult = new List<Message>();

			if (priority is null && content is null)
			{
				return BadRequest("No content and priority to find out");
			}
			else if (priority is null && content is string)
			{
				tempResult = await _repository.GetByContent(content);
			}
			else if (content is null && priority is int)
			{
				tempResult = await _repository.GetByPriority((int)priority);
			}
			else if (content is not null && priority is not null)
			{
				tempResult = await _repository.GetByContentAndPriority(content, (int)priority);
			}

			if (tempResult.Count() > 0)
			{
				foreach (var msg in tempResult)
				{
					MessageDto mdto = new MessageDto
					{
						Content = msg.Content,
						Id = msg.Id,
						Priority = msg.Priority is not null ? new PriorityDto
						{
							Id = msg.Priority!.Id,
							Description = msg.Priority.Description,
						} : null,
					};
					resultDto.Add(mdto);
				}
				return Ok(resultDto);
			}

			var priorityErrMsg = (priority ?? 0) == 0 ? "undefined" : priority.ToString();
			return NotFound($"No result with search criteria content={content ?? ""} && priority={priorityErrMsg}");

		}
	}
}
