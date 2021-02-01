using Carry.Redis.Data;
using Carry.Redis.Domain.Dto;
using Carry.Redis.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Carry.Redis.Service
{
    public class RedisCommandService : IRedisCommandService
    {

        private readonly IRedisCommand _command;

        public RedisCommandService(IRedisCommand command)
        {
            this._command = command ?? throw new ArgumentNullException(nameof(command));
        }

        public async Task<CommandResponse> AddDataToCacheAsync(AddDto addCache)
        {
            if (string.IsNullOrEmpty(addCache.Key) || string.IsNullOrEmpty(addCache.Value) )
            {
                throw new ArgumentNullException(nameof(addCache));
            }

            await this._command.AddToCacheAsync(new KeyValuePair<string, string>(addCache.Key, addCache.Value))
                               .ConfigureAwait(false);

            return new CommandResponse
            {
                StatusCode = 201,
                Message = "Successfully added to cache"
            };
        }

        public async Task<CommandResponse> DeleteCacheAsync(string key)
        {
            await this._command.DeleteCacheAsync(key).ConfigureAwait(false);

            return new CommandResponse
            {
                Message = $"Successfully deleted cached {key}",
                StatusCode = 200
            };
        }

    }
}
