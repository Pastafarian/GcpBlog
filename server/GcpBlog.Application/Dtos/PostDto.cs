namespace GcpBlog.Application.Dtos
{
	public class PostDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
        public string Slug { get; set; }
    }
}