using Microsoft.AspNetCore.Mvc;
using RestApiApp.Models;

namespace RestApiApp.Controllers
{
	[ApiController]
	[Route("api/welcome")]
	public class WelcomeController : ControllerBase
	{
		public string Index()
		{
			return "ciao sono api rest fatta in wsl";
		}

		[HttpGet("name")]
		public string WelcomeName(string name)
		{
			return $"ciao {name} sono api rest fatta in wsl";
		}

		[HttpGet("message")]
		public Message WelcomeMessage(string name)
		{
			var msg = new Message($"ciao {name}", 3);
			return msg;
		}

	}
}
