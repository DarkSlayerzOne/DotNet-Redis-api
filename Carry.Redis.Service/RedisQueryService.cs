using Carry.Redis.Data;
using Carry.Redis.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carry.Redis.Service
{
    public class RedisQueryService : IRedisQueryService
    {

        private readonly IRedisQuery _redis;

        public RedisQueryService(IRedisQuery redis)
        {
            this._redis = redis ?? throw new ArgumentException(nameof(redis));
        }

        public async Task<QueryResponse> GetQueryAsync(string cacheKey)
        {
            if (string.IsNullOrEmpty(cacheKey))
            {
                throw new ArgumentNullException(nameof(cacheKey));
            }

            var result = await this._redis.GetCacheAsync(cacheKey)
                                          .ConfigureAwait(false);

            return new QueryResponse
            {
                Result = result.ToString()
            };
        }


    }
}
