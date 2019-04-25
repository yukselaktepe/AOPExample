using AOP.Aspect.Interface;
using Caching;
using System;

namespace AOP.Aspect.Attr
{
    public class CacheAttribute : AspectBase, IBeforeAspect, IAfterVoidAspect
    {
        ICacheManager _caching = new MemoryCacheManager();
        public int DurationInMinute { get; set; }
        public object OnBefore()
        {
            string cacheKey = string.Format("{0}_{1}", AspectContext.Instance.MethodName, string.Join("_", AspectContext.Instance.Arguments));
            object result = null;
            if (_caching.IsExist(cacheKey))
            {
                result = _caching.Get<object>(cacheKey);
                Console.WriteLine("{0} get caching", cacheKey);
            }

            return result;
        }
        public void OnAfter(object value)
        {
            string cacheKey = string.Format("{0}_{1}", AspectContext.Instance.MethodName, string.Join("_", AspectContext.Instance.Arguments));
            if (_caching.IsExist(cacheKey))
                _caching.Remove(cacheKey);

            _caching.Add(cacheKey, value, DurationInMinute);

        }
    }
}
