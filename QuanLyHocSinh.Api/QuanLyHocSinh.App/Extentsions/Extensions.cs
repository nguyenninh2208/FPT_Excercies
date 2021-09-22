using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.App.Extentsions
{
    public static class Extensions
    {
        public static string ToMD5Hash(this string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public static void SetUser<T>(this IDistributedCache cache,
            string key,
            T data,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? unusedExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromMinutes(10);
            options.SlidingExpiration = unusedExpireTime;

            var jsonData = JsonConvert.SerializeObject(data);
            cache.SetString(key, jsonData, options);
        }

        public static T GetUser<T>(this IDistributedCache cache, string key)
        {
            var jsonData = cache.GetString(key);
            if (jsonData is null)
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(jsonData);
        }
    }
}
