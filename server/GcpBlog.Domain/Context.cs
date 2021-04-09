using GcpBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GcpBlog.Domain
{
    #pragma warning disable 8618
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options) : base(options)
		{
		}

		public DbSet<Post> Posts { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Post>().HasData(
				new
				{
					Id = 1,
                    Title = "Angular 11",
					Slug = "angular-11",
					Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec euismod diam quam, at dictum elit tincidunt in.",
                },
				new
				{
					Id = 2,
                    Title = ".NET Core",
					Slug = "core",
					Body = "Donec posuere iaculis iaculis. Donec pulvinar varius diam, nec tincidunt mauris cursus ut. Quisque fringilla risus dignissim justo ultricies aliquam.",
                },
				new
				{
					Id = 3,
                    Title = "Git Hub",
					Slug = "git",
					Body = "Vestibulum egestas dapibus elit non facilisis. Maecenas sit amet elit sem. Donec eget placerat mauris. Sed sodales enim nec lacinia sagittis. Etiam at bibendum quam, condimentum commodo est.",
                });

			base.OnModelCreating(builder);
		}
	}
}
