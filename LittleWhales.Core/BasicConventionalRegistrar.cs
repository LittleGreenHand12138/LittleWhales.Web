using Castle.MicroKernel.Registration;
using Castle.Windsor;
using LittleWhales.Infrastructure.LeftStyle;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace LittleWhales.Core
{
    public class BasicConventionalRegistrar
    {
        public static readonly WindsorContainer _container = new WindsorContainer();

        /// <summary>
        /// 注册程序集中满足约定的类
        /// </summary>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public static WindsorContainer RegisterAssembly()
        {
            var assemblies = GetAssemblys("Manage.dll");
            foreach (var assembly in assemblies)
            {
                //Transient
                _container.Register(
                    Classes.FromAssembly(assembly)
                           .IncludeNonPublicTypes()
                           .BasedOn<ITransientDependency>()
                           .If(type => !type.GetTypeInfo().IsGenericTypeDefinition)
                           .WithService.Self()
                           .WithService.DefaultInterfaces()
                           .LifestyleTransient()
                );

                //Singleton
                _container.Register(
                    Classes.FromAssembly(assembly)
                           .IncludeNonPublicTypes()
                           .BasedOn<ISingletonDependency>()
                           .If(type => !type.GetTypeInfo().IsGenericTypeDefinition)
                           .WithService.Self()
                           .WithService.DefaultInterfaces()
                           .LifestyleSingleton()
                );
                //PerThread
                _container.Register(
                    Classes.FromAssembly(assembly)
                           .IncludeNonPublicTypes()
                           .BasedOn<ISingletonDependency>()
                           .If(type => !type.GetTypeInfo().IsGenericTypeDefinition)
                           .WithService.Self()
                           .WithService.DefaultInterfaces()
                           .LifestylePerThread()
                );
            }
            return _container;
        }
        public static IEnumerable<Assembly> GetAssemblys(string dllName)
        {
            var basePath = AppContext.BaseDirectory;
            DirectoryInfo dinfo = new DirectoryInfo(basePath);
            var paths = dinfo.GetFileSystemInfos();
            List<string> pathList = new List<string>();
            foreach (var path in paths)
            {
                if (path.FullName.EndsWith(dllName))
                {
                    pathList.Add(path.FullName);
                }
            }
            var assemblies = new List<Assembly>();
            assemblies.Add(Assembly.GetExecutingAssembly());
            pathList.ForEach(fe =>
                assemblies.Add(Assembly.LoadFrom(fe))
            );
            return assemblies;
        }
    }
}
