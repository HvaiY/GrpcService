using Ben.RedisExtend.RedisManagers;
using Grpc.Core;
using GrpcService.Ben.Demo.Models;
using GrpcService.Ben.Demo.Protos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Ben.Demo.Services
{
    public class BlogService : Blog.BlogBase
    {
        private readonly IRedisManager redisManager;

        private List<BlogModel> blogs;

        public BlogService(IRedisManager redisManager)
        {
            this.redisManager = redisManager;
        }

        //重redis初始化Blog集合
        private void InitBlogs()
        {
            var value = redisManager.GetString(nameof(BlogService));
            if (value != null)
            {
                blogs = JsonConvert.DeserializeObject<List<BlogModel>>(value);
            }
            else
            {
                blogs = new List<BlogModel>();
            }
        }

        public async override Task<CreateBlogReply> CreateBlog(CreateBlogRequest request, ServerCallContext context)
        {
            InitBlogs();
            if (!string.IsNullOrWhiteSpace(request.Code) && !blogs.Any(b => b.Code.Equals(request.Code)))
            {
                blogs.Add(new BlogModel
                {
                    Code = request.Code,
                    Name = request.Name,
                    Title = request.Title,
                    Descript = request.Descript,
                    NumberWord = request.NumberWord,
                    Id = Guid.NewGuid().ToString()
                });
                redisManager.SetString(nameof(BlogService), JsonConvert.SerializeObject(blogs));
                return new CreateBlogReply
                {
                    Success = true,
                    RequestValues = JsonConvert.SerializeObject(request)
                };
            }
            return new CreateBlogReply
            {
                Success = false,
                RequestValues = "已存在相同的博客或者请求blog code is empty"
            };
        }

        public async override Task<CustomBlogReply> CustomBlog(CustomBlogRequest request, ServerCallContext context)
        {
            InitBlogs();
            //空校验 在拦截中做过了
            if (blogs.Any(b => b.Code.Equals(request.Code)))
            {
                blogs.Add(new BlogModel { Id = Guid.NewGuid().ToString(), Code = request.Code, Name = request.Name });
                redisManager.SetString(nameof(BlogService), JsonConvert.SerializeObject(blogs));
                if (request.IsReply)
                {
                    return new CustomBlogReply
                    {
                        Success = true,
                        RequestValues = JsonConvert.SerializeObject(request)
                    };
                }
                return default;
            }
            return new CustomBlogReply
            {
                Success = false,
                RequestValues = "已存在相同的博客"
            };
        }
    }
}
