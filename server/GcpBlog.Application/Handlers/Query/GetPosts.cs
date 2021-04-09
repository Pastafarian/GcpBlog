using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GcpBlog.Application.Dtos;
using GcpBlog.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GcpBlog.Application.Handlers.Query
{
    public class GetPosts : IRequest<List<PostDto>>
    {
        public class Query : IRequest<List<PostDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<PostDto>>
        {
            private readonly Context _context;

            public Handler(Context context)
            {
                _context = context;
            }

            public async Task<List<PostDto>> Handle(Query query, CancellationToken cancellationToken)
            {
                return await _context.Posts.AsNoTracking().Select(x => new PostDto
                {
                    Id = x.Id,
                    Body = x.Body,
                    Title = x.Title,
                    Slug = x.Slug
                }).ToListAsync(cancellationToken);
            }
        }
    }
}
