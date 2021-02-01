using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carry.Redis.Data
{
    public class RedisCommand : IRedisCommand
    {

        private readonly IDatabase _redis;

        public RedisCommand(IDatabase redis)
        {
            this._redis = redis;
        }


        public async Task AddToCacheAsync(KeyValuePair<string, string> value)
        {
             if (value.Value == null || string.IsNullOrEmpty(value.Key))
             {
                 throw new ArgumentNullException(nameof(value));
             }
           
             var getCache = await this._redis.StringGetAsync(value.Key);
           
             if (!getCache.IsNullOrEmpty)
             {
                 _redis.KeyDelete(value.Key);
                 _redis.StringSet(value.Key, value.Value);
             }
            
            await _redis.StringSetAsync(value.Key, value.Value);
        }

        public async Task DeleteCacheAsync(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            await _redis.KeyDeleteAsync(key);
        }


    }
}
