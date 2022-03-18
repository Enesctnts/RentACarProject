using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    // işin içinde şifreleme olan sistemlerde her şeyi byte array formatında veriyor olammız gerekiyor. string şekilde key oluşturamayız. Bu oluşan byte array şeklinde key leri jsonwebtoken  servislerinin anlıcagı dile getirmek için bunları yapıyoruz.
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
