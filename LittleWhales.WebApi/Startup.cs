using AutoMapper;
using Castle.Windsor.MsDependencyInjection;
using Core.WebApi.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LittleWhales.Infrastructure;
using LittleWhales.Infrastructure.Redis;
using Microsoft.Extensions.Caching.Redis;
using LittleWhales.Core;
using LittleWhales.Domain.BasicInfoManage;
using System.Reflection;
using LittleWhales.Core.Extends;
using Microsoft.AspNetCore.Http;

namespace HTJWWebApi
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup
        /// </summary>
        public Startup(IConfiguration configuration)//(IHostingEnvironment env)
        {
            Configuration = configuration;
            //Configuration = new ConfigurationBuilder()
            //    .SetBasePath(env.ContentRootPath)
            //    .AddJsonFile("\\Configs\\appsettings.json", optional: true, reloadOnChange: true)
            //    .AddEnvironmentVariables()
            //    .Build();
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            if (string.Equals(Configuration.GetSection("EnableSwagger").Value, "True"))
            {
                DISwagger(services);
            }
            //添加 Cors 跨域,
            services.AddCors(option =>
            {
                //添加一个名为 AllowAny 的策略
                option.AddPolicy("AllowAny", builder =>
                {
                    //配置跨域项
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                    builder.AllowCredentials();
                });
            });
            DIAutoMapper(services);
            DIChacheRedis(services);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<HttpHeadersExtend>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var container = BasicConventionalRegistrar.RegisterAssembly();
            //替换容器
            return WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }

        #region 第三方注入
        /// <summary>
        /// 注入 Swagger
        /// </summary>
        /// <param name="services"></param>
        private void DISwagger(IServiceCollection services)
        {
            var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
            DirectoryInfo dinfo = new DirectoryInfo(basePath);
            var paths = dinfo.GetFileSystemInfos();
            List<string> pathList = new List<string>();
            foreach (var path in paths)
            {
                if (path.FullName.EndsWith(".xml"))
                {
                    pathList.Add(path.FullName);
                }
            }
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                //使用域描述
                c.OperationFilter<ApiHttpHeaderFilter>();
                pathList.ForEach(fe => c.IncludeXmlComments(fe, true))
                ;
            });
        }

        /// <summary>
        /// 注入 AutoMapper
        /// </summary>
        /// <param name="services"></param>
        private void DIAutoMapper(IServiceCollection services)
        {
            List<Type> types = new List<Type>();
            var assemblies = BasicConventionalRegistrar.GetAssemblys("Manage.Web.dll");
            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (typeof(Profile).IsAssignableFrom(type))
                    {
                        if (type.IsClass && !type.IsAbstract)
                        {
                            types.Add(type);
                        }
                    }
                }
            }
            services.AddAutoMapper(types.ToArray());
        }

        /// <summary>
        /// 注入 Redis
        /// </summary>
        /// <param name="services"></param>
        private void DIChacheRedis(IServiceCollection services)
        {
            services.AddSingleton(typeof(ICacheService), new RedisCacheService(
                conn: Configuration.GetSection("Cache:ConnectionString").Value,
                db: Configuration.GetSection("Cache:db").Value));
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory factory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            #region 日志
            //ILogger<Startup> logger = factory.CreateLogger<Startup>();
            //logger.LogError("This is Startup Error");
            #endregion

            #region Swagger
            if (string.Equals(Configuration.GetSection("EnableSwagger").Value, "True"))
            {
                //启用中间件服务生成Swagger作为JSON终结点
                app.UseSwagger();
                //启用中间件服务对swagger-ui，指定Swagger JSON终结点
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }
            #endregion
        }
    }
}
