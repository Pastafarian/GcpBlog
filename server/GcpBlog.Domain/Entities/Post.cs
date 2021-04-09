namespace GcpBlog.Domain.Entities
{
	public class Post 
	{
        public int Id { get; set; }
        public string Title { get; set; }
		public string Slug { get; set; }
		public string Body { get; set; }
    }
}
