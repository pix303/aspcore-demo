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
			if (_appDBContext.Messages is not null)
			{
				return await _appDBContext.Messages.Where(m => m.Content.Contains(content)).ToListAsync();
			}

			return Enumerable.Empty<Message>();
		}

		public async Task<IEnumerable<Message>> GetByPriority(int priority)
		{
			if (_appDBContext.Messages is not null)
			{
				return await _appDBContext.Messages.Where(m => m.PriorityId.Equals(priority)).ToListAsync();
			}

			return Enumerable.Empty<Message>();
		}

	}


}
