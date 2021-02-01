using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carry.Redis.Data
{
    public interface IRedisQuery
    {
      
        Task<RedisValue> GetCacheAsync(string cacheKey);

    }
}
