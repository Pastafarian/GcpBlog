using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GcpBlog.Application.Dtos;
using GcpBlog.Application.Handlers.Command;
using GcpBlog.Application.Handlers.Query;
using GcpBlog.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace GcpBlog.Api.Controllers
{
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<List<PostDto>>> Index()
        {
            var response = await _mediator.Send(new GetPosts.Query(), CancellationToken.None);
            return  Ok(response);
        }

        [Route("{slug}")]
        [HttpGet]
        public async Task<ActionResult<List<PostDto>>> GetPost(string slug)
        {
            var response = await _mediator.Send(new GetPost.Query(slug), CancellationToken.None);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<PostDto>> CreatePost([FromBody] CreatePostRequest postDto)
        {
            await _mediator.Send(new CreatePost.Command(postDto), CancellationToken.None);
            return Ok();
        }

        [Route("{slug}")]
        [HttpDelete]
        public async Task<ActionResult> DeletePost(string slug)
        {
            await _mediator.Send(new DeletePost.Command(slug), CancellationToken.None);
            return Ok();
        }
    }
}