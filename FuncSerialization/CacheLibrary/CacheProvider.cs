using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CacheLibrary
{
    public class CacheProvider
    {
        public TResult GetCache<TResult>(string cacheKey, DelegateWrapper<TResult> delegateFunc)
        {
            // 如果 Cache 命中
            if (this.TryGetCache(cacheKey, out TResult result))
            {
                // 如果 Cache 一分鐘以內要到期，將 delegate function 傳遞到後端執行並更新 Cache。
                if (this.GetCacheTimeToLive() < 60)
                {
                    var formatter = new BinaryFormatter();

                    // Dummy: save delegate function as a binary file
                    using (var fs = new FileStream(
                        Path.ChangeExtension(Path.Combine(@"D:\", cacheKey), "bin"),
                        FileMode.Create,
                        FileAccess.Write,
                        FileShare.None))
                    {
                        formatter.Serialize(fs, delegateFunc);
                    }
                }

                // Dummy: try invoke delegate function
                return delegateFunc.Invoke();
            }
            else
            {
                return this.SetCache(cacheKey, delegateFunc.Invoke(), 60);
            }
        }

        private TResult SetCache<TResult>(string cacheKey, TResult result, int timeout)
        {
            return result;
        }

        private bool TryGetCache<TResult>(string cacheKey, out TResult result)
        {
            result = default(TResult);

            return true;
        }

        private int GetCacheTimeToLive()
        {
            return 59;
        }
    }
}