using RestApiApp.Models;

namespace RestApiApp.Services
{
	public interface IPrioritiesRepository
	{
		Task<IEnumerable<Priority>> GetAll();
	}
}
