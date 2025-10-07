namespace Yummy.WebApi.Entities
{
	public class Message
	{
		public int MessageId { get; set; }
		public string NameSurname { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Content { get; set; }
		public DateTime SentAt { get; set; }
		public bool IsRead { get; set; }
	}
}
