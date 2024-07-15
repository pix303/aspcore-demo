using RestApiApp.Models;

namespace RestApiApp.Services
{
	public interface IMessagesRepository
	{
		Task<bool> Insert(Message message);
		bool Update(Message message);
		bool Delete(Message message);
		Task<IEnumerable<Message>> GetByContent(string content);
		Task<IEnumerable<Message>> GetByPriority(int priority);
	}
}
