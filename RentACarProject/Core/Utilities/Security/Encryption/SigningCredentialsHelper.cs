using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    //Gelen jsonwebtokenin dogrulaması gerekiyor bizde aspnet e webapiye parametreyle gelen security key anahtarını kullanıcaksın algoritmaolarakta daga önce hash oluştururken kullandıgımız securityalgorithms larından hmacsha512 kullan diyoruz.

    //aspnete diyoruz ki sen hashing işlemi yapıcaksın anahtar olarakta gönderdiğimi bu keyi kullan şifreleme olarakta güvenlik algoritmalarından hmacsha512 kullan diyoruz.
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
