using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiApp.Models
{
	[Table("priority")]
	public class Priority
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("description")]
		public string Description { get; set; }

		public virtual ICollection<Message>? Messages { get; set; }

		public Priority(string description)
		{
			Description = description;
		}
	}
}
