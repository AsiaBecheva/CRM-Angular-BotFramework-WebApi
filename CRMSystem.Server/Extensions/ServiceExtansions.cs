﻿//using System.Linq;
//using System.Reflection;
//using CRMSystem.Services;
//using Microsoft.Extensions.DependencyInjection;

//namespace CRMSystem.Server.Extensions
//{
//    public static class ServiceExtansions
//    {
//        public static IServiceCollection AddServices(this IServiceCollection services)
//        {
//            Assembly.GetAssembly(typeof(IService))
//                .GetTypes()
//                .Where(t => t.IsClass && t.GetInterfaces().Any(i => i.Name == $"I{t.Name}"))
//                .Select(t => new
//                {
//                    Interface = t.GetInterface($"I{t.Name}"),
//                    Implementation = t
//                })
//                .ToList()
//                .ForEach(s => services.AddTransient(s.Interface, s.Implementation));

//            return services;
//        }
//    }
//}
