using Carry.Redis.Domain.Dto;
using Carry.Redis.Domain.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Carry.Redis.Service
{
    public class RedisQueryHandler : IRequestHandler<QueryDto, QueryResponse>
    {

        private readonly IRedisQueryService _redis;

        public RedisQueryHandler(IRedisQueryService redis)
        {
            _redis = redis ?? throw new ArgumentNullException(nameof(redis));
        }

        public async Task<QueryResponse> Handle(QueryDto request, CancellationToken cancellationToken)
        {
            return await this._redis.GetQueryAsync(request.CacheKey).ConfigureAwait(false);
        }


    }
}
