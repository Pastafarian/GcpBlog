using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GcpBlog.Domain.Factory
{
	public class BlogContextFactory : IDesignTimeDbContextFactory<Context>
	{
		public Context CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<Context>();
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=a;Password=a;Database=CloudBlog;");

			return new Context(optionsBuilder.Options);
		}
	}
}