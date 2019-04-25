using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Caching
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly ObjectCache _cache = MemoryCache.Default;

        public void Add(string key, object data, int expireAsMinute)
        {
            if (data == null)
            {
                return;
            }

            if (IsExist(key))
            {
                Remove(key);
            }

            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(expireAsMinute) };
            _cache.Add(new CacheItem(key, data), policy);
        }

        public void Clear()
        {
            foreach (var item in _cache)
            {
                Remove(item.Key);
            }
        }

        public T Get<T>(string key)
        {
            return (T)_cache[key];
        }

        public bool IsExist(string key)
        {
            return _cache.Any(_ => _.Key == key);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
