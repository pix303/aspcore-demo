using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiApp.Models
{
	// by default use same class name to plural (how do plural of exeptions?)
	// so to avoid ec migration names of table and columns must be mapped
	[Table("messages")]
	public class Message
	{
		// map the primary key column
		[Key]
		[Column("id")]
		public Int32 Id { get; set; }

		private string _content = "";
		[MinLength(3, ErrorMessage = "min length is 3 char")]
		[MaxLength(3, ErrorMessage = "max length is 100 char")]
		[Column("content")]
		public string Content
		{
			get { return _content; }
			set { _content = value; }
		}


		[Range(0, 5, ErrorMessage = "possible value 1,2,3,4,5")]
		[Column("priority_id")]
		public int PriorityId { get; set; }

		public virtual Priority? Priority { get; set; }

		public Message(string content, int priorityId)
		{
			PriorityId = priorityId;
			Content = content;
		}
	}
}
