using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //Core module eklemek için bunu uyguladık. Asıl amacımız bütün modelleri ekleyebilmek için bu extensions yapıyoruz. Polimorfizm uygulayarak yapıyoruz.AddDependencyResolver ile IServiceCollection u genişletiyoruz genişletme yaparken this komutu kullanılır. Birden fazla modul eklebileceğiz bu class sayesinde.Bu yaptıklarımız her projedeuygulayabileceiğimiz core katmanındai tüm injactionları yapabileceğimiz yer.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
