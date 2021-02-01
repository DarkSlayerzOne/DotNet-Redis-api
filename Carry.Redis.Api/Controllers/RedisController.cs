using System;
using System.Threading.Tasks;
using Carry.Redis.Api.Key;
using Carry.Redis.Domain.Dto;
using Carry.Redis.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Carry.Redis.Api.Controllers
{
    [Route("api/v1/redis")]
    [ApiController]
    [KeyFilter]
    public class RedisController : ControllerBase
    {

        private readonly IMediator _mediatr;

        public RedisController(IMediator mediator)
        {
            this._mediatr = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Add data to redis cache.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<CommandResponse> AddToCache(AddDto cache)
        {
            return await this._mediatr.Send(cache).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the cached data from redis server.
        /// </summary>
        /// <param name="cacheKey">The cache key.</param>
        /// <returns></returns>
        [HttpGet, Route("{cacheKey}")]
        public async Task<QueryResponse> GetCachedData(string cacheKey)
        {
            return await this._mediatr.Send(new QueryDto { CacheKey = cacheKey  }).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes the cached data.
        /// </summary>
        /// <param name="cacheKey">The cache key.</param>
        /// <returns></returns>
        [HttpDelete, Route("{cacheKey}")]
        public async Task<CommandResponse> DeleteCachedData(string cacheKey)
        {
            return await this._mediatr.Send(new DeleteDto { Key = cacheKey }).ConfigureAwait(false);
        }

    }
}