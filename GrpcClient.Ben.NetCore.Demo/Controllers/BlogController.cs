using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using GrpcService.Ben.Demo.Protos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrpcClient.Ben.NetCore.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly Blog.BlogClient blogClient;

        public BlogController(Blog.BlogClient blogClient)
        {
            this.blogClient = blogClient;
        }

        /// <summary>
        ///  Get create
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> InsertBlog([FromQuery] CreateBlogRequest request)
        {
            var result = await blogClient.CreateBlogAsync(request);
            return Ok(result);
        }

        [HttpGet("custom")]
        public async Task<IActionResult> InsertCustom([FromQuery] CustomBlogRequest request)
        {
            return Ok(await blogClient.CustomBlogAsync(request));
        }
    }
}
