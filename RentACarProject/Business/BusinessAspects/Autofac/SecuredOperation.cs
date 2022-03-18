using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;


namespace Business.BusinessAspects.Autofac
{

    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; //JWT ye istek yaptıgımızda o anda binlerce kişi istek yapabilir. Her bir istek için HttpContext i oluşur

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');//Split komutu belirttiğimiz kelimeye göre belirleyip array e atıyor. yani ' , ' bunu görene kadar kısmı array bir elemanmış gibi at ' , ' den sonrasını yine bir elemanmış gibi array e at.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();//Aspect lerde DependencyInjection yapılamıyor. örnek olarak controller business çagırır business dal ı çagırır. Aspect bu düzende yoktur olmadıgı için bu şekilde onları otomatik çagıran sistem yapıyoruz.ServiceTool classıyla otomatik DependencyInjection yaptırabiliyoruz.

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
