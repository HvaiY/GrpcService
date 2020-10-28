using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace GrpcService.Ben.Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var aspnetcorePort = Environment.GetEnvironmentVariable("ASPNETCORE_PORT") ?? "5000";
                    int.TryParse(aspnetcorePort, out int port);
                    // 设置 Kestrel 绑定端口及服务
                    webBuilder.ConfigureKestrel(options =>
                   {
                       options.ListenAnyIP(port, options => options.Protocols = HttpProtocols.Http1);
                       options.ListenAnyIP(port + 1, options => options.Protocols = HttpProtocols.Http2);
                   })
                   .UseStartup<Startup>();
                });
    }
}
