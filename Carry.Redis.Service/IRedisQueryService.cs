using Carry.Redis.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carry.Redis.Service
{
    public interface IRedisQueryService
    {
        Task<QueryResponse> GetQueryAsync(string cacheKey);


    }
}
