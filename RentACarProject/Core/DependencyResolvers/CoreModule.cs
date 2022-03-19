using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        //Tüm projelerdeki bağımlılıkları çözmek için bu modulü oluşturduk. Tüm projelerdeki injactionları kullanmak için bunu uyguluyoruz.
        //Constractar injacte edilip çalışmaz.Çünkü zincir webapi business dataaccess diye ilerliyor. Aspect bambaşka bir zincirin içinde dolayısıyla bizde bunun için servicetool yazdık.ICoremodule ile servicetool enjacte etmiştik.Biz oyüzden aspect bambaşka zincirde oldugunndan bu tarz işlemleri constracterda yapamayız çalışmaz.
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();//Alttaklerle ayni işi yapıyor. Sadece MemoryCache hazır bir yapi oldugu için bunu bize microsoft yazmış biz direk bu şekilde yapınca arkada tarafta instance sini oluşturuyor. IMemoryCache  istenildiği zaman gelip bakıyor ve burada eklendiğini görünce arka tarafta oluşan instance kullanıyor.
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();

        }
    }
}
