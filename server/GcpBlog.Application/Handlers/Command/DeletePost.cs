using System.Threading;
using System.Threading.Tasks;
using GcpBlog.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GcpBlog.Application.Handlers.Command
{
	public class DeletePost
	{
		public class Command : IRequest
		{
			public string Slug { get; set; }

			public Command(string slug)
            {
                Slug = slug;
            }
		}

		public class Handler : AsyncRequestHandler<Command>
		{
			private readonly Context _context;

			public Handler(Context context)
			{
				_context = context;
			}

			protected override async Task Handle(Command command, CancellationToken cancellationToken)
			{
				var post = await _context.Posts.SingleAsync(x => x.Slug == command.Slug, cancellationToken);
				_context.Posts.Remove(post);
				await _context.SaveChangesAsync(cancellationToken);
			}
		}
	}
}