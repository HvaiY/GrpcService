using Grpc.Core;
using Grpc.Core.Interceptors;
using GrpcService.Ben.Demo.Protos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Ben.Demo.Interceptors
{
    public class CustomInterceptor : Interceptor
    {
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                if (context.Method.Contains("CustomBlog"))
                {
                    var req = request as CustomBlogRequest;
                    if (string.IsNullOrWhiteSpace(req.Code))
                    {
                        var blog = new CustomBlogReply
                        {
                            Success = false,
                            RequestValues = "请求测试拦截了，Code为空或者空字符串:" + JsonConvert.SerializeObject(request),
                        } as TResponse;
                        return blog;
                    }
                }
                return await continuation(request, context);
            }
            catch (RpcException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message + "\r\n" + ex.StackTrace));
            }
        }
    }
}
