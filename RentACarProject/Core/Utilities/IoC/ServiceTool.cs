using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        //Burası bizim webapi veya autofac de oluşturdugumuz injectionları oluşturabilmemize yarıyor.
        //Aspect lerde DependencyInjection yapılamıyor. örnek olarak controller business çagırır business dal ı çagırır. Aspect bu düzende yoktur olmadıgı için bu şekilde onları otomatik çagıran sistem yapıyoruz.

        //Constractar injacte edilip çalışmaz.Çünkü zincir webapi business dataaccess diye ilerliyor. Aspect bambaşka bir zincirin içinde dolayısıyla bizde bunun için servicetool yazdık.ICoremodule ile servicetool enjacte etmiştik.Biz oyüzden aspect bambaşka zincirde oldugunndan bu tarz işlemleri constracterda yapamayız çalışmaz.

        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
