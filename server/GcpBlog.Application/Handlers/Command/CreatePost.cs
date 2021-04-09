using System;
using System.Threading;
using System.Threading.Tasks;
using GcpBlog.Application.Requests;
using GcpBlog.Domain;
using GcpBlog.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GcpBlog.Application.Handlers.Command
{
	public class CreatePost
	{
		public class Command : IRequest
        {
			public CreatePostRequest Request { get; }

			public Command(CreatePostRequest request)
			{
				Request = request;
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
				if (await _context.Posts.AnyAsync(x => x.Slug == command.Request.Slug, cancellationToken))
                    throw new Exception("A post with that slug already exists");

                await _context.Posts.AddAsync(new Post
                {
                    Title = command.Request.Title,
                    Body = command.Request.Body,
                    Slug = command.Request.Slug
                }, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);
			}
        }
	}
}
