using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carry.Redis.Data
{
    public class RedisQuery : IRedisQuery
    {

        private readonly IDatabase _redis;

        public RedisQuery(IDatabase redis)
        {
            this._redis = redis;
        }


        public async Task<RedisValue> GetCacheAsync(string cacheKey)
        {
            if (string.IsNullOrEmpty(cacheKey))
            {
                throw new ArgumentNullException(nameof(cacheKey));
            }
             
            return await _redis.StringGetAsync(cacheKey);
        }

     
    }
}
