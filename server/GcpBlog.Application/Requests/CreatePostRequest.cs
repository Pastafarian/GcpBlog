
namespace GcpBlog.Application.Requests
{
	public class CreatePostRequest
	{
		public string Title { get; set; }
		public string Body { get; set; }
        public string Slug => Title.ToLower().Replace(" ", "_");
    }
}