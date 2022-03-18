using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    //Hashleme ihtiyacımız olursa diye hachleme aracı oluşturuyoruz. Bu bizim için bir araç oldugundan dolayı IEntity gibi implemantasyonu yapmıyoruz. 
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //out komutununamacı boş bile olsa doldurup gönderiyor.Birden fazla değerde döndürülebilir.
            using(var hmac= new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;//salting(tuzlama) oluşturmak için biz hmac in key ini kullanıyoruz başka bişey de kullanmak istersek kullanabiliriz. Standart olmak zorunda şifreyi çözerken bunu kullanıyoruz. Algoritma HMACSHA512 her oluşturdugunda key üretir. her kullanıcı  için farklı bir key oluşur.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //Encoding.utf8.getbytes yaparak string olan passwordu byte dizisine çevirdik.
            }
        }
        //Burada PasswordHash dogruluyoruz. out kullanmıyoruz çünü bu değerleri biz vericez. Burası bizim veritabanındaki hashmiz olucak. bu hashle kullanıcının gönderdiği parolanın hashını karşılaştırıp dogrulugunu teyit ediyoruz.
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))//passwordSaltı vermemimiz sebebi dogrulama yapmamız. Önceki parolaya biz kendi ürettiğimiz salt değerini eklemiştik sebebi parolayı güçlendirmek. parolaya eklenen salt değeriyle beraber yeni paroloyı hashliyoruz.bu yüzden biz burada saltPassword değerinin hashing değerini buluyoruz. şifremiz: 123 olsun saltımız: %&( olsun saltPasswordnumuz: 123%&( degeridir. hashing uyguladıgımız şifre zor olsun diye saltPassword a hash yaparız.
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//burada yeni hash oluşturuyoruz bunu oluştururken salt degerini yukarda HMACSHA512 de kullanması gerektiğini söyledik salt değeriyle parolayı birleştirip bunlara hash uyguluyoruz. sonra for döngüsünde veri tabanındaki hash değeriyle metoda parametreyle gelen parolanın hash değerini karşılaştırıp dogrulugunu kontrolediyoz.
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }

                }
            }
            return true;
        }
    }
}
