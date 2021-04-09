using GcpBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GcpBlog.Domain.EntityConfigurations
{
	public class PostConfiguration : IEntityTypeConfiguration<Post>
	{
		public void Configure(EntityTypeBuilder<Post> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Slug).HasMaxLength(100);
        }
	}
}

