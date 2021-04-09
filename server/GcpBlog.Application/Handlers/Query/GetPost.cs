using System.Threading;
using System.Threading.Tasks;
using GcpBlog.Application.Dtos;
using GcpBlog.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GcpBlog.Application.Handlers.Query
{
    public class GetPost : IRequest<PostDto>
    {
        public class Query : IRequest<PostDto>
        {
            public string Slug { get; set; }

            public Query(string slug)
            {
                Slug = slug;
            }
        }

        public class Handler : IRequestHandler<Query, PostDto>
        {
            private readonly Context _context;

            public Handler(Context context)
            {
                _context = context;
            }

            public async Task<PostDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts.AsNoTracking().SingleAsync(x => x.Slug == request.Slug, cancellationToken);

                return new PostDto
                {
                    Title = post.Title,
                    Body = post.Body,
                    Id = post.Id,
                    Slug = post.Slug
                };
            }
        }
    }
}