using Microsoft.EntityFrameworkCore;
using RestApiApp.Models;

namespace RestApiApp.Services
{
	public class MessagesRepository : IMessagesRepository
	{
		private AppDBContext _appDBContext;
		public MessagesRepository(AppDBContext appDbContext)
		{
			_appDBContext = appDbContext;
		}

		public Task<bool> Insert(Message message)
		{
			throw new NotImplementedException();
		}

		public bool Update(Message message)
		{
			throw new NotImplementedException();
		}

		public bool Delete(Message message)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Message>> GetByContent(string content)
		{
			return await _appDBContext.Messages
			.Where(m => m.Content.Contains(content))
			.Include(m => m.Priority)
			.ToListAsync();
		}

		public async Task<IEnumerable<Message>> GetByPriority(int priority)
		{
			return await _appDBContext.Messages
			.Where(m => m.PriorityId.Equals(priority))
			.Include(m => m.Priority)
			.ToListAsync();
		}

		public async Task<IEnumerable<Message>> GetByContentAndPriority(string content, int priority)
		{
			return await _appDBContext.Messages
			.Where(m => m.PriorityId.Equals(priority))
			.Where(m => m.Content.Contains(content))
			.Include(m => m.Priority)
			.ToListAsync();
		}
	}


}
