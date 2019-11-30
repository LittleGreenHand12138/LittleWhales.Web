using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HTJWWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging((context, loggingbuilder) =>
            {
                //该方法需要引入Microsoft.Extensions.Logging名称空间

                loggingbuilder.AddFilter("System", LogLevel.Warning); //过滤掉系统默认的一些日志
                loggingbuilder.AddFilter("Microsoft", LogLevel.Warning);//过滤掉系统默认的一些日志

                //添加Log4Net

                var path = Directory.GetCurrentDirectory() + "\\Configs\\log4net.config";
                //不带参数：表示log4net.config的配置文件就在应用程序根目录下，也可以指定配置文件的路径
                loggingbuilder.AddLog4Net(path);
            }).UseStartup<Startup>();
    }
}
