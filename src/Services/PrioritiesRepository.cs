
using Microsoft.EntityFrameworkCore;
using RestApiApp.Models;

namespace RestApiApp.Services
{
	public class PrioritiesRepository : IPrioritiesRepository
	{
		private AppDBContext _appDBContext;

		public PrioritiesRepository(AppDBContext appDBContext)
		{
			_appDBContext = appDBContext;
		}

		public async Task<IEnumerable<Priority>> GetAll()
		{
			return await _appDBContext.Priorities.ToListAsync();
		}
	}
}
