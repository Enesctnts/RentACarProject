using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        //Constractar injacte edilip çalışmaz.Çünkü zincir webapi business dataaccess diye ilerliyor. Aspect bambaşka bir zincirin içinde dolayısıyla bizde bunun için servicetool yazdık.ICoremodule ile servicetool enjacte etmiştik.Biz oyüzden aspect bambaşka zincirde oldugunndan bu tarz işlemleri constracterda yapamayız çalışmaz.
        void Load(IServiceCollection serviceCollection);
    }
}
